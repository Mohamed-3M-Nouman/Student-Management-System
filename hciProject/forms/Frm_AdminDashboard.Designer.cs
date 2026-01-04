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
            lblWelcome.ForeColor = Color.DarkRed;
            lblWelcome.Location = new Point(255, 26);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(157, 25);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome Admin";
            // 
            // btnManageStudents
            // 
            btnManageStudents.Location = new Point(153, 120);
            btnManageStudents.Margin = new Padding(3, 2, 3, 2);
            btnManageStudents.Name = "btnManageStudents";
            btnManageStudents.Size = new Size(147, 58);
            btnManageStudents.TabIndex = 1;
            btnManageStudents.Text = "Manage Students";
            btnManageStudents.UseVisualStyleBackColor = true;
            // 
            // btnGrading
            // 
            btnGrading.Location = new Point(394, 120);
            btnGrading.Margin = new Padding(3, 2, 3, 2);
            btnGrading.Name = "btnGrading";
            btnGrading.Size = new Size(147, 58);
            btnGrading.TabIndex = 2;
            btnGrading.Text = "Grading";
            btnGrading.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(303, 242);
            btnLogout.Margin = new Padding(3, 2, 3, 2);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(94, 28);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // Frm_AdminDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
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