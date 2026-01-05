using System;
using System.Data;
using System.Windows.Forms;
using hciProject.Data;

namespace hciProject
{
    public partial class Frm_AddEditStudent : Form
    {
        public int CurrentStudentId = 0;

        public Frm_AddEditStudent()
        {
            InitializeComponent();
        }

        public Frm_AddEditStudent(int studentId)
        {
            InitializeComponent();
            CurrentStudentId = studentId;
        }

        private void Frm_AddEditStudent_Load(object sender, EventArgs e)
        {
            lblNameError.Visible = false;
            lblAddressError.Visible = false;
            lblPhoneError.Visible = false;
            lblDepartmentError.Visible = false;
            lblLevelError.Visible = false;
            lblUsernameError.Visible = false;
            lblPasswordError.Visible = false;

            if (cmbDepartment.Items.Count == 0)
                cmbDepartment.Items.AddRange(new object[] { "CS", "IS", "AI", "IT", "MM", "SE", "BIO" });

            if (cmbLevel.Items.Count == 0)
                cmbLevel.Items.AddRange(new object[] { "1", "2", "3", "4" });

            if (CurrentStudentId > 0)
            {
                this.Text = "Edit Student";
                btnSave.Text = "Update";
                LoadStudentData();
            }
            else
            {
                this.Text = "Add New Student";
                btnSave.Text = "Save";
                cmbDepartment.SelectedIndex = -1;
                cmbLevel.SelectedIndex = -1;
            }
        }

        private void LoadStudentData()
        {
            try
            {
                DBHelper db = new DBHelper();
                string sql = $@"SELECT S.*, U.Username, U.PasswordHash 
                                FROM Students S 
                                LEFT JOIN Users U ON U.LinkedStudentID = S.StudentID 
                                WHERE S.StudentID = {CurrentStudentId}";

                DataTable dt = db.ExecuteQuery(sql);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txtName.Text = row["FullName"].ToString();
                    txtAddress.Text = row["Address"].ToString();
                    txtPhone.Text = row["Phone"].ToString();

                    if (row["Department"] != DBNull.Value) cmbDepartment.Text = row["Department"].ToString();
                    if (row["CurrentLevel"] != DBNull.Value) cmbLevel.Text = row["CurrentLevel"].ToString();

                    if (row["Username"] != DBNull.Value) txtUsername.Text = row["Username"].ToString();
                    if (row["PasswordHash"] != DBNull.Value) txtPassword.Text = row["PasswordHash"].ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
             
                bool isValid = true;
                lblNameError.Visible = false;
                lblAddressError.Visible = false;
                lblPhoneError.Visible = false;
                lblDepartmentError.Visible = false;
                lblLevelError.Visible = false;
                lblUsernameError.Visible = false;
                lblPasswordError.Visible = false;

                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    lblNameError.Visible = true;
                    isValid = false;
                }

                if (string.IsNullOrWhiteSpace(txtAddress.Text))
                {
                    lblAddressError.Visible = true;
                    isValid = false;
                }

                if (string.IsNullOrWhiteSpace(txtPhone.Text))
                {
                    lblPhoneError.Visible = true;
                    isValid = false;
                }

                if (string.IsNullOrWhiteSpace(cmbDepartment.Text))
                {
                    lblDepartmentError.Visible = true;
                    isValid = false;
                }

                if (string.IsNullOrWhiteSpace(cmbLevel.Text))
                {
                    lblLevelError.Visible = true;
                    isValid = false;
                }

                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    lblUsernameError.Visible = true;
                    isValid = false;
                }

                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    lblPasswordError.Visible = true;
                    isValid = false;
                }

                if (!isValid)
                {
                    return;
                }


                DBHelper db = new DBHelper();

                string fullName = txtName.Text.Trim();
                string address = txtAddress.Text.Trim();
                string phone = txtPhone.Text.Trim();
                string deptName = cmbDepartment.Text;
                int level = int.Parse(cmbLevel.Text);
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();

                string getDeptIdSql = $"SELECT DeptID FROM Departments WHERE DeptName = '{deptName}'";
                DataTable dtDept = db.ExecuteQuery(getDeptIdSql);
                int deptId = 1;
                if (dtDept.Rows.Count > 0) deptId = int.Parse(dtDept.Rows[0]["DeptID"].ToString());

                if (CurrentStudentId == 0) 
                {
                    string insertStudentSql = $@"
                INSERT INTO Students (FullName, Address, Phone, Email, CurrentLevel, DeptID, Department) 
                VALUES ('{fullName}', '{address}', '{phone}', NULL, {level}, {deptId}, '{deptName}');
                SELECT SCOPE_IDENTITY();";

                    int newStudentId = Convert.ToInt32(db.ExecuteScalar(insertStudentSql));

                    string insertUserSql = $@"
                INSERT INTO Users (Username, PasswordHash, Role, LinkedStudentID) 
                VALUES ('{username}', '{password}', 'Student', {newStudentId})";

                    db.ExecuteQuery(insertUserSql);
                    MessageBox.Show("Student added successfully!");
                }
                else 
                {
                    string updateStudentSql = $@"
                UPDATE Students 
                SET FullName = '{fullName}', 
                    Address = '{address}', 
                    Phone = '{phone}', 
                    CurrentLevel = {level}, 
                    DeptID = {deptId}, 
                    Department = '{deptName}'
                WHERE StudentID = {CurrentStudentId}";

                    db.ExecuteNonQuery(updateStudentSql);

                    string updateUserSql = $@"
                UPDATE Users 
                SET Username = '{username}', 
                    PasswordHash = '{password}' 
                WHERE LinkedStudentID = {CurrentStudentId}";

                    db.ExecuteNonQuery(updateUserSql);
                    MessageBox.Show("Student updated successfully!");
                }

                this.Close();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE") || ex.Message.Contains("duplicate"))
                    MessageBox.Show("Username already exists. Please choose another one.");
                else
                    MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cmbLevel_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}