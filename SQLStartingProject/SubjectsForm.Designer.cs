
namespace SQLStartingProject
{
	partial class SubjectsForm
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
            this.gvSubjects = new System.Windows.Forms.DataGridView();
            this.pbxCancelButton = new System.Windows.Forms.PictureBox();
            this.pbxSaveButton = new System.Windows.Forms.PictureBox();
            this.pbxEditButton = new System.Windows.Forms.PictureBox();
            this.pbxAddButton = new System.Windows.Forms.PictureBox();
            this.lblSubjectName = new System.Windows.Forms.Label();
            this.txtSubjectName = new System.Windows.Forms.TextBox();
            this.chkHasExam = new System.Windows.Forms.CheckBox();
            this.lblSubjectsTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAddEdit = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvSubjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCancelButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSaveButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxEditButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAddButton)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvSubjects
            // 
            this.gvSubjects.AllowUserToAddRows = false;
            this.gvSubjects.AllowUserToDeleteRows = false;
            this.gvSubjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvSubjects.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvSubjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSubjects.Location = new System.Drawing.Point(40, 163);
            this.gvSubjects.MultiSelect = false;
            this.gvSubjects.Name = "gvSubjects";
            this.gvSubjects.ReadOnly = true;
            this.gvSubjects.RowHeadersVisible = false;
            this.gvSubjects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvSubjects.Size = new System.Drawing.Size(867, 308);
            this.gvSubjects.TabIndex = 14;
            this.gvSubjects.TabStop = false;
            this.gvSubjects.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvStudents_CellClick);
            this.gvSubjects.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gvStudents_MouseClick);
            // 
            // pbxCancelButton
            // 
            this.pbxCancelButton.Enabled = false;
            this.pbxCancelButton.Image = global::SQLStartingProject.Properties.Resources.CancelButtonDisabled;
            this.pbxCancelButton.Location = new System.Drawing.Point(62, 75);
            this.pbxCancelButton.Name = "pbxCancelButton";
            this.pbxCancelButton.Size = new System.Drawing.Size(35, 35);
            this.pbxCancelButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxCancelButton.TabIndex = 25;
            this.pbxCancelButton.TabStop = false;
            this.pbxCancelButton.Tag = "4";
            this.pbxCancelButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbxAddButton_MouseDown);
            this.pbxCancelButton.MouseEnter += new System.EventHandler(this.pbxAddButton_MouseEnter);
            this.pbxCancelButton.MouseLeave += new System.EventHandler(this.pbxAddButton_MouseLeave);
            this.pbxCancelButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbxAddButton_MouseUp);
            // 
            // pbxSaveButton
            // 
            this.pbxSaveButton.Enabled = false;
            this.pbxSaveButton.Image = global::SQLStartingProject.Properties.Resources.SaveButtonDisabled;
            this.pbxSaveButton.Location = new System.Drawing.Point(21, 75);
            this.pbxSaveButton.Name = "pbxSaveButton";
            this.pbxSaveButton.Size = new System.Drawing.Size(35, 35);
            this.pbxSaveButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxSaveButton.TabIndex = 24;
            this.pbxSaveButton.TabStop = false;
            this.pbxSaveButton.Tag = "3";
            this.pbxSaveButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbxAddButton_MouseDown);
            this.pbxSaveButton.MouseEnter += new System.EventHandler(this.pbxAddButton_MouseEnter);
            this.pbxSaveButton.MouseLeave += new System.EventHandler(this.pbxAddButton_MouseLeave);
            this.pbxSaveButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbxAddButton_MouseUp);
            // 
            // pbxEditButton
            // 
            this.pbxEditButton.Image = global::SQLStartingProject.Properties.Resources.EditButton;
            this.pbxEditButton.Location = new System.Drawing.Point(62, 34);
            this.pbxEditButton.Name = "pbxEditButton";
            this.pbxEditButton.Size = new System.Drawing.Size(35, 35);
            this.pbxEditButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxEditButton.TabIndex = 23;
            this.pbxEditButton.TabStop = false;
            this.pbxEditButton.Tag = "2";
            this.pbxEditButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbxAddButton_MouseDown);
            this.pbxEditButton.MouseEnter += new System.EventHandler(this.pbxAddButton_MouseEnter);
            this.pbxEditButton.MouseLeave += new System.EventHandler(this.pbxAddButton_MouseLeave);
            this.pbxEditButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbxAddButton_MouseUp);
            // 
            // pbxAddButton
            // 
            this.pbxAddButton.Image = global::SQLStartingProject.Properties.Resources.AddButton;
            this.pbxAddButton.Location = new System.Drawing.Point(21, 34);
            this.pbxAddButton.Name = "pbxAddButton";
            this.pbxAddButton.Size = new System.Drawing.Size(35, 35);
            this.pbxAddButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxAddButton.TabIndex = 22;
            this.pbxAddButton.TabStop = false;
            this.pbxAddButton.Tag = "1";
            this.pbxAddButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbxAddButton_MouseDown);
            this.pbxAddButton.MouseEnter += new System.EventHandler(this.pbxAddButton_MouseEnter);
            this.pbxAddButton.MouseLeave += new System.EventHandler(this.pbxAddButton_MouseLeave);
            this.pbxAddButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbxAddButton_MouseUp);
            // 
            // lblSubjectName
            // 
            this.lblSubjectName.AutoSize = true;
            this.lblSubjectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubjectName.Location = new System.Drawing.Point(37, 70);
            this.lblSubjectName.Name = "lblSubjectName";
            this.lblSubjectName.Size = new System.Drawing.Size(96, 17);
            this.lblSubjectName.TabIndex = 15;
            this.lblSubjectName.Text = "Subject Name";
            // 
            // txtSubjectName
            // 
            this.txtSubjectName.Enabled = false;
            this.txtSubjectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubjectName.Location = new System.Drawing.Point(40, 90);
            this.txtSubjectName.Name = "txtSubjectName";
            this.txtSubjectName.Size = new System.Drawing.Size(645, 30);
            this.txtSubjectName.TabIndex = 1;
            // 
            // chkHasExam
            // 
            this.chkHasExam.AutoSize = true;
            this.chkHasExam.Enabled = false;
            this.chkHasExam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHasExam.Location = new System.Drawing.Point(691, 99);
            this.chkHasExam.Name = "chkHasExam";
            this.chkHasExam.Size = new System.Drawing.Size(90, 21);
            this.chkHasExam.TabIndex = 26;
            this.chkHasExam.Text = "Has Exam";
            this.chkHasExam.UseVisualStyleBackColor = true;
            // 
            // lblSubjectsTitle
            // 
            this.lblSubjectsTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubjectsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubjectsTitle.Location = new System.Drawing.Point(12, 9);
            this.lblSubjectsTitle.Name = "lblSubjectsTitle";
            this.lblSubjectsTitle.Size = new System.Drawing.Size(924, 31);
            this.lblSubjectsTitle.TabIndex = 27;
            this.lblSubjectsTitle.Text = "Subjects";
            this.lblSubjectsTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblAddEdit);
            this.panel1.Controls.Add(this.pbxAddButton);
            this.panel1.Controls.Add(this.pbxEditButton);
            this.panel1.Controls.Add(this.pbxSaveButton);
            this.panel1.Controls.Add(this.pbxCancelButton);
            this.panel1.Location = new System.Drawing.Point(787, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(120, 123);
            this.panel1.TabIndex = 28;
            // 
            // lblAddEdit
            // 
            this.lblAddEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddEdit.Location = new System.Drawing.Point(-1, 14);
            this.lblAddEdit.Name = "lblAddEdit";
            this.lblAddEdit.Size = new System.Drawing.Size(120, 17);
            this.lblAddEdit.TabIndex = 26;
            this.lblAddEdit.Text = "Add/Edit";
            this.lblAddEdit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // SubjectsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 512);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblSubjectsTitle);
            this.Controls.Add(this.chkHasExam);
            this.Controls.Add(this.lblSubjectName);
            this.Controls.Add(this.txtSubjectName);
            this.Controls.Add(this.gvSubjects);
            this.Name = "SubjectsForm";
            this.Text = "SubjectsForm";
            this.Load += new System.EventHandler(this.SubjectsForm_Load);
            this.Shown += new System.EventHandler(this.SubjectsForm_Shown);
            this.Leave += new System.EventHandler(this.SubjectsForm_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.gvSubjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCancelButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSaveButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxEditButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAddButton)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.DataGridView gvSubjects;
		private System.Windows.Forms.PictureBox pbxCancelButton;
		private System.Windows.Forms.PictureBox pbxSaveButton;
		private System.Windows.Forms.PictureBox pbxEditButton;
		private System.Windows.Forms.PictureBox pbxAddButton;
		private System.Windows.Forms.Label lblSubjectName;
		private System.Windows.Forms.TextBox txtSubjectName;
		private System.Windows.Forms.CheckBox chkHasExam;
		private System.Windows.Forms.Label lblSubjectsTitle;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblAddEdit;
	}
}