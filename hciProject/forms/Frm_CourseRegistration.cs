using System;
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
}