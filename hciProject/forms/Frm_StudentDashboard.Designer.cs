<<<<<<< HEAD
﻿namespace hciProject
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
            lblWelcome.Location = new Point(248, 40);
            lblWelcome.Margin = new Padding(4, 0, 4, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(138, 38);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome";
            lblWelcome.Click += lblWelcome_Click;
            // 
            // btnRegisterCourses
            // 
            btnRegisterCourses.BackColor = Color.DarkSlateGray;
            btnRegisterCourses.ForeColor = Color.White;
            btnRegisterCourses.Location = new Point(298, 305);
            btnRegisterCourses.Margin = new Padding(4, 4, 4, 4);
            btnRegisterCourses.Name = "btnRegisterCourses";
            btnRegisterCourses.Size = new Size(358, 108);
            btnRegisterCourses.TabIndex = 1;
            btnRegisterCourses.Text = "Register Courses";
            btnRegisterCourses.UseVisualStyleBackColor = false;
            btnRegisterCourses.Click += btnRegisterCourses_Click;
            // 
            // btnTranscript
            // 
            btnTranscript.BackColor = Color.DarkSlateGray;
            btnTranscript.ForeColor = Color.White;
            btnTranscript.Location = new Point(298, 158);
            btnTranscript.Margin = new Padding(4, 4, 4, 4);
            btnTranscript.Name = "btnTranscript";
            btnTranscript.Size = new Size(358, 108);
            btnTranscript.TabIndex = 2;
            btnTranscript.Text = "Transcript";
            btnTranscript.UseVisualStyleBackColor = false;
            btnTranscript.Click += btnTranscript_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.White;
            btnLogout.ForeColor = Color.Red;
            btnLogout.Location = new Point(795, 465);
            btnLogout.Margin = new Padding(4, 4, 4, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(136, 51);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // Frm_StudentDashboard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1000, 564);
            Controls.Add(btnLogout);
            Controls.Add(btnTranscript);
            Controls.Add(btnRegisterCourses);
            Controls.Add(lblWelcome);
            Margin = new Padding(4, 4, 4, 4);
            Name = "Frm_StudentDashboard";
            Text = "Student Dashboard";
            FormClosed += Frm_StudentDashboard_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWelcome;
        private Button btnRegisterCourses;
        private Button btnTranscript;
        private Button btnLogout;
    }
=======
﻿namespace hciProject
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
            FormClosed += Frm_StudentDashboard_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWelcome;
        private Button btnRegisterCourses;
        private Button btnTranscript;
        private Button btnLogout;
    }
>>>>>>> fbe70bcb48a49a963399dc4b53bdd4a819027a3a
}