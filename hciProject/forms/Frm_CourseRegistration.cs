<<<<<<< HEAD
﻿using System;
using System.Data;
using System.Windows.Forms;
using hciProject.Data;

namespace hciProject
{
    public partial class Frm_CourseRegistration : Form
    {
        public Frm_CourseRegistration()
        {
            InitializeComponent();
        }

        private void Frm_CourseRegistration_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            SetupComboBoxes();
        }

        private void SetupDataGridView()
        {
            dgvCourses.Columns.Clear();

            DataGridViewCheckBoxColumn checkCol = new DataGridViewCheckBoxColumn();
            checkCol.Name = "Select";
            checkCol.HeaderText = "Select";
            checkCol.Width = 50;
            dgvCourses.Columns.Add(checkCol);

            dgvCourses.Columns.Add("CourseID", "ID");
            dgvCourses.Columns.Add("CourseName", "Subject");
            dgvCourses.Columns.Add("CreditHours", "Credit Hours");
            dgvCourses.Columns.Add("ProfessorName", "Professor"); 

            dgvCourses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCourses.AllowUserToAddRows = false;
        }

        private void SetupComboBoxes()
        {
            cmbYear.Items.Clear();
            cmbYear.Items.AddRange(new object[] { "1", "2", "3", "4" });

            cmbSemester.Items.Clear();
            cmbSemester.Items.AddRange(new object[] { "First", "Second" });

            try
            {
                DBHelper db = new DBHelper();
                int studentId = ProgramSession.StudentId;

                string sql = $"SELECT CurrentLevel FROM Students WHERE StudentID = {studentId}";
                DataTable dt = db.ExecuteQuery(sql);

                if (dt.Rows.Count > 0)
                {
                    cmbYear.Text = dt.Rows[0]["CurrentLevel"].ToString();
                }
                else
                {
                    cmbYear.SelectedIndex = 0;
                }
                cmbSemester.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching student level: " + ex.Message);
            }
        }

