namespace hciProject
{
    partial class Frm_StudentDashboard
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
            btnRegisterCourses = new Button();
            btnTranscript = new Button();
            btnLogout = new Button();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.Location = new Point(221, 25);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(93, 25);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome";
            // 
            // btnRegisterCourses
            // 
            btnRegisterCourses.Location = new Point(173, 104);
            btnRegisterCourses.Margin = new Padding(3, 2, 3, 2);
            btnRegisterCourses.Name = "btnRegisterCourses";
            btnRegisterCourses.Size = new Size(118, 52);
            btnRegisterCourses.TabIndex = 1;
            btnRegisterCourses.Text = "Register Courses";
            btnRegisterCourses.UseVisualStyleBackColor = true;
            btnRegisterCourses.Click += btnRegisterCourses_Click;
            // 
            // btnTranscript
            // 
            btnTranscript.Location = new Point(363, 104);
            btnTranscript.Margin = new Padding(3, 2, 3, 2);
            btnTranscript.Name = "btnTranscript";
            btnTranscript.Size = new Size(118, 52);
            btnTranscript.TabIndex = 2;
            btnTranscript.Text = "Transcript";
            btnTranscript.UseVisualStyleBackColor = true;
            btnTranscript.Click += btnTranscript_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(284, 208);
            btnLogout.Margin = new Padding(3, 2, 3, 2);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(95, 31);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // Frm_StudentDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(btnLogout);
            Controls.Add(btnTranscript);
            Controls.Add(btnRegisterCourses);
            Controls.Add(lblWelcome);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Frm_StudentDashboard";
            Text = "Student Dashboard";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWelcome;
        private Button btnRegisterCourses;
        private Button btnTranscript;
        private Button btnLogout;
    }
}