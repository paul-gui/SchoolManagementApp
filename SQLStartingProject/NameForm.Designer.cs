
namespace SQLStartingProject
{
	partial class NameForm
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
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtCNP = new System.Windows.Forms.TextBox();
            this.lblCNP = new System.Windows.Forms.Label();
            this.cbxSex = new System.Windows.Forms.ComboBox();
            this.lblSex = new System.Windows.Forms.Label();
            this.gvStudents = new System.Windows.Forms.DataGridView();
            this.lblStudentsTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAddEdit = new System.Windows.Forms.Label();
            this.pbxAddButton = new System.Windows.Forms.PictureBox();
            this.pbxEditButton = new System.Windows.Forms.PictureBox();
            this.pbxSaveButton = new System.Windows.Forms.PictureBox();
            this.pbxCancelButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvStudents)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAddButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxEditButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSaveButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCancelButton)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLastName
            // 
            this.txtLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.Location = new System.Drawing.Point(491, 90);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(230, 30);
            this.txtLastName.TabIndex = 3;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.Location = new System.Drawing.Point(260, 90);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(225, 30);
            this.txtFirstName.TabIndex = 2;
            // 
            // lblLastName
            // 
            this.lblLastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastName.Location = new System.Drawing.Point(488, 70);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(76, 17);
            this.lblLastName.TabIndex = 2;
            this.lblLastName.Text = "Last Name";
            // 
            // lblFirstName
            // 
            this.lblFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstName.Location = new System.Drawing.Point(273, 70);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(76, 17);
            this.lblFirstName.TabIndex = 3;
            this.lblFirstName.Text = "First Name";
            // 
            // txtCNP
            // 
            this.txtCNP.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCNP.Location = new System.Drawing.Point(40, 90);
            this.txtCNP.MaxLength = 13;
            this.txtCNP.Name = "txtCNP";
            this.txtCNP.Size = new System.Drawing.Size(214, 30);
            this.txtCNP.TabIndex = 1;
            this.txtCNP.TextChanged += new System.EventHandler(this.txtCNP_TextChanged);
            // 
            // lblCNP
            // 
            this.lblCNP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCNP.AutoSize = true;
            this.lblCNP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCNP.Location = new System.Drawing.Point(37, 68);
            this.lblCNP.Name = "lblCNP";
            this.lblCNP.Size = new System.Drawing.Size(36, 17);
            this.lblCNP.TabIndex = 8;
            this.lblCNP.Text = "CNP";
            // 
            // cbxSex
            // 
            this.cbxSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSex.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSex.FormattingEnabled = true;
            this.cbxSex.Items.AddRange(new object[] {
            "M",
            "F"});
            this.cbxSex.Location = new System.Drawing.Point(727, 88);
            this.cbxSex.Name = "cbxSex";
            this.cbxSex.Size = new System.Drawing.Size(54, 32);
            this.cbxSex.TabIndex = 4;
            // 
            // lblSex
            // 
            this.lblSex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSex.AutoSize = true;
            this.lblSex.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSex.Location = new System.Drawing.Point(724, 68);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(31, 17);
            this.lblSex.TabIndex = 10;
            this.lblSex.Text = "Sex";
            // 
            // gvStudents
            // 
            this.gvStudents.AllowUserToAddRows = false;
            this.gvStudents.AllowUserToDeleteRows = false;
            this.gvStudents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvStudents.Location = new System.Drawing.Point(40, 163);
            this.gvStudents.MultiSelect = false;
            this.gvStudents.Name = "gvStudents";
            this.gvStudents.ReadOnly = true;
            this.gvStudents.RowHeadersVisible = false;
            this.gvStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvStudents.Size = new System.Drawing.Size(867, 309);
            this.gvStudents.TabIndex = 13;
            this.gvStudents.TabStop = false;
            this.gvStudents.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvStudents_CellClick);
            this.gvStudents.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gvStudents_MouseClick);
            // 
            // lblStudentsTitle
            // 
            this.lblStudentsTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStudentsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudentsTitle.Location = new System.Drawing.Point(12, 9);
            this.lblStudentsTitle.Name = "lblStudentsTitle";
            this.lblStudentsTitle.Size = new System.Drawing.Size(924, 31);
            this.lblStudentsTitle.TabIndex = 23;
            this.lblStudentsTitle.Text = "Students";
            this.lblStudentsTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.panel1.TabIndex = 24;
            // 
            // lblAddEdit
            // 
            this.lblAddEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddEdit.Location = new System.Drawing.Point(-1, 9);
            this.lblAddEdit.Name = "lblAddEdit";
            this.lblAddEdit.Size = new System.Drawing.Size(120, 17);
            this.lblAddEdit.TabIndex = 18;
            this.lblAddEdit.Text = "Add/Edit";
            this.lblAddEdit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pbxAddButton
            // 
            this.pbxAddButton.Image = global::SQLStartingProject.Properties.Resources.AddButton;
            this.pbxAddButton.Location = new System.Drawing.Point(21, 35);
            this.pbxAddButton.Name = "pbxAddButton";
            this.pbxAddButton.Size = new System.Drawing.Size(35, 35);
            this.pbxAddButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxAddButton.TabIndex = 14;
            this.pbxAddButton.TabStop = false;
            this.pbxAddButton.Tag = "1";
            this.pbxAddButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_MouseDown);
            this.pbxAddButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.pbxAddButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            this.pbxAddButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_MouseUp);
            // 
            // pbxEditButton
            // 
            this.pbxEditButton.Image = global::SQLStartingProject.Properties.Resources.EditButton;
            this.pbxEditButton.Location = new System.Drawing.Point(62, 35);
            this.pbxEditButton.Name = "pbxEditButton";
            this.pbxEditButton.Size = new System.Drawing.Size(35, 35);
            this.pbxEditButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxEditButton.TabIndex = 15;
            this.pbxEditButton.TabStop = false;
            this.pbxEditButton.Tag = "2";
            this.pbxEditButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_MouseDown);
            this.pbxEditButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.pbxEditButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            this.pbxEditButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_MouseUp);
            // 
            // pbxSaveButton
            // 
            this.pbxSaveButton.Enabled = false;
            this.pbxSaveButton.Image = global::SQLStartingProject.Properties.Resources.SaveButtonDisabled;
            this.pbxSaveButton.Location = new System.Drawing.Point(21, 76);
            this.pbxSaveButton.Name = "pbxSaveButton";
            this.pbxSaveButton.Size = new System.Drawing.Size(35, 35);
            this.pbxSaveButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxSaveButton.TabIndex = 16;
            this.pbxSaveButton.TabStop = false;
            this.pbxSaveButton.Tag = "3";
            this.pbxSaveButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_MouseDown);
            this.pbxSaveButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.pbxSaveButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            this.pbxSaveButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_MouseUp);
            // 
            // pbxCancelButton
            // 
            this.pbxCancelButton.Enabled = false;
            this.pbxCancelButton.Image = global::SQLStartingProject.Properties.Resources.CancelButtonDisabled;
            this.pbxCancelButton.Location = new System.Drawing.Point(62, 76);
            this.pbxCancelButton.Name = "pbxCancelButton";
            this.pbxCancelButton.Size = new System.Drawing.Size(35, 35);
            this.pbxCancelButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxCancelButton.TabIndex = 17;
            this.pbxCancelButton.TabStop = false;
            this.pbxCancelButton.Tag = "4";
            this.pbxCancelButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_MouseDown);
            this.pbxCancelButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.pbxCancelButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            this.pbxCancelButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_MouseUp);
            // 
            // NameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 512);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblStudentsTitle);
            this.Controls.Add(this.txtCNP);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.lblCNP);
            this.Controls.Add(this.lblSex);
            this.Controls.Add(this.gvStudents);
            this.Controls.Add(this.cbxSex);
            this.Name = "NameForm";
            this.Text = "NameForm";
            this.Load += new System.EventHandler(this.NameForm_Load);
            this.Shown += new System.EventHandler(this.NameForm_Shown);
            this.Leave += new System.EventHandler(this.NameForm_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.gvStudents)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxAddButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxEditButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSaveButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCancelButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtLastName;
		private System.Windows.Forms.TextBox txtFirstName;
		private System.Windows.Forms.Label lblLastName;
		private System.Windows.Forms.Label lblFirstName;
		private System.Windows.Forms.TextBox txtCNP;
		private System.Windows.Forms.Label lblCNP;
		private System.Windows.Forms.ComboBox cbxSex;
		private System.Windows.Forms.Label lblSex;
		private System.Windows.Forms.DataGridView gvStudents;
		private System.Windows.Forms.PictureBox pbxAddButton;
		private System.Windows.Forms.PictureBox pbxEditButton;
		private System.Windows.Forms.PictureBox pbxSaveButton;
		private System.Windows.Forms.PictureBox pbxCancelButton;
		private System.Windows.Forms.Label lblStudentsTitle;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblAddEdit;
    }
}