        private void LoadCourses()
        {
            if (cmbYear.SelectedIndex == -1 || cmbSemester.SelectedIndex == -1) return;

            try
            {
                DBHelper db = new DBHelper();
                string year = cmbYear.Text;

                int semesterId = (cmbSemester.Text == "First") ? 1 : 2;

                string sql = $@"SELECT CourseID, CourseName, CreditHours, ProfessorName 
                                FROM Courses 
                                WHERE YearLevel = {year} AND DefaultSemester = {semesterId}";

                DataTable dt = db.ExecuteQuery(sql);

                dgvCourses.Rows.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    dgvCourses.Rows.Add(
                        false,
                        row["CourseID"],
                        row["CourseName"],
                        row["CreditHours"],
                        row["ProfessorName"] 
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading courses: " + ex.Message);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                DBHelper db = new DBHelper();
                int studentId = ProgramSession.StudentId;
                int count = 0;

                int semesterId = (cmbSemester.Text == "First") ? 1 : 2;
                string year = cmbYear.Text;
                string academicYearStr = DateTime.Now.Year.ToString();

                foreach (DataGridViewRow row in dgvCourses.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["Select"].Value) == true)
                    {
                        string courseId = row.Cells["CourseID"].Value.ToString();

                        string checkSql = $"SELECT * FROM Enrollments WHERE StudentID={studentId} AND CourseID={courseId}";
                        if (db.ExecuteQuery(checkSql).Rows.Count == 0)
                        {
                            string insertSql = $@"INSERT INTO Enrollments (StudentID, CourseID, Semester, AcademicYear) 
                                                  VALUES ({studentId}, {courseId}, {semesterId}, '{academicYearStr}')";
                            db.ExecuteNonQuery(insertSql);
                            count++;
                        }
                    }
                }

                if (count > 0)
                    MessageBox.Show($"Successfully registered {count} courses!");
                else
                    MessageBox.Show("No new courses selected.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e) { LoadCourses(); }
        private void cmbSemester_SelectedIndexChanged(object sender, EventArgs e) { LoadCourses(); }
        private void dgvAvailableCourses_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
=======
﻿using System;
using System.Data;
using System.Windows.Forms;
using hciProject.Data;

namespace hciProject
{
    public partial class Frm_CourseRegistration : Form
    {
        public Frm_CourseRegistration()
        {
            InitializeComponent();
        }

        private void Frm_CourseRegistration_Load(object sender, EventArgs e)
        {
            // 1. تجهيز الجدول أولاً (عشان نتجنب خطأ الأعمدة)
            SetupDataGridView();

            // 2. تجهيز القوائم واختيار سنة الطالب أوتوماتيك
            SetupComboBoxes();
        }

        private void SetupDataGridView()
        {
            // إضافة أعمدة للجدول لو مش موجودة
            dgvCourses.Columns.Clear();

            DataGridViewCheckBoxColumn checkCol = new DataGridViewCheckBoxColumn();
            checkCol.Name = "Select";
            checkCol.HeaderText = "Select";
            checkCol.Width = 50;
            dgvCourses.Columns.Add(checkCol);

            dgvCourses.Columns.Add("CourseID", "ID");
            dgvCourses.Columns.Add("CourseName", "Subject");
            dgvCourses.Columns.Add("CreditHours", "Credit Hours");
            dgvCourses.Columns.Add("Instructor", "Instructor");

            dgvCourses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCourses.AllowUserToAddRows = false; // منع صفوف إضافية فاضية
        }

        private void SetupComboBoxes()
        {
            // أ) ملء السنوات
            cmbYear.Items.Clear();
            cmbYear.Items.AddRange(new object[] { "1", "2", "3", "4" });

            // ب) ملء الترمات
            cmbSemester.Items.Clear();
            cmbSemester.Items.AddRange(new object[] { "First", "Second" });

            // ج) تحديد سنة الطالب تلقائياً من الداتا بيز
            try
            {
                DBHelper db = new DBHelper();
                int studentId = ProgramSession.StudentId; // رقم الطالب المسجل دخول

                string sql = $"SELECT CurrentLevel FROM Students WHERE StudentID = {studentId}";
                DataTable dt = db.ExecuteQuery(sql);

                if (dt.Rows.Count > 0)
                {
                    string currentLevel = dt.Rows[0]["CurrentLevel"].ToString();
                    cmbYear.Text = currentLevel; // اختيار السنة بتاعته
                }
                else
                {
                    cmbYear.SelectedIndex = 0; // لو حصل خطأ اختار أول سنة
                }

                // اختيار الترم الأول افتراضياً
                cmbSemester.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching student level: " + ex.Message);
            }
        }

        // الدالة دي بتشتغل لما نغير السنة أو الترم
        private void LoadCourses()
        {
            // لو لسه مفيش اختيار، اخرج
            if (cmbYear.SelectedIndex == -1 || cmbSemester.SelectedIndex == -1) return;

            try
            {
                DBHelper db = new DBHelper();
                string year = cmbYear.Text;
                string semester = cmbSemester.Text;

                // هات المواد المناسبة للسنة والترم ده
                string sql = $@"SELECT CourseID, CourseName, CreditHours, Instructor 
                                FROM Courses 
                                WHERE AcademicYear = {year} AND Semester = '{semester}'";

                DataTable dt = db.ExecuteQuery(sql);

                dgvCourses.Rows.Clear(); // فضي الجدول القديم

                foreach (DataRow row in dt.Rows)
                {
                    dgvCourses.Rows.Add(
                        false, // الـ Checkbox فاضي في الأول
                        row["CourseID"],
                        row["CourseName"],
                        row["CreditHours"],
                        row["Instructor"]
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading courses: " + ex.Message);
            }
        }

        // الأحداث (Events)
        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCourses();
        }

        private void cmbSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCourses();
        }

        // زر التأكيد (الحفظ)
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                DBHelper db = new DBHelper();
                int studentId = ProgramSession.StudentId;
                int count = 0;

                foreach (DataGridViewRow row in dgvCourses.Rows)
                {
                    // لو الطالب عمل علامة صح
                    if (Convert.ToBoolean(row.Cells["Select"].Value) == true)
                    {
                        string courseId = row.Cells["CourseID"].Value.ToString();
                        string semester = cmbSemester.Text;
                        string year = cmbYear.Text;

                        // تأكد إنه مش مسجل المادة دي قبل كده
                        string checkSql = $"SELECT * FROM Enrollments WHERE StudentID={studentId} AND CourseID={courseId}";
                        if (db.ExecuteQuery(checkSql).Rows.Count == 0)
                        {
                            string insertSql = $@"INSERT INTO Enrollments (StudentID, CourseID, Semester, AcademicYear) 
                                                  VALUES ({studentId}, {courseId}, '{semester}', {year})";
                            db.ExecuteNonQuery(insertSql);
                            count++;
                        }
                    }
                }

                if (count > 0)
                    MessageBox.Show($"Successfully registered {count} courses!");
                else
                    MessageBox.Show("No new courses selected.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dgvAvailableCourses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
>>>>>>> fbe70bcb48a49a963399dc4b53bdd4a819027a3a
}