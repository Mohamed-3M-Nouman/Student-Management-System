<<<<<<< HEAD
﻿namespace hciProject
{
    partial class Frm_Grading
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
            lblSelectStudent = new Label();
            cmbSelectStudent = new ComboBox();
            dgvStudentCourses = new DataGridView();
            btnSaveGrades = new Button();
            back_btn = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvStudentCourses).BeginInit();
            SuspendLayout();
            // 
            // lblSelectStudent
            // 
            lblSelectStudent.AutoSize = true;
            lblSelectStudent.Location = new Point(291, 67);
            lblSelectStudent.Margin = new Padding(4, 0, 4, 0);
            lblSelectStudent.Name = "lblSelectStudent";
            lblSelectStudent.Size = new Size(124, 25);
            lblSelectStudent.TabIndex = 0;
            lblSelectStudent.Text = "Select Student";
            // 
            // cmbSelectStudent
            // 
            cmbSelectStudent.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSelectStudent.FormattingEnabled = true;
            cmbSelectStudent.Location = new Point(440, 63);
            cmbSelectStudent.Margin = new Padding(4, 3, 4, 3);
            cmbSelectStudent.Name = "cmbSelectStudent";
            cmbSelectStudent.Size = new Size(188, 33);
            cmbSelectStudent.TabIndex = 1;
            cmbSelectStudent.SelectedIndexChanged += cmbSelectStudent_SelectedIndexChanged;
            cmbSelectStudent.Click += cmbSelectStudent_SelectedIndexChanged;
            // 
            // dgvStudentCourses
            // 
            dgvStudentCourses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudentCourses.Location = new Point(13, 132);
            dgvStudentCourses.Margin = new Padding(4, 3, 4, 3);
            dgvStudentCourses.Name = "dgvStudentCourses";
            dgvStudentCourses.RowHeadersWidth = 51;
            dgvStudentCourses.Size = new Size(974, 316);
            dgvStudentCourses.TabIndex = 2;
            // 
            // btnSaveGrades
            // 
            btnSaveGrades.BackColor = Color.Green;
            btnSaveGrades.ForeColor = SystemColors.ButtonHighlight;
            btnSaveGrades.Location = new Point(313, 470);
            btnSaveGrades.Margin = new Padding(4, 3, 4, 3);
            btnSaveGrades.Name = "btnSaveGrades";
            btnSaveGrades.Size = new Size(163, 69);
            btnSaveGrades.TabIndex = 3;
            btnSaveGrades.Text = "Save Grades";
            btnSaveGrades.UseVisualStyleBackColor = false;
            btnSaveGrades.Click += btnSaveGrades_Click;
            // 
            // back_btn
            // 
            back_btn.BackColor = Color.Red;
            back_btn.ForeColor = SystemColors.Control;
            back_btn.Location = new Point(516, 470);
            back_btn.Margin = new Padding(4, 5, 4, 5);
            back_btn.Name = "back_btn";
            back_btn.Size = new Size(171, 69);
            back_btn.TabIndex = 4;
            back_btn.Text = "close";
            back_btn.UseVisualStyleBackColor = false;
            back_btn.Click += back_btn_Click;
            // 
            // Frm_Grading
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 563);
            Controls.Add(back_btn);
            Controls.Add(btnSaveGrades);
            Controls.Add(dgvStudentCourses);
            Controls.Add(cmbSelectStudent);
            Controls.Add(lblSelectStudent);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Frm_Grading";
            Text = "Grading";
            Load += Frm_Grading_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvStudentCourses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSelectStudent;
        private ComboBox cmbSelectStudent;
        private DataGridView dgvStudentCourses;
        private Button btnSaveGrades;
        private Button back_btn;
    }
=======
﻿namespace hciProject
{
    partial class Frm_Grading
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
            lblSelectStudent = new Label();
            cmbSelectStudent = new ComboBox();
            dgvStudentCourses = new DataGridView();
            btnSaveGrades = new Button();
            back_btn = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvStudentCourses).BeginInit();
            SuspendLayout();
            // 
            // lblSelectStudent
            // 
            lblSelectStudent.AutoSize = true;
            lblSelectStudent.Location = new Point(204, 40);
            lblSelectStudent.Name = "lblSelectStudent";
            lblSelectStudent.Size = new Size(82, 15);
            lblSelectStudent.TabIndex = 0;
            lblSelectStudent.Text = "Select Student";
            // 
            // cmbSelectStudent
            // 
            cmbSelectStudent.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSelectStudent.FormattingEnabled = true;
            cmbSelectStudent.Location = new Point(308, 38);
            cmbSelectStudent.Margin = new Padding(3, 2, 3, 2);
            cmbSelectStudent.Name = "cmbSelectStudent";
            cmbSelectStudent.Size = new Size(133, 23);
            cmbSelectStudent.TabIndex = 1;
            cmbSelectStudent.SelectedIndexChanged += cmbSelectStudent_SelectedIndexChanged;
            cmbSelectStudent.Click += cmbSelectStudent_SelectedIndexChanged;
            // 
            // dgvStudentCourses
            // 
            dgvStudentCourses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudentCourses.Location = new Point(199, 79);
            dgvStudentCourses.Margin = new Padding(3, 2, 3, 2);
            dgvStudentCourses.Name = "dgvStudentCourses";
            dgvStudentCourses.RowHeadersWidth = 51;
            dgvStudentCourses.Size = new Size(262, 141);
            dgvStudentCourses.TabIndex = 2;
            // 
            // btnSaveGrades
            // 
            btnSaveGrades.Location = new Point(199, 261);
            btnSaveGrades.Margin = new Padding(3, 2, 3, 2);
            btnSaveGrades.Name = "btnSaveGrades";
            btnSaveGrades.Size = new Size(114, 22);
            btnSaveGrades.TabIndex = 3;
            btnSaveGrades.Text = "Save Grades";
            btnSaveGrades.UseVisualStyleBackColor = true;
            btnSaveGrades.Click += btnSaveGrades_Click;
            // 
            // back_btn
            // 
            back_btn.Location = new Point(341, 261);
            back_btn.Name = "back_btn";
            back_btn.Size = new Size(120, 22);
            back_btn.TabIndex = 4;
            back_btn.Text = "close";
            back_btn.UseVisualStyleBackColor = true;
            back_btn.Click += back_btn_Click;
            // 
            // Frm_Grading
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(back_btn);
            Controls.Add(btnSaveGrades);
            Controls.Add(dgvStudentCourses);
            Controls.Add(cmbSelectStudent);
            Controls.Add(lblSelectStudent);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Frm_Grading";
            Text = "Grading";
            Load += Frm_Grading_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvStudentCourses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSelectStudent;
        private ComboBox cmbSelectStudent;
        private DataGridView dgvStudentCourses;
        private Button btnSaveGrades;
        private Button back_btn;
    }
>>>>>>> fbe70bcb48a49a963399dc4b53bdd4a819027a3a
}