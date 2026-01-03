namespace hciProject
{
    partial class Frm_CourseRegistration
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
            lblYear = new Label();
            cmbYear = new ComboBox();
            lblSemester = new Label();
            cmbSemester = new ComboBox();
            dgvAvailableCourses = new DataGridView();
            btnConfirm = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAvailableCourses).BeginInit();
            SuspendLayout();
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Location = new Point(225, 32);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(29, 15);
            lblYear.TabIndex = 0;
            lblYear.Text = "Year";
            // 
            // cmbYear
            // 
            cmbYear.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbYear.FormattingEnabled = true;
            cmbYear.Location = new Point(308, 30);
            cmbYear.Margin = new Padding(3, 2, 3, 2);
            cmbYear.Name = "cmbYear";
            cmbYear.Size = new Size(133, 23);
            cmbYear.TabIndex = 1;
            cmbYear.SelectedIndexChanged += cmbSemester_SelectedIndexChanged;
            // 
            // lblSemester
            // 
            lblSemester.AutoSize = true;
            lblSemester.Location = new Point(225, 85);
            lblSemester.Name = "lblSemester";
            lblSemester.Size = new Size(55, 15);
            lblSemester.TabIndex = 2;
            lblSemester.Text = "Semester";
            lblSemester.Click += lblSemester_Click;
            // 
            // cmbSemester
            // 
            cmbSemester.FormattingEnabled = true;
            cmbSemester.Items.AddRange(new object[] { "First", "Second" });
            cmbSemester.Location = new Point(308, 82);
            cmbSemester.Margin = new Padding(3, 2, 3, 2);
            cmbSemester.Name = "cmbSemester";
            cmbSemester.Size = new Size(133, 23);
            cmbSemester.TabIndex = 3;
            cmbSemester.SelectedIndexChanged += cmbSemester_SelectedIndexChanged;
            cmbSemester.Click += lblSemester_Click;
            // 
            // dgvAvailableCourses
            // 
            dgvAvailableCourses.AccessibleName = "";
            dgvAvailableCourses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAvailableCourses.Location = new Point(207, 122);
            dgvAvailableCourses.Margin = new Padding(3, 2, 3, 2);
            dgvAvailableCourses.Name = "dgvAvailableCourses";
            dgvAvailableCourses.RowHeadersWidth = 51;
            dgvAvailableCourses.Size = new Size(365, 217);
            dgvAvailableCourses.TabIndex = 4;
            dgvAvailableCourses.CellContentClick += dgvAvailableCourses_CellContentClick;
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(268, 371);
            btnConfirm.Margin = new Padding(3, 2, 3, 2);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(173, 22);
            btnConfirm.TabIndex = 5;
            btnConfirm.Text = "Confirm Registration";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // Frm_CourseRegistration
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 438);
            Controls.Add(btnConfirm);
            Controls.Add(dgvAvailableCourses);
            Controls.Add(cmbSemester);
            Controls.Add(lblSemester);
            Controls.Add(cmbYear);
            Controls.Add(lblYear);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Frm_CourseRegistration";
            Text = "Course Registration";
            Load += Frm_CourseRegistration_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAvailableCourses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblYear;
        private ComboBox cmbYear;
        private Label lblSemester;
        private ComboBox cmbSemester;
        private DataGridView dgvAvailableCourses;
        private Button btnConfirm;
    }
}