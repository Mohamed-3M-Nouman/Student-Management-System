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
            LoadTranscriptData();
        }

        private void LoadTranscriptData()
        {
            try
            {
                DBHelper db = new DBHelper();
                int studentId = ProgramSession.StudentId;

                // 1. استعلام يجيب اسم المادة، الساعات، والدرجة
                string sql = $@"SELECT 
                                    C.CourseName AS [Subject], 
                                    C.CreditHours AS [Credits],
                                    E.CourseGrade AS [Score],
                                    E.Semester
                                FROM Enrollments E
                                JOIN Courses C ON E.CourseID = C.CourseID
                                WHERE E.StudentID = {studentId}";

                DataTable dt = db.ExecuteQuery(sql);
                dgvTranscript.DataSource = dt;

                // تنسيق الجدول
                dgvTranscript.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvTranscript.AllowUserToAddRows = false;
                dgvTranscript.ReadOnly = true;

                // 2. حساب الـ GPA بالمعادلة الجديدة
                CalculateGPA(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading transcript: " + ex.Message);
            }
        }

        // دالة تحويل الدرجة المئوية إلى نقاط (حسب اللائحة اللي بعتها)
        private double GetGPAPoints(int score)
        {
            if (score >= 96) return 4.00; // A+
            if (score >= 92) return 3.70; // A
            if (score >= 88) return 3.40; // A-
            if (score >= 84) return 3.20; // B+
            if (score >= 80) return 3.00; // B
            if (score >= 76) return 2.80; // B-
            if (score >= 72) return 2.60; // C+
            if (score >= 68) return 2.40; // C
            if (score >= 64) return 2.20; // C-
            if (score >= 60) return 2.00; // D+
            if (score >= 55) return 1.50; // D
            if (score >= 50) return 1.00; // D-
            return 0.00;                  // F (أقل من 50)
        }

        private void CalculateGPA(DataTable dt)
        {
            double totalWeightedPoints = 0; // مجموع (النقاط × الساعات)
            int totalCreditHours = 0;       // مجموع الساعات الكلية

            foreach (DataRow row in dt.Rows)
            {
                // نتأكد إن فيه درجة مرصودة
                if (row["Score"] != DBNull.Value && row["Score"].ToString() != "")
                {
                    int score = Convert.ToInt32(row["Score"]);
                    int credits = Convert.ToInt32(row["Credits"]);

                    // 1. حول الدرجة لنقاط (مثلاً 93% بتبقى 3.7)
                    double points = GetGPAPoints(score);

                    // 2. اضرب النقاط في عدد ساعات المادة واجمعها
                    totalWeightedPoints += (points * credits);

                    // 3. اجمع عدد الساعات
                    totalCreditHours += credits;
                }
            }

            if (totalCreditHours > 0)
            {
                double gpa = totalWeightedPoints / totalCreditHours;

                lblTotalGPA.Text = "Total GPA: " + gpa.ToString("0.00");
            }
            else
            {
                lblTotalGPA.Text = "GPA: 0.00";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}