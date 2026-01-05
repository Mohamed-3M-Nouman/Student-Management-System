using System;
using System.Data;
using System.Windows.Forms;
using hciProject.Data;

namespace hciProject
{
    public partial class Frm_Login : Form
    {
        public Frm_Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DBHelper db = new DBHelper();
            string sql = $"SELECT * FROM Users WHERE Username = '{txtUser.Text.Trim()}' AND PasswordHash = '{txtPass.Text.Trim()}'";

            DataTable dt = db.ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
            {
                ProgramSession.UserId = int.Parse(dt.Rows[0]["UserID"].ToString());
                ProgramSession.UserRole = dt.Rows[0]["Role"].ToString();

                if (dt.Rows[0]["LinkedStudentID"] != DBNull.Value)
                {
                    ProgramSession.StudentId = int.Parse(dt.Rows[0]["LinkedStudentID"].ToString());
                }

                if (ProgramSession.UserRole == "Admin")
                {
                    new Frm_AdminDashboard().Show();
                }
                else
                {
                    new Frm_StudentDashboard().Show();
                }
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
