using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Threading;
using System.Globalization;
using SQLStartingProject.Resx;
using System.Net;

namespace SQLStartingProject
{
	public partial class NameForm : Form
	{
		string sql;

		private DataTable dt = new DataTable();
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

		public NameForm()
		{
			InitializeComponent();
		}

		private void NameForm_Load(object sender, EventArgs e)
		{
			lblStudentsTitle.Text = Global.Students;
			lblLastName.Text = Global.LastName;
			lblFirstName.Text = Global.FirstName;
			lblCNP.Text = Global.CNP;
			lblSex.Text = Global.Sex;
			lblAddEdit.Text = Global.AddEdit;
		}

		private void NameForm_Shown(object sender, EventArgs e)
		{
			try
			{
				UpdateDataGridView();
				GridToTextBox();
			}
			catch (Exception ex)
			{
				Logger.LogError(ex);
				MessageBox.Show("E100: " + Global.ExceptionMessage);
			}
		}

		private void NameForm_Leave(object sender, EventArgs e)
		{
			try
			{
				DbConn.sqlConnection.Close();
			}
			catch(Exception ex)
            {
				Logger.LogWarn(ex);
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
				MessageBox.Show("E101: " + Global.ExceptionMessage);
				Logger.LogError(ex);
            }
		}

		private void gvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (e.RowIndex == gvStudents.NewRowIndex || e.RowIndex < 0)
				{
					return;
				}
				if (gvStudents.Columns[e.ColumnIndex].Name == Global.Deletion)
				{
					if (MessageBox.Show(DbConn.RoleID == 1 ? Global.AdminDeletionQuestionStudents : Global.DeletionQuestionStudents, Global.Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						if (DbConn.RoleID != 1)
						{
							sql = "exec Soft_Delete_Student_Entries @0";
							List<object> parameters = new List<object>
							{
								gvStudents.CurrentRow.Cells[0].Value
							};
							DbConn.UpdateData(sql, 1, parameters);
						}
						else
                        {
							sql = "exec Delete_Student_Entries @0";
							List<object> parameters = new List<object>
							{
								gvStudents.CurrentRow.Cells[0].Value
							};
							DbConn.UpdateData(sql, 1, parameters);
						}
						UpdateDataGridView();
						gvStudents.Rows[gvStudents.CurrentRow.Index].Selected = true;
						GridToTextBox();
					}
				}
				if(gvStudents.Columns[e.ColumnIndex].Name == Global.Restoration && gvStudents.Rows[e.RowIndex].Cells[e.ColumnIndex].GetType() != typeof(DataGridViewTextBoxCell))
                {
					if(MessageBox.Show(Global.RestorationQuestion, Global.Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
						sql = "exec Restore_Student_Entries @0";
						List<object> parameters = new List<object>
						{
							gvStudents.CurrentRow.Cells[0].Value
						};
						DbConn.UpdateData(sql, 1, parameters);
						UpdateDataGridView();
						gvStudents.Rows[gvStudents.CurrentRow.Index].Selected = true;
						GridToTextBox();
					}
                }
			}
			catch (Exception ex)
            {
				Logger.LogError(ex);
				MessageBox.Show("E102: " + Global.ExceptionMessage);
            }
		}

		private void txtCNP_TextChanged(object sender, EventArgs e)
		{
			try
			{
				if (System.Text.RegularExpressions.Regex.IsMatch(txtCNP.Text, "[^0-9]"))
				{
					MessageBox.Show(Global.CNPErrorStatement);
					txtCNP.Text = txtCNP.Text.Remove(txtCNP.Text.Length - 1);
				}
			}
			catch (Exception ex)
            {
				Logger.LogError(ex);
				MessageBox.Show("E103: " + Global.ExceptionMessage);
			}
		}

