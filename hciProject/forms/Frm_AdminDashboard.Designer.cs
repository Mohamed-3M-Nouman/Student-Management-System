namespace hciProject
{
    partial class Frm_AdminDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblWelcome = new Label();
            btnManageStudents = new Button();
            btnGrading = new Button();
            btnLogout = new Button();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.ForeColor = Color.Black;
            lblWelcome.Location = new Point(294, 31);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(191, 31);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome Admin";
            lblWelcome.Click += lblWelcome_Click;
            // 
            // btnManageStudents
            // 
            btnManageStudents.BackColor = Color.DarkSlateGray;
            btnManageStudents.ForeColor = SystemColors.Control;
            btnManageStudents.Location = new Point(245, 116);
            btnManageStudents.Margin = new Padding(3, 2, 3, 2);
            btnManageStudents.Name = "btnManageStudents";
            btnManageStudents.Size = new Size(301, 92);
            btnManageStudents.TabIndex = 1;
            btnManageStudents.Text = "Manage Students";
            btnManageStudents.UseVisualStyleBackColor = false;
            // 
            // btnGrading
            // 
            btnGrading.BackColor = Color.DarkSlateGray;
            btnGrading.ForeColor = SystemColors.Control;
            btnGrading.Location = new Point(245, 239);
            btnGrading.Margin = new Padding(3, 2, 3, 2);
            btnGrading.Name = "btnGrading";
            btnGrading.Size = new Size(301, 92);
            btnGrading.TabIndex = 2;
            btnGrading.Text = "Grading";
            btnGrading.UseVisualStyleBackColor = false;
            // 
            // btnLogout
            // 
            btnLogout.ForeColor = Color.Red;
            btnLogout.Location = new Point(638, 371);
            btnLogout.Margin = new Padding(3, 2, 3, 2);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(107, 38);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // Frm_AdminDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnLogout);
            Controls.Add(btnGrading);
            Controls.Add(btnManageStudents);
            Controls.Add(lblWelcome);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Frm_AdminDashboard";
            Text = "Admin Dashboard";
            FormClosed += Frm_AdminDashboard_FormClosed;
            Load += Frm_AdminDashboard_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWelcome;
        private Button btnManageStudents;
        private Button btnGrading;
        private Button btnLogout;
    }
}