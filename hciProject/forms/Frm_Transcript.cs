using System;
using System.Data;
using System.Windows.Forms;
using hciProject.Data;

namespace hciProject
{
    public partial class Frm_Transcript : Form
    {
        public Frm_Transcript()
        {
            InitializeComponent();
        }

        private void Frm_Transcript_Load(object sender, EventArgs e)
        {
            LoadTranscript();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadTranscript();
        }

        private void LoadTranscript()
        {
            try
            {
                DBHelper db = new DBHelper();
                int studentId = ProgramSession.StudentId;

                string sql = $@"
            SELECT 
                C.CourseName AS 'Subject', 
                C.CreditHours AS 'Credits', 
                E.AcademicYear AS 'Year', 
                CASE WHEN E.Semester = 1 THEN 'First' ELSE 'Second' END AS 'Semester', 
                E.CourseGrade AS 'Score' 
            FROM Enrollments E
            INNER JOIN Courses C ON E.CourseID = C.CourseID
            WHERE E.StudentID = {studentId} AND E.CourseGrade IS NOT NULL";

                DataTable dt = db.ExecuteQuery(sql);
                dgvTranscript.DataSource = dt;

                CalculateGPA(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private double GetGPAPoints(double score)
        {
            if (score >= 96) return 4.00;
            if (score >= 92) return 3.70;
            if (score >= 88) return 3.40;
            if (score >= 84) return 3.20;
            if (score >= 80) return 3.00;
            if (score >= 76) return 2.80;
            if (score >= 72) return 2.60;
            if (score >= 68) return 2.40;
            if (score >= 64) return 2.20;
            if (score >= 60) return 2.00;
            if (score >= 55) return 1.50;
            if (score >= 50) return 1.00;
            return 0.00;
        }
        private void lblTotalGPA_Click(object sender, EventArgs e)
        {
        }
        private void CalculateGPA(DataTable dt)
        {
            double totalPoints = 0;
            double totalHours = 0;

            foreach (DataRow row in dt.Rows)
            {
                if (row["Score"] != DBNull.Value && row["Credits"] != DBNull.Value)
                {
                    double score = Convert.ToDouble(row["Score"]);
                    int credits = Convert.ToInt32(row["Credits"]);
                    double points = GetGPAPoints(score);

                    totalPoints += (points * credits);
                    totalHours += credits;
                }
            }

            if (totalHours > 0)
            {
                double gpa = totalPoints / totalHours;
                lblTotalGPA.Text = "Total GPA: " + gpa.ToString("0.00");
            }
            else
            {
                lblTotalGPA.Text = "Total GPA: 0.00";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }

}