		private void Button_MouseEnter(object sender, EventArgs e)
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
				MessageBox.Show("E103: " + Global.ExceptionMessage);
			}
		}

		private void Button_MouseLeave(object sender, EventArgs e)
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
				MessageBox.Show("E104: " + Global.ExceptionMessage);
				Logger.LogWarn(ex);
			}
		}

		private void Button_MouseDown(object sender, MouseEventArgs e)
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
				MessageBox.Show("E105: " + Global.ExceptionMessage);
			}
		}

		private void Button_MouseUp(object sender, MouseEventArgs e)
		{
			try
			{
				switch (Convert.ToInt32((sender as PictureBox).Tag))
				{
					case 1:
						#region Add Button Operations
						pbxAddButton.Image = AddButtonHoverImage;

						txtLastName.Text = "";
						txtFirstName.Text = "";
						txtCNP.Text = "";

						txtLastName.Enabled = true;
						txtFirstName.Enabled = true;
						txtCNP.Enabled = true;
						cbxSex.Enabled = true;

						gvStudents.Enabled = false;

						cbxSex.SelectedIndex = -1;
						gvStudents.ClearSelection();
						pbxEditButton.Enabled = false;
						pbxEditButton.Image = EditButtonDisabledImage;
						pbxSaveButton.Enabled = true;
						pbxSaveButton.Image = SaveButtonImage;
						pbxCancelButton.Enabled = true;
						pbxCancelButton.Image = CancelButtonImage;
						pbxAddButton.Enabled = false;
						pbxAddButton.Image = AddButtonDisabledImage;

						AddButtonPressed = true;
						break;
					#endregion

					case 2:
						#region Edit Button Operations
						pbxEditButton.Image = EditButtonHoverImage;

						gvStudents.Enabled = false;

						txtLastName.Enabled = true;
						txtFirstName.Enabled = true;
						txtCNP.Enabled = true;
						cbxSex.Enabled = true;

						pbxEditButton.Enabled = false;
						pbxEditButton.Image = EditButtonDisabledImage;
						pbxSaveButton.Enabled = true;
						pbxSaveButton.Image = SaveButtonImage;
						pbxCancelButton.Enabled = true;
						pbxCancelButton.Image = CancelButtonImage;
						pbxAddButton.Enabled = false;
						pbxAddButton.Image = AddButtonDisabledImage;

						AddButtonPressed = false;
						break;
					#endregion

					case 3:
						#region Save Button Operations
						try
						{
							pbxSaveButton.Image = SaveButtonHoverImage;
							//Check all fields
							if (!string.IsNullOrEmpty(txtLastName.Text) && !string.IsNullOrEmpty(txtFirstName.Text) && !string.IsNullOrEmpty(txtCNP.Text) && !string.IsNullOrEmpty(cbxSex.Text))
							{
								if (AddButtonPressed)
								{
									sql = "INSERT INTO Students (CNP, LastName, FirstName, Sex, Created, Modified) OUTPUT inserted.ID VALUES (@0, @1, @2, @3, GETDATE(), GETDATE())";
									List<object> parameters = new List<object>
								{
									txtCNP.Text,
									txtLastName.Text,
									txtFirstName.Text,
									cbxSex.SelectedItem
								};
									var id = DbConn.InsertData(sql, 4, parameters);
									sql = "exec Update_Data";

									MessageBox.Show(Global.StudentAddedStatement + id);
								}
								else
								{
									sql = "UPDATE Students SET CNP = @0, LastName = @1, FirstName = @2, Sex = @3, Modified = GETDATE() WHERE ID = @4";
									List<object> parameters = new List<object>();
									parameters.Add(txtCNP.Text);
									parameters.Add(txtLastName.Text);
									parameters.Add(txtFirstName.Text);
									parameters.Add(cbxSex.SelectedItem);
									parameters.Add(gvStudents.CurrentRow.Cells[0].Value);
									DbConn.UpdateData(sql, 5, parameters);
									MessageBox.Show(Global.RowEditStatement);
								}
								pbxEditButton.Enabled = true;
								pbxEditButton.Image = EditButtonImage;
								pbxAddButton.Enabled = true;
								pbxAddButton.Image = AddButtonImage;
								pbxCancelButton.Enabled = false;
								pbxCancelButton.Image = CancelButtonDisabledImage;
								pbxSaveButton.Enabled = false;
								pbxSaveButton.Image = SaveButtonDisabledImage;

								gvStudents.Enabled = true;

								var bdstl1 = txtLastName.BorderStyle;
								txtLastName.BorderStyle = BorderStyle.None;
								txtLastName.Enabled = false;
								txtLastName.BorderStyle = bdstl1;

								txtFirstName.Enabled = false;
								txtCNP.Enabled = false;
								cbxSex.Enabled = false;

								UpdateDataGridView();
								gvStudents.Rows[gvStudents.CurrentRow.Index].Selected = true;
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

							throw;
						}
						catch (Exception ex)
						{
							Logger.LogError(ex);
							throw;
						}
						break;
					#endregion

					case 4:
						#region Cancel Button Operations

						pbxCancelButton.Image = CancelButtonHoverImage;

						pbxEditButton.Enabled = true;
						pbxEditButton.Image = EditButtonImage;
						pbxSaveButton.Enabled = false;
						pbxSaveButton.Image = SaveButtonDisabledImage;
						pbxCancelButton.Enabled = false;
						pbxCancelButton.Image = CancelButtonDisabledImage;
						pbxAddButton.Enabled = true;
						pbxAddButton.Image = AddButtonImage;

						var bdstl = txtLastName.BorderStyle;
						txtLastName.BorderStyle = BorderStyle.None;
						txtLastName.Enabled = false;
						txtLastName.BorderStyle = bdstl;
						txtFirstName.Enabled = false;
						txtCNP.Enabled = false;
						cbxSex.Enabled = false;

						gvStudents.Enabled = true;

						gvStudents.Rows[gvStudents.CurrentRow.Index].Selected = true;

						GridToTextBox();
						break;
						#endregion

				}
			}
			catch (Exception ex)
            {
				Logger.LogError(ex);
				MessageBox.Show("E106: " + Global.ExceptionMessage);
			}
        }

		void UpdateDataGridView()
        {
			try
			{
				if (DbConn.RoleID != 1)
				{
					sql = "SELECT ID, CNP, FirstName, LastName, Sex FROM Students WHERE Active = 1";
				}
				else
                {
					sql = "SELECT ID, CNP, FirstName, LastName, Sex, Active FROM Students";
				}
				if(gvStudents.Columns.Contains(Global.Deletion))
                {
					gvStudents.Columns.Remove(Global.Deletion);
				}
				if(DbConn.RoleID == 1)
                {
					if(gvStudents.Columns.Contains(Global.Restoration))
                    {
						gvStudents.Columns.Remove(Global.Restoration);
					}
                }

				gvStudents.DataSource = DbConn.GetData(sql);

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

				gvStudents.Columns.Insert(5, col);

				if (DbConn.RoleID == 1)
				{
					gvStudents.Columns[6].Visible = false;

					DataGridViewButtonColumn restoreColumn = new DataGridViewButtonColumn
					{
						UseColumnTextForButtonValue = true,
						Text = Global.Restore,
						Name = Global.Restoration,
						SortMode = DataGridViewColumnSortMode.NotSortable,
					};
					gvStudents.Columns.Insert(6, restoreColumn);
					ColumnFormatting();
				}

				gvStudents.Columns[1].HeaderText = Global.CNP;
				gvStudents.Columns[2].HeaderText = Global.FirstName;
				gvStudents.Columns[3].HeaderText = Global.LastName;
				gvStudents.Columns[4].HeaderText = Global.Sex;

				gvStudents.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

				gvStudents.Columns[4].Width = 50;
				gvStudents.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
				gvStudents.Columns[5].Width = 80;
				gvStudents.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
				if (DbConn.RoleID == 1) 
				{
					gvStudents.Columns[6].Width = 80;
					gvStudents.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
				}
			}
			catch (Exception ex)
            {
				Logger.LogError(ex);
				throw ex;
			}
		}

		private void GridToTextBox()
		{
			try
			{
				sql = "SELECT LastName, FirstName, CNP, Sex FROM Students WHERE ID = @0";
				List<object> parameters = new List<object>();
				parameters.Add(gvStudents.CurrentRow.Cells[0].Value);
				DataTable dt = DbConn.GetData(sql, 1, parameters);
				DataRow dr = dt.Rows[0];
				txtLastName.Text = dr.Field<string>("LastName");
				txtFirstName.Text = dr.Field<string>("FirstName");
				txtCNP.Text = dr.Field<string>("CNP");
				if (dr.Field<string>("Sex") == "M")
				{
					cbxSex.SelectedIndex = 0;
				}
				if (dr.Field<string>("Sex") == "F")
				{
					cbxSex.SelectedIndex = 1;
				}
				cbxSex.Enabled = false;
				txtLastName.Enabled = false;
				txtFirstName.Enabled = false;
				txtCNP.Enabled = false;
			}
			catch (Exception ex)
            {
				Logger.LogError(ex);
				throw ex;
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
			try
			{
				if (DbConn.RoleID == 1)
				{
					foreach (DataGridViewRow row in gvStudents.Rows)
					{
						if ((bool)row.Cells[7].Value)
						{
							DataGridViewTextBoxCell boxCell = new DataGridViewTextBoxCell();
							row.Cells[6] = boxCell;
							row.Cells[6].ReadOnly = true;

						}
						else
						{
							row.Cells[6].Style.BackColor = Color.LightGray;
						}
					}
				}
			}
			catch (Exception ex)
            {
				throw;
            }
        }
    }
}
