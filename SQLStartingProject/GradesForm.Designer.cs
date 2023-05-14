
namespace SQLStartingProject
{
	partial class GradesForm
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
            this.cbxGrades = new System.Windows.Forms.ComboBox();
            this.gvGrades = new System.Windows.Forms.DataGridView();
            this.lblGradeControl = new System.Windows.Forms.Label();
            this.cbxStudents = new System.Windows.Forms.ComboBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lblGradesTitle = new System.Windows.Forms.Label();
            this.chkIsExam = new System.Windows.Forms.CheckBox();
            this.pbxCancelButton = new System.Windows.Forms.PictureBox();
            this.pbxSaveButton = new System.Windows.Forms.PictureBox();
            this.pbxEditButton = new System.Windows.Forms.PictureBox();
            this.pbxAddButton = new System.Windows.Forms.PictureBox();
            this.cbxSubjects = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAddEdit = new System.Windows.Forms.Label();
            this.lblAverage = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblAverageValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvGrades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCancelButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSaveButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxEditButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAddButton)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxGrades
            // 
            this.cbxGrades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxGrades.Enabled = false;
            this.cbxGrades.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxGrades.FormattingEnabled = true;
            this.cbxGrades.Items.AddRange(new object[] {
            "",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbxGrades.Location = new System.Drawing.Point(94, 70);
            this.cbxGrades.Name = "cbxGrades";
            this.cbxGrades.Size = new System.Drawing.Size(76, 33);
            this.cbxGrades.TabIndex = 0;
            // 
            // gvGrades
            // 
            this.gvGrades.AllowUserToAddRows = false;
            this.gvGrades.AllowUserToDeleteRows = false;
            this.gvGrades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvGrades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvGrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvGrades.Location = new System.Drawing.Point(57, 203);
            this.gvGrades.MultiSelect = false;
            this.gvGrades.Name = "gvGrades";
            this.gvGrades.ReadOnly = true;
            this.gvGrades.RowHeadersVisible = false;
            this.gvGrades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvGrades.Size = new System.Drawing.Size(850, 269);
            this.gvGrades.TabIndex = 14;
            this.gvGrades.TabStop = false;
            this.gvGrades.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvGrades_CellClick);
            // 
            // lblGradeControl
            // 
            this.lblGradeControl.AutoSize = true;
            this.lblGradeControl.Enabled = false;
            this.lblGradeControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGradeControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGradeControl.Location = new System.Drawing.Point(91, 50);
            this.lblGradeControl.Name = "lblGradeControl";
            this.lblGradeControl.Size = new System.Drawing.Size(48, 17);
            this.lblGradeControl.TabIndex = 17;
            this.lblGradeControl.Text = "Grade";
            // 
            // cbxStudents
            // 
            this.cbxStudents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxStudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxStudents.FormattingEnabled = true;
            this.cbxStudents.Location = new System.Drawing.Point(57, 89);
            this.cbxStudents.Name = "cbxStudents";
            this.cbxStudents.Size = new System.Drawing.Size(514, 33);
            this.cbxStudents.TabIndex = 18;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(57, 69);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(57, 17);
            this.lblName.TabIndex = 20;
            this.lblName.Text = "Student";
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubject.Location = new System.Drawing.Point(54, 125);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(55, 17);
            this.lblSubject.TabIndex = 21;
            this.lblSubject.Text = "Subject";
            // 
            // lblGradesTitle
            // 
            this.lblGradesTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGradesTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGradesTitle.Location = new System.Drawing.Point(12, 9);
            this.lblGradesTitle.Name = "lblGradesTitle";
            this.lblGradesTitle.Size = new System.Drawing.Size(924, 31);
            this.lblGradesTitle.TabIndex = 22;
            this.lblGradesTitle.Text = "Grades";
            this.lblGradesTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chkIsExam
            // 
            this.chkIsExam.AutoSize = true;
            this.chkIsExam.Enabled = false;
            this.chkIsExam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsExam.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkIsExam.Location = new System.Drawing.Point(104, 105);
            this.chkIsExam.Name = "chkIsExam";
            this.chkIsExam.Size = new System.Drawing.Size(75, 21);
            this.chkIsExam.TabIndex = 23;
            this.chkIsExam.Text = "Is Exam";
            this.chkIsExam.UseVisualStyleBackColor = true;
            // 
            // pbxCancelButton
            // 
            this.pbxCancelButton.Enabled = false;
            this.pbxCancelButton.Image = global::SQLStartingProject.Properties.Resources.CancelButtonDisabled;
            this.pbxCancelButton.Location = new System.Drawing.Point(53, 91);
            this.pbxCancelButton.Name = "pbxCancelButton";
            this.pbxCancelButton.Size = new System.Drawing.Size(35, 35);
            this.pbxCancelButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxCancelButton.TabIndex = 27;
            this.pbxCancelButton.TabStop = false;
            this.pbxCancelButton.Tag = "4";
            this.pbxCancelButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_MouseDown);
            this.pbxCancelButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.pbxCancelButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            this.pbxCancelButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_MouseUp);
            // 
            // pbxSaveButton
            // 
            this.pbxSaveButton.Enabled = false;
            this.pbxSaveButton.Image = global::SQLStartingProject.Properties.Resources.SaveButtonDisabled;
            this.pbxSaveButton.Location = new System.Drawing.Point(12, 91);
            this.pbxSaveButton.Name = "pbxSaveButton";
            this.pbxSaveButton.Size = new System.Drawing.Size(35, 35);
            this.pbxSaveButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxSaveButton.TabIndex = 26;
            this.pbxSaveButton.TabStop = false;
            this.pbxSaveButton.Tag = "3";
            this.pbxSaveButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_MouseDown);
            this.pbxSaveButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.pbxSaveButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            this.pbxSaveButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_MouseUp);
            // 
            // pbxEditButton
            // 
            this.pbxEditButton.Enabled = false;
            this.pbxEditButton.Image = global::SQLStartingProject.Properties.Resources.EditButtonDisabled;
            this.pbxEditButton.Location = new System.Drawing.Point(53, 50);
            this.pbxEditButton.Name = "pbxEditButton";
            this.pbxEditButton.Size = new System.Drawing.Size(35, 35);
            this.pbxEditButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxEditButton.TabIndex = 25;
            this.pbxEditButton.TabStop = false;
            this.pbxEditButton.Tag = "2";
            this.pbxEditButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_MouseDown);
            this.pbxEditButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.pbxEditButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            this.pbxEditButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_MouseUp);
            // 
            // pbxAddButton
            // 
            this.pbxAddButton.Enabled = false;
            this.pbxAddButton.Image = global::SQLStartingProject.Properties.Resources.AddButtonDisabled;
            this.pbxAddButton.Location = new System.Drawing.Point(12, 50);
            this.pbxAddButton.Name = "pbxAddButton";
            this.pbxAddButton.Size = new System.Drawing.Size(35, 35);
            this.pbxAddButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxAddButton.TabIndex = 24;
            this.pbxAddButton.TabStop = false;
            this.pbxAddButton.Tag = "1";
            this.pbxAddButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_MouseDown);
            this.pbxAddButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.pbxAddButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            this.pbxAddButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_MouseUp);
            // 
            // cbxSubjects
            // 
            this.cbxSubjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSubjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSubjects.FormattingEnabled = true;
            this.cbxSubjects.Location = new System.Drawing.Point(57, 145);
            this.cbxSubjects.Name = "cbxSubjects";
            this.cbxSubjects.Size = new System.Drawing.Size(514, 33);
            this.cbxSubjects.TabIndex = 23;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblAddEdit);
            this.panel1.Controls.Add(this.pbxAddButton);
            this.panel1.Controls.Add(this.pbxEditButton);
            this.panel1.Controls.Add(this.pbxCancelButton);
            this.panel1.Controls.Add(this.pbxSaveButton);
            this.panel1.Controls.Add(this.cbxGrades);
            this.panel1.Controls.Add(this.chkIsExam);
            this.panel1.Controls.Add(this.lblGradeControl);
            this.panel1.Location = new System.Drawing.Point(577, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(193, 145);
            this.panel1.TabIndex = 28;
            // 
            // lblAddEdit
            // 
            this.lblAddEdit.Enabled = false;
            this.lblAddEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddEdit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAddEdit.Location = new System.Drawing.Point(3, 16);
            this.lblAddEdit.Name = "lblAddEdit";
            this.lblAddEdit.Size = new System.Drawing.Size(185, 18);
            this.lblAddEdit.TabIndex = 28;
            this.lblAddEdit.Text = "Add/Edit Grade";
            this.lblAddEdit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblAverage
            // 
            this.lblAverage.BackColor = System.Drawing.Color.Transparent;
            this.lblAverage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAverage.Location = new System.Drawing.Point(3, 15);
            this.lblAverage.Name = "lblAverage";
            this.lblAverage.Size = new System.Drawing.Size(123, 18);
            this.lblAverage.TabIndex = 29;
            this.lblAverage.Text = "Average";
            this.lblAverage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.MistyRose;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblAverageValue);
            this.panel2.Controls.Add(this.lblAverage);
            this.panel2.Location = new System.Drawing.Point(776, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(131, 145);
            this.panel2.TabIndex = 30;
            // 
            // lblAverageValue
            // 
            this.lblAverageValue.BackColor = System.Drawing.Color.Transparent;
            this.lblAverageValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAverageValue.ForeColor = System.Drawing.Color.DarkRed;
            this.lblAverageValue.Location = new System.Drawing.Point(-1, 36);
            this.lblAverageValue.Name = "lblAverageValue";
            this.lblAverageValue.Size = new System.Drawing.Size(131, 107);
            this.lblAverageValue.TabIndex = 30;
            this.lblAverageValue.Text = "-";
            this.lblAverageValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GradesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 512);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbxSubjects);
            this.Controls.Add(this.cbxStudents);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.lblGradesTitle);
            this.Controls.Add(this.gvGrades);
            this.Name = "GradesForm";
            this.Text = "GradesForm";
            this.Load += new System.EventHandler(this.GradesForm_Load);
            this.Shown += new System.EventHandler(this.GradesForm_Shown);
            this.Leave += new System.EventHandler(this.GradesForm_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.gvGrades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCancelButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSaveButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxEditButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAddButton)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cbxGrades;
		private System.Windows.Forms.DataGridView gvGrades;
		private System.Windows.Forms.Label lblGradeControl;
		private System.Windows.Forms.ComboBox cbxStudents;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Label lblSubject;
		private System.Windows.Forms.Label lblGradesTitle;
		private System.Windows.Forms.CheckBox chkIsExam;
		private System.Windows.Forms.PictureBox pbxCancelButton;
		private System.Windows.Forms.PictureBox pbxSaveButton;
		private System.Windows.Forms.PictureBox pbxEditButton;
		private System.Windows.Forms.PictureBox pbxAddButton;
		private System.Windows.Forms.ComboBox cbxSubjects;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblAddEdit;
		private System.Windows.Forms.Label lblAverage;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lblAverageValue;
	}
}