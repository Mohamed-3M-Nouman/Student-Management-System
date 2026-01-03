using System;
using System.Data;
using System.Windows.Forms;
using hciProject.Data; // تأكد إن ده المسار الصح لملف DBHelper

namespace hciProject
{
    public partial class Frm_CourseRegistration : Form
    {
        public Frm_CourseRegistration()
        {
            InitializeComponent();
        }

        // 1. حدث تحميل الصفحة
        private void Frm_CourseRegistration_Load(object sender, EventArgs e)
        {
            SetupComboBoxes();
            SetupDataGridView();
            // مش بننادي LoadCourses هنا لأن تغيير الكومبو بوكس هيناديها لوحده
        }

        // 2. دالة تجهيز القوائم (السنوات والترمين)
        private void SetupComboBoxes()
        {
            // أ) تجهيز قائمة الترمات
            cmbSemester.Items.Clear();
            cmbSemester.Items.Add("First");
            cmbSemester.Items.Add("Second");
            cmbSemester.SelectedIndex = 0; // نختار الأول افتراضياً

            // ب) تجهيز قائمة السنوات (بناءً على مستوى الطالب)
            cmbYear.Items.Clear();

            DBHelper db = new DBHelper();
            // نجيب مستوى الطالب الحالي
            string sql = $"SELECT CurrentLevel FROM Students WHERE StudentID = {ProgramSession.StudentId}";
            DataTable dt = db.ExecuteQuery(sql);

            int studentCurrentLevel = 1; // الافتراضي
            if (dt.Rows.Count > 0 && dt.Rows[0]["CurrentLevel"] != DBNull.Value)
            {
                studentCurrentLevel = Convert.ToInt32(dt.Rows[0]["CurrentLevel"]);
            }

            // اللوب الذكي: نعرض سنين من 1 لحد مستوى الطالب بس
            for (int i = 1; i <= studentCurrentLevel; i++)
            {
                cmbYear.Items.Add(i.ToString());
            }

            // نختار آخر سنة هو وصلها
            if (cmbYear.Items.Count > 0)
            {
                cmbYear.SelectedIndex = cmbYear.Items.Count - 1;
            }
        }

        // 3. دالة تصميم الجدول
        private void SetupDataGridView()
        {
            dgvAvailableCourses.Columns.Clear();
            dgvAvailableCourses.AutoGenerateColumns = false;

            // عمود الاختيار
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.HeaderText = "Select";
            checkColumn.Name = "colSelect";
            checkColumn.Width = 50;
            dgvAvailableCourses.Columns.Add(checkColumn);

            // باقي الأعمدة
            dgvAvailableCourses.Columns.Add("colCourseName", "Course Name");
            dgvAvailableCourses.Columns.Add("colHours", "Credits");

            // عمود مخفي للـ ID
            dgvAvailableCourses.Columns.Add("colCourseID", "ID");
            dgvAvailableCourses.Columns["colCourseID"].Visible = false;

            dgvAvailableCourses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAvailableCourses.AllowUserToAddRows = false;
        }

        // 4. دالة تحميل المواد (بناءً على الفلتر)
        private void LoadCourses()
        {
            try
            {
                // لو القوائم لسه فاضية نخرج عشان ميعملش ايرور
                if (cmbYear.Text == "" || cmbSemester.Text == "") return;

                int semesterId = (cmbSemester.Text == "Second") ? 2 : 1;

                // هنا بنعتبر إن اللي مكتوب في الكومبو بوكس هو "مستوى المادة" (1, 2, 3..)
                int selectedYearLevel = 1;
                int.TryParse(cmbYear.Text, out selectedYearLevel);

                DBHelper db = new DBHelper();

                // الشرط: هات المواد بتاعة الترم ده AND السنة الدراسية دي
                string query = $@"SELECT CourseID, CourseName, CreditHours 
                                  FROM Courses 
                                  WHERE DefaultSemester = {semesterId} 
                                  AND YearLevel = {selectedYearLevel}";

                DataTable dt = db.ExecuteQuery(query);

                dgvAvailableCourses.Rows.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    dgvAvailableCourses.Rows.Add(
                        false,
                        row["CourseName"],
                        row["CreditHours"],
                        row["CourseID"]
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading courses: " + ex.Message);
            }
        }

        // 5. أحداث تغيير الاختيار (عشان يحدث الجدول)
        private void cmbSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCourses();
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCourses();
        }

        // 6. زرار الحفظ
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DBHelper db = new DBHelper();
            int successCount = 0;
            string currentAcademicYear = "2025-2026";

            foreach (DataGridViewRow row in dgvAvailableCourses.Rows)
            {
                if (row.Cells["colSelect"].Value != null && (bool)row.Cells["colSelect"].Value == true)
                {
                    string courseId = row.Cells["colCourseID"].Value.ToString();

                    // === التعديل هنا ===
                    // بدل ما نبعت "First" نبعت 1، وبدل "Second" نبعت 2
                    int semesterId = (cmbSemester.Text == "Second") ? 2 : 1;

                    // لاحظ شلنا علامات التنصيص '' من حوالين semesterId لأنه بقى رقم
                    string sql = $@"INSERT INTO Enrollments (StudentID, CourseID, AcademicYear, Semester) 
                            VALUES ({ProgramSession.StudentId}, {courseId}, '{currentAcademicYear}', {semesterId})";

                    try
                    {
                        int result = db.ExecuteNonQuery(sql);
                        if (result > 0) successCount++;
                    }
                    catch (Exception ex)
                    {
                        // ممكن تظهر رسالة الخطأ هنا للتوضيح لو حصلت مشكلة تانية
                        // MessageBox.Show(ex.Message);
                    }
                }
            }

            if (successCount > 0)
            {
                MessageBox.Show($"Done! Registered {successCount} courses.");
                this.Close();
            }
            else
            {
                MessageBox.Show("No courses selected.");
            }
        }

        // دوال فارغة (عشان الديزاينر ميزعلش لو مربوط بيهم)
        private void lblSemester_Click(object sender, EventArgs e) { }
        private void dgvAvailableCourses_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        //private void lblYear_Click(object sender, EventArgs e)
        //{
        //}
    }
}