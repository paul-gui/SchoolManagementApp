using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using SQLStartingProject.Resx;
using System.Threading;
using System.Globalization;

namespace SQLStartingProject
{
	public partial class SubjectsForm : Form
	{
		string sql;

		private readonly Bitmap AddButtonImage = new Bitmap(Properties.Resources.AddButton);
		private readonly Bitmap AddButtonHoverImage = new Bitmap(Properties.Resources.AddButtonHover);
		private readonly Bitmap AddButtonClickImage = new Bitmap(Properties.Resources.AddButtonClick);
		private readonly Bitmap AddButtonDisabledImage = new Bitmap(Properties.Resources.AddButtonDisabled);
		private readonly Bitmap EditButtonImage = new Bitmap(Properties.Resources.EditButton);
		private readonly Bitmap EditButtonHoverImage = new Bitmap(Properties.Resources.EditButtonHover);
		private readonly Bitmap EditButtonClickImage = new Bitmap(Properties.Resources.EditButtonClick);
		private readonly Bitmap EditButtonDisabledImage = new Bitmap(Properties.Resources.EditButtonDisabled);
		private readonly Bitmap SaveButtonImage = new Bitmap(Properties.Resources.SaveButton);
		private readonly Bitmap SaveButtonHoverImage = new Bitmap(Properties.Resources.SaveButtonHover);
		private readonly Bitmap SaveButtonClickImage = new Bitmap(Properties.Resources.SaveButtonClick);
		private readonly Bitmap SaveButtonDisabledImage = new Bitmap(Properties.Resources.SaveButtonDisabled);
		private readonly Bitmap CancelButtonImage = new Bitmap(Properties.Resources.CancelButton);
		private readonly Bitmap CancelButtonHoverImage = new Bitmap(Properties.Resources.CancelButtonHover);
		private readonly Bitmap CancelButtonClickImage = new Bitmap(Properties.Resources.CancelButtonClick);
		private readonly Bitmap CancelButtonDisabledImage = new Bitmap(Properties.Resources.CancelButtonDisabled);

		bool AddButtonPressed;

		public SubjectsForm()
		{
			InitializeComponent();
		}

		private void SubjectsForm_Load(object sender, EventArgs e)
		{
			lblSubjectsTitle.Text = Global.Subjects;
			lblSubjectName.Text = Global.SubjectName;
			chkHasExam.Text = Global.HasExam;
			lblAddEdit.Text = Global.AddEdit;
		}

		private void SubjectsForm_Shown(object sender, EventArgs e)
		{
			try
			{
				UpdateDataGridView();
				GridToTextBox();
			}
			catch (Exception ex)
            {
				Logger.LogError(ex);
				MessageBox.Show("E201: " + Global.ExceptionMessage);
            }
		}

		private void SubjectsForm_Leave(object sender, EventArgs e)
		{
			try
			{
				DbConn.sqlConnection.Close();
			}
			catch (Exception ex)
            {
				Logger.LogError(ex);
				MessageBox.Show("E202: " + Global.ExceptionMessage);
			}
		}

		private void gvStudents_MouseClick(object sender, MouseEventArgs e)
		{
			try
			{
				GridToTextBox();
			}
			catch (Exception ex)
            {
				Logger.LogError(ex);
				MessageBox.Show("E203: " + Global.ExceptionMessage);
			}
		}

		private void gvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (e.RowIndex == gvSubjects.NewRowIndex || e.RowIndex < 0)
				{
					return;
				}
				if (gvSubjects.Columns[e.ColumnIndex].Name == Global.Deletion)
				{
					if (MessageBox.Show(DbConn.RoleID == 1 ? Global.AdminDeletionQuestionSubjects : Global.DeletionQuestionSubjects, Global.Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						if(DbConn.RoleID != 1)
                        {
							sql = "exec Soft_Delete_Subject_Entries @0";
						}
						else
                        {
							sql = "exec Delete_Subject_Entries @0";

						}
						List<object> parameters = new List<object>
						{
							gvSubjects.CurrentRow.Cells[0].Value
						};
						DbConn.UpdateData(sql, 1, parameters);

						UpdateDataGridView();
						gvSubjects.Rows[gvSubjects.CurrentRow.Index].Selected = true;
						GridToTextBox();
					}
				}
				if (gvSubjects.Columns[e.ColumnIndex].Name == Global.Restoration && gvSubjects.Rows[e.RowIndex].Cells[e.ColumnIndex].GetType() != typeof(DataGridViewTextBoxCell))
				{
					if (MessageBox.Show(Global.RestorationQuestion, Global.Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						sql = "exec Restore_Subject_Entries @0";
						List<object> parameters = new List<object>
						{
							gvSubjects.CurrentRow.Cells[0].Value
						};
						DbConn.UpdateData(sql, 1, parameters);
						UpdateDataGridView();
						gvSubjects.Rows[gvSubjects.CurrentRow.Index].Selected = true;
						GridToTextBox();
					}
				}
			}
			catch (Exception ex)
            {
				Logger.LogError(ex);
				MessageBox.Show("E204: " + Global.ExceptionMessage);
			}
		}

