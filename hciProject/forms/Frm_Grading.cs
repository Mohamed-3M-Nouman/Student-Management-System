using System;
using System.Data;
using System.Windows.Forms;
using hciProject.Data;

namespace hciProject
{
    public partial class Frm_Grading : Form
    {
        public Frm_Grading()
        {
            InitializeComponent();

            SetupDataGridView();
            LoadStudentsCombo();
        }

        private void Frm_Grading_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadStudentsCombo(); 
        }

        private void SetupDataGridView()
        {
            dgvStudentCourses.Columns.Clear();
            dgvStudentCourses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudentCourses.AllowUserToAddRows = false;
        }

        private void LoadStudentsCombo()
        {
            try
            {
                DBHelper db = new DBHelper();
                string sql = "SELECT StudentID, FullName FROM Students";
                DataTable dt = db.ExecuteQuery(sql);
                       
                cmbSelectStudent.DataSource = dt;
                cmbSelectStudent.DisplayMember = "FullName";
                cmbSelectStudent.ValueMember = "StudentID"; 

                cmbSelectStudent.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading students: " + ex.Message);
            }
        }

        private void cmbSelectStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSelectStudent.SelectedIndex == -1 || cmbSelectStudent.SelectedValue == null)
                return;

            int studentId;
            bool isNumber = int.TryParse(cmbSelectStudent.SelectedValue.ToString(), out studentId);
            if (!isNumber) return;

            LoadStudentCourses(studentId);
        }

        private void LoadStudentCourses(int studentId)
        {
            DBHelper db = new DBHelper();

            string sql = $@"SELECT 
                                C.CourseID, 
                                C.CourseName, 
                                E.CourseGrade 
                            FROM Enrollments E
                            JOIN Courses C ON E.CourseID = C.CourseID
                            WHERE E.StudentID = {studentId}";

            DataTable dt = db.ExecuteQuery(sql);
            dgvStudentCourses.DataSource = dt;

            if (dgvStudentCourses.Columns.Contains("CourseID"))
                dgvStudentCourses.Columns["CourseID"].Visible = false;

            if (dgvStudentCourses.Columns.Contains("CourseName"))
            {
                dgvStudentCourses.Columns["CourseName"].ReadOnly = true; 
                dgvStudentCourses.Columns["CourseName"].HeaderText = "Subject";
            }

            if (dgvStudentCourses.Columns.Contains("CourseGrade"))
                dgvStudentCourses.Columns["CourseGrade"].HeaderText = "Grade (Enter here)";
        }

        private void btnSaveGrades_Click(object sender, EventArgs e)
        {
            if (cmbSelectStudent.SelectedValue == null) return;

            int studentId = Convert.ToInt32(cmbSelectStudent.SelectedValue);
            DBHelper db = new DBHelper();
            int count = 0;

            foreach (DataGridViewRow row in dgvStudentCourses.Rows)
            {
                if (row.Cells["CourseID"].Value != null)
                {
                    string courseId = row.Cells["CourseID"].Value.ToString();
                    string gradeValue = "NULL"; 

                    if (row.Cells["CourseGrade"].Value != null &&
                        !string.IsNullOrWhiteSpace(row.Cells["CourseGrade"].Value.ToString()))
                    {
                        gradeValue = row.Cells["CourseGrade"].Value.ToString();
                    }

                    string sql = $@"UPDATE Enrollments 
                                    SET CourseGrade = {gradeValue} 
                                    WHERE StudentID = {studentId} AND CourseID = {courseId}";

                    db.ExecuteNonQuery(sql);
                    count++;
                }
            }

            MessageBox.Show($"Done! Grades saved/updated for {count} courses.");
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_Grading_Load_1(object sender, EventArgs e)
        {

        }
    }
}