		private void pbxAddButton_MouseEnter(object sender, EventArgs e)
		{
			try
			{
				switch (Convert.ToInt32((sender as PictureBox).Tag))
				{
					case 1:
						pbxAddButton.Image = AddButtonHoverImage;
						break;
					case 2:
						pbxEditButton.Image = EditButtonHoverImage;
						break;
					case 3:
						pbxSaveButton.Image = SaveButtonHoverImage;
						break;
					case 4:
						pbxCancelButton.Image = CancelButtonHoverImage;
						break;
				}
			}
			catch (Exception ex)
            {
				Logger.LogWarn(ex);
				MessageBox.Show("E205: " + Global.ExceptionMessage);
			}
		}

		private void pbxAddButton_MouseLeave(object sender, EventArgs e)
		{
			try
			{
				switch (Convert.ToInt32((sender as PictureBox).Tag))
				{
					case 1:
						pbxAddButton.Image = AddButtonImage;
						break;
					case 2:
						pbxEditButton.Image = EditButtonImage;
						break;
					case 3:
						pbxSaveButton.Image = SaveButtonImage;
						break;
					case 4:
						pbxCancelButton.Image = CancelButtonImage;
						break;
				}
				if (!pbxAddButton.Enabled)
				{
					pbxAddButton.Image = AddButtonDisabledImage;
				}
				if (!pbxEditButton.Enabled)
				{
					pbxEditButton.Image = EditButtonDisabledImage;
				}
				if (!pbxSaveButton.Enabled)
				{
					pbxSaveButton.Image = SaveButtonDisabledImage;
				}
				if (!pbxCancelButton.Enabled)
				{
					pbxCancelButton.Image = CancelButtonDisabledImage;
				}
			}
			catch (Exception ex)
            {
				Logger.LogWarn(ex);
				MessageBox.Show("E206: " + Global.ExceptionMessage);
			}
		}

		private void pbxAddButton_MouseDown(object sender, MouseEventArgs e)
		{
			try
			{
				switch (Convert.ToInt32((sender as PictureBox).Tag))
				{
					case 1:
						pbxAddButton.Image = AddButtonClickImage;
						break;
					case 2:
						pbxEditButton.Image = EditButtonClickImage;
						break;
					case 3:
						pbxSaveButton.Image = SaveButtonClickImage;
						break;
					case 4:
						pbxCancelButton.Image = CancelButtonClickImage;
						break;
				}
			}
			catch (Exception ex)
            {
				Logger.LogWarn(ex);
				MessageBox.Show("E207: " + Global.ExceptionMessage);
			}
		}

		private void pbxAddButton_MouseUp(object sender, MouseEventArgs e)
		{
			try
			{
				switch (Convert.ToInt32((sender as PictureBox).Tag))
				{
					case 1:
						#region Add Button Operations
						txtSubjectName.Text = "";

						txtSubjectName.Enabled = true;

						gvSubjects.Enabled = false;

						gvSubjects.ClearSelection();
						pbxEditButton.Image = EditButtonDisabledImage;
						pbxEditButton.Enabled = false;
						pbxSaveButton.Image = SaveButtonImage;
						pbxSaveButton.Enabled = true;
						pbxCancelButton.Image = CancelButtonImage;
						pbxCancelButton.Enabled = true;
						pbxAddButton.Image = AddButtonDisabledImage;
						pbxAddButton.Enabled = false;

						chkHasExam.Checked = false;
						chkHasExam.Enabled = true;

						AddButtonPressed = true;
						break;
					#endregion
					case 2:
						#region Edit Button Operations
						gvSubjects.Enabled = false;

						txtSubjectName.Enabled = true;

						pbxEditButton.Image = EditButtonDisabledImage;
						pbxEditButton.Enabled = false;
						pbxSaveButton.Image = SaveButtonImage;
						pbxSaveButton.Enabled = true;
						pbxCancelButton.Image = CancelButtonImage;
						pbxCancelButton.Enabled = true;
						pbxAddButton.Image = AddButtonDisabledImage;
						pbxAddButton.Enabled = false;
						chkHasExam.Enabled = true;

						AddButtonPressed = false;
						break;
					#endregion
					case 3:
						#region Save Button Operations
						try
						{
							if (!string.IsNullOrEmpty(txtSubjectName.Text))
							{
								if (AddButtonPressed) //Save operations for the Add Button
								{
									sql = "INSERT INTO Subjects (Name, Created, Modified, HasExam) OUTPUT inserted.ID VALUES (@0, GETDATE(), GETDATE(), @1)";
									List<object> parameters = new List<object>
										{
											txtSubjectName.Text,
											chkHasExam.Checked ? "true" : "false"
										};
									var id = DbConn.InsertData(sql, 2, parameters);
									sql = "exec Update_Data";
									DbConn.ExecuteStoredProcedure(sql);
									MessageBox.Show(Global.SubjectAddedStatement + id);

								}
								else //Save operations for the Edit Button
								{
									if (CheckIfSubjectHasExams() && !chkHasExam.Checked)
									{
										MessageBox.Show(Global.UncheckHasExamStatement);
										return;
									}
									else
									{
										sql = @"UPDATE Subjects SET Name = @0, HasExam = @1, Modified = GETDATE() WHERE
												ID = @2";
										List<object> parameters = new List<object>
											{
												txtSubjectName.Text,
												chkHasExam.Checked ? "true" : "false",
												gvSubjects.CurrentRow.Cells[0].Value
											};
										DbConn.UpdateData(sql, 3, parameters);
										MessageBox.Show(Global.RowEditStatement);
									}
								}

								//Enable and disable controls
								pbxEditButton.Image = EditButtonImage;
								pbxEditButton.Enabled = true;
								pbxAddButton.Image = AddButtonImage;
								pbxAddButton.Enabled = true;
								pbxCancelButton.Image = CancelButtonDisabledImage;
								pbxCancelButton.Enabled = false;
								pbxSaveButton.Image = SaveButtonDisabledImage;
								pbxSaveButton.Enabled = false;
								chkHasExam.Enabled = false;

								gvSubjects.Enabled = true;

								txtSubjectName.Enabled = false;


								//Update table
								UpdateDataGridView();
								gvSubjects.Rows[gvSubjects.CurrentRow.Index].Selected = true;
								GridToTextBox();
							}
							else
							{
								MessageBox.Show(Global.AllFieldsStatement);
							}
						}
						catch (SqlException ex)
						{
							Logger.LogError(ex);
							MessageBox.Show("E208: " + Global.ExceptionMessage);
						}
						catch (Exception ex)
						{
							Logger.LogError(ex);
							MessageBox.Show("E208: " + Global.ExceptionMessage);
						}
						break;
					#endregion
					case 4:
						#region Cancel Button Operations

						//Enable and disable controls
						pbxEditButton.Image = EditButtonImage;
						pbxEditButton.Enabled = true;
						pbxAddButton.Image = AddButtonImage;
						pbxAddButton.Enabled = true;
						pbxCancelButton.Image = CancelButtonDisabledImage;
						pbxCancelButton.Enabled = false;
						pbxSaveButton.Image = SaveButtonDisabledImage;
						pbxSaveButton.Enabled = false;
						chkHasExam.Enabled = false;
						//Solve border bug
						var bdstl = txtSubjectName.BorderStyle;
						txtSubjectName.BorderStyle = BorderStyle.None;
						txtSubjectName.Enabled = false;
						txtSubjectName.BorderStyle = bdstl;
						//ReEnable gridview
						gvSubjects.Enabled = true;
						gvSubjects.Rows[gvSubjects.CurrentRow.Index].Selected = true;

						GridToTextBox();
						break;
						#endregion
				}
			}
			catch (Exception ex)
            {
				Logger.LogError(ex);
				MessageBox.Show("E209: " + Global.ExceptionMessage);
			}
        }

		void UpdateDataGridView()
        {
			try
			{
				if(DbConn.RoleID != 1)
                {
					sql = "select * from SubjectsTableViewFunction()";
				}
				else
                {
					sql = "select * from Admin_SubjectTableViewFunction()";
                }
				if(gvSubjects.Columns.Contains(Global.Deletion))
                {
					gvSubjects.Columns.Remove(Global.Deletion);
				}
				if(DbConn.RoleID == 1)
                {
					if(gvSubjects.Columns.Contains(Global.Restoration))
                    {
						gvSubjects.Columns.Remove(Global.Restoration);
					}
                }
				gvSubjects.DataSource = DbConn.GetData(sql);
				gvSubjects.Columns[1].HeaderText = Global.Subject;
				gvSubjects.Columns[2].HeaderText = Global.HasExam;
				DataGridViewButtonColumn col = new DataGridViewButtonColumn
				{
					UseColumnTextForButtonValue = true,
					Text = Global.Delete,
					Name = Global.Deletion,
					SortMode = DataGridViewColumnSortMode.NotSortable,
				};
				if(DbConn.RoleID == 1)
                {
					col.DefaultCellStyle.BackColor = Color.Red;
                }
				gvSubjects.Columns.Insert(3, col);

				if (DbConn.RoleID == 1)
				{
					gvSubjects.Columns[4].Visible = false;
					DataGridViewButtonColumn restoreColumn = new DataGridViewButtonColumn
					{
						UseColumnTextForButtonValue = true,
						Text = Global.Restore,
						Name = Global.Restoration,
						SortMode = DataGridViewColumnSortMode.NotSortable,
					};
					gvSubjects.Columns.Insert(4, restoreColumn);
					ColumnFormatting();
				}

				gvSubjects.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
				gvSubjects.Columns[2].Width = 80;
				gvSubjects.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
				gvSubjects.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				gvSubjects.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
				gvSubjects.Columns[3].Width = 80;
				gvSubjects.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
				if(DbConn.RoleID == 1)
                {
					gvSubjects.Columns[4].Width = 80;
					gvSubjects.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
				}
			}
			catch (Exception ex)
            {
				Logger.LogError(ex);
				MessageBox.Show("E210: " + Global.ExceptionMessage);
			}
		}

		private void GridToTextBox()
		{
			try
			{
				//cmd = new SqlCommand
				//{
				//	CommandType = CommandType.Text,
				//	CommandText = $"SELECT Name, HasExam FROM Subjects WHERE ID = {gvSubjects.CurrentRow.Cells[0].Value}"

				//};
				//cmd.Connection = sqlConnection;
				//var rdr = cmd.ExecuteReader();
				sql = $"SELECT Name, HasExam FROM Subjects WHERE ID = @0";
				List<object> parameters = new List<object>();
				parameters.Add(gvSubjects.CurrentRow.Cells[0].Value);
				DataTable dt = DbConn.GetData(sql, 1, parameters);
				DataRow dr = dt.Rows[0];

				txtSubjectName.Text = dr.Field<string>("Name");
				chkHasExam.Checked = dr.Field<bool?>("HasExam") ?? false;

				//rdr.Close();
			}
			catch (Exception ex)
            {
				Logger.LogError(ex);
				MessageBox.Show("E211: " + Global.ExceptionMessage);
			}
		}

		bool CheckIfSubjectHasExams()
		{
			try
			{
				sql = "select IsExam from Grades where AverageID in (select ID from Averages where SubjectID = @0) and IsExam = 1";
				List<object> parameters = new List<object>
				{
					gvSubjects.CurrentRow.Cells[0].Value,
				};
				DataTable dt = DbConn.GetData(sql, 1, parameters);
				if (dt.Rows.Count > 0)
				{
					return true;
				}
				return false;
			}
			catch
			{
				throw;
			}
		}

		private void InsertIntoAverages()
		{
			sql = @"select ID from Students where Active = 1";
			DataTable dt1 = DbConn.GetData(sql);
			sql = @"select ID from Subjects where Active = 1";
			DataTable dt2 = DbConn.GetData(sql);
			for (int i = 0; i < dt1.Rows.Count; i++)
			{
				for (int j = 0; j < dt2.Rows.Count; j++)
				{
					sql = @"if not exists (select * from Averages where StudentID = @0 and SubjectID = @1)
									insert into Averages(StudentID, SubjectID, Created, Modified) values(@0, @1, GETDATE(), GETDATE())";
					List<object> parameters = new List<object>
											{
												dt1.Rows[i][0],
												dt2.Rows[j][0],
											};
					DbConn.InsertAverageData(sql, 2, parameters);
				}
			}
		}

		private void ColumnFormatting()
		{
			if (DbConn.RoleID == 1)
			{
				foreach (DataGridViewRow row in gvSubjects.Rows)
				{
					if ((bool)row.Cells[5].Value)
					{
						DataGridViewTextBoxCell boxCell = new DataGridViewTextBoxCell();
						row.Cells[4] = boxCell;
						row.Cells[4].ReadOnly = true;

					}
					else
					{
						row.Cells[4].Style.BackColor = Color.LightGray;
					}
				}
			}
		}
	}
}