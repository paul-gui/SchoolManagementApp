using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLStartingProject.Resx;
using System.Threading;
using System.Globalization;


namespace SQLStartingProject
{
	public partial class GradesForm : Form
	{
		string sql;

		private DataTable dtStudents = new DataTable();
		private DataTable dtSubjects = new DataTable();
		private DataTable dtGridView = new DataTable();
		bool AddButtonPressed = true;
		List<object> parameters;


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

		public GradesForm()
		{
			InitializeComponent();
		}

		private void GradesForm_Load(object sender, EventArgs e)
		{
			try
			{
				lblGradesTitle.Text = Global.Grades;
				lblName.Text = Global.Student;
				lblSubject.Text = Global.Subject;
				lblAddEdit.Text = Global.AddEditGrade;
				lblGradeControl.Text = Global.Grade;
				chkIsExam.Text = Global.IsExam;
				lblAverage.Text = Global.Average;
			}
			catch (Exception ex)
            {
				Logger.LogError(ex);
				MessageBox.Show("E300: " + Global.ExceptionMessage);
			}
		}

		private void GradesForm_Leave(object sender, EventArgs e)
		{
			try
			{
				DbConn.sqlConnection.Close();
			}
			catch (Exception ex)
			{
				Logger.LogWarn(ex);
				MessageBox.Show("E301: " + Global.ExceptionMessage);
			}
		}

		private void GradesForm_Shown(object sender, EventArgs e)
		{
			try
			{
				#region Populate Students combobox
				if(DbConn.RoleID == 1)
                {
					sql = "SELECT LastName + ' ' + FirstName as Name, ID FROM Students ORDER BY Name ASC";
				}
				else
                {
					sql = "SELECT LastName + ' ' + FirstName as Name, ID FROM Students WHERE Active = 1 ORDER BY Name ASC";
				}
				dtStudents = DbConn.GetData(sql);
				DataRow dr1 = dtStudents.NewRow();
				dr1["ID"] = -1;
				dr1["Name"] = Global.All;
				dtStudents.Rows.InsertAt(dr1, 0);
				cbxStudents.ValueMember = "ID";
				cbxStudents.DisplayMember = "Name";
				cbxStudents.DataSource = dtStudents;
				#endregion

				#region Populate Subjects combobox
				if(DbConn.RoleID == 1)
                {
					sql = "SELECT Name as Name, ID FROM Subjects ORDER BY Name ASC";
				}
				else
                {
					sql = "SELECT Name as Name, ID FROM Subjects WHERE Active = 1 ORDER BY Name ASC";
				}
				dtSubjects = DbConn.GetData(sql);
				DataRow dr2 = dtSubjects.NewRow();
				dr2["ID"] = -1;
				dr2["Name"] = Global.All;
				dtSubjects.Rows.InsertAt(dr2, 0);
				cbxSubjects.ValueMember = "ID";
				cbxSubjects.DisplayMember = "Name";
				cbxSubjects.DataSource = dtSubjects;
				#endregion

				cbxStudents.SelectedIndexChanged += cbx_SelectedIndexChanged;
				cbxSubjects.SelectedIndexChanged += cbx_SelectedIndexChanged;

				#region Populate GridView
				UpdateDataGridView();
				#endregion

				#region Insert all Students and Subjects into Averages table
				sql = "exec Update_Data";
				DbConn.ExecuteStoredProcedure(sql);
				#endregion
			}
			catch (Exception ex)
			{
				Logger.LogError(ex);
				MessageBox.Show("E302: " + Global.ExceptionMessage);
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
				MessageBox.Show("E303: " + Global.ExceptionMessage);
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
				Logger.LogWarn(ex);
				MessageBox.Show("E304: " + Global.ExceptionMessage);
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
				MessageBox.Show("E305: " + Global.ExceptionMessage);
			}
		}

		private void cbx_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				UpdateDataGridView();
				//If both coboboxes != ALL
				if (cbxStudents.SelectedIndex > 0 && cbxSubjects.SelectedIndex > 0)
				{
					DisplayAverage();
					gvGrades.Enabled = true;
					pbxAddButton.Enabled = true;
					pbxAddButton.Image = AddButtonImage;

					//Enable and disable buttons
					if (gvGrades.Rows.Count == 0)
					{
						pbxEditButton.Enabled = false;
						pbxEditButton.Image = EditButtonDisabledImage;
					}
					else
					{
						pbxEditButton.Enabled = true;
						pbxEditButton.Image = EditButtonImage;
						gvGrades.Rows[0].Selected = true;
					}
				}
				else if(cbxStudents.SelectedIndex > 0)
                {
					sql = "select cast(cast(avg(Average) as decimal(4, 2)) as varchar) Average from Averages where StudentID = @0";
					parameters = new List<object>
					{
						cbxStudents.SelectedValue
					};
					DataTable dt = DbConn.GetData(sql, 1, parameters);
					DataRow dr = dt.Rows[0];
					lblAverage.Text = Global.GeneralAverage;
					lblAverageValue.Text = dr.Field<string>("Average") ?? "-";
				}
				else
				{
					//Enable and disable buttons
					pbxAddButton.Enabled = false;
					pbxAddButton.Image = AddButtonDisabledImage;
					pbxEditButton.Enabled = false;
					pbxEditButton.Image = EditButtonDisabledImage;
					lblAverage.Text = Global.Average;
					lblAverageValue.Text = "-";
				}
			}
			catch (Exception ex)
			{
				Logger.LogError(ex);
				MessageBox.Show("E306: " + Global.ExceptionMessage);
			}
		}

		private void gvGrades_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (cbxGrades.Enabled)
				{
					cbxGrades.SelectedIndex = Convert.ToInt32(gvGrades.CurrentRow.Cells[3].Value);
				}
			}
			catch (Exception ex)
			{
				Logger.LogError(ex);
				MessageBox.Show("E307: " + Global.ExceptionMessage);
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

						//Enable and disable controls
						gvGrades.Enabled = false;
						pbxAddButton.Enabled = false;
						pbxAddButton.Image = AddButtonDisabledImage;
						pbxEditButton.Enabled = false;
						pbxEditButton.Image = EditButtonDisabledImage;
						pbxSaveButton.Enabled = true;
						pbxSaveButton.Image = SaveButtonImage;
						pbxCancelButton.Enabled = true;
						pbxCancelButton.Image = CancelButtonImage;
						cbxStudents.Enabled = false;
						cbxSubjects.Enabled = false;
						cbxGrades.Enabled = true;
						lblAddEdit.Enabled = true;
						lblGradeControl.Enabled = true;

						//Enable or disable IsExam checkbox
						sql = "select HasExam from Subjects where ID = @0";
						parameters = new List<object>
						{
							cbxSubjects.SelectedValue
						};
						DataTable dt = DbConn.GetData(sql, 1, parameters);
						DataRow dr = dt.Rows[0];
						chkIsExam.Enabled = dr.Field<bool?>("HasExam") ?? false;
						AddButtonPressed = true;
						break;
					#endregion
					case 2:
						#region Edit Button Operations

						//Enable and disable controls
						gvGrades.Enabled = false;
						pbxAddButton.Enabled = false;
						pbxAddButton.Image = AddButtonDisabledImage;
						pbxEditButton.Enabled = false;
						pbxEditButton.Image = EditButtonDisabledImage;
						pbxSaveButton.Enabled = true;
						pbxSaveButton.Image = SaveButtonImage;
						pbxCancelButton.Enabled = true;
						pbxCancelButton.Image = CancelButtonImage;
						cbxStudents.Enabled = false;
						cbxSubjects.Enabled = false;
						cbxGrades.Enabled = true;
						lblAddEdit.Enabled = true;
						lblGradeControl.Enabled = true;

						//Enable or disable IsExam checkbox
						sql = "select HasExam from Subjects where ID = @0";
						parameters = new List<object>
						{
							cbxSubjects.SelectedValue
						};
						dt = DbConn.GetData(sql, 1, parameters);
						dr = dt.Rows[0];
						chkIsExam.Enabled = dr.Field<bool?>("HasExam") ?? false;

						//Check or uncheck IsExam checkbox
						sql = "select IsExam from Grades where ID = @0";
						parameters = new List<object>
						{
							gvGrades.CurrentRow.Cells[0].Value
						};
						dt = DbConn.GetData(sql, 1, parameters);
						dr = dt.Rows[0];
						chkIsExam.Checked = dr.Field<bool?>("IsExam") ?? false;
						//Populate Grade combobox with value from grid
						cbxGrades.SelectedIndex = Convert.ToInt32(gvGrades.CurrentRow.Cells[3].Value);

						AddButtonPressed = false;
						break;
					#endregion
					case 3:
						#region Save Button Operations
						try
						{
							pbxSaveButton.Image = SaveButtonHoverImage;
							if ((CheckForExistingExam() || !CheckIfSubjectHasExam()) && chkIsExam.Checked)
							{
								MessageBox.Show(Global.ExamExistsStatement);
							}
							else
							{
								if (cbxGrades.SelectedIndex > 0)
								{
									if (AddButtonPressed)
									{
										//cmd = new SqlCommand
										//{
										//	CommandType = CommandType.Text,
										//	CommandText = "INSERT INTO Grades (SubjectID, StudentID, Grade, IsExam, Created, Modified)OUTPUT inserted.ID " +
										//	"VALUES (@SubjectID, @StudentID, @Grade, @IsExam, GETDATE(), GETDATE())",
										//	Connection = sqlConnection
										//};
										//cmd.Parameters.AddWithValue("@SubjectID", cbxSubjects.SelectedValue);
										//cmd.Parameters.AddWithValue("@StudentID", cbxStudents.SelectedValue);
										//cmd.Parameters.AddWithValue("@Grade", cbxGrades.Text);
										//cmd.Parameters.AddWithValue("@IsExam", chkIsExam.Checked ? 1 : 0);

										//cmd.ExecuteNonQuery();
										//sql = "INSERT INTO Grades (SubjectID, StudentID, Grade, IsExam, Created, Modified) OUTPUT inserted.ID VALUES (@0, @1, @2, @3, GETDATE(), GETDATE())";

										sql = "INSERT INTO Grades (AverageID, Grade, IsExam, Created, Modified) OUTPUT inserted.ID VALUES ((select ID from Averages where SubjectID = @0 and StudentID = @1), @2, @3, GETDATE(), GETDATE())";
										parameters = new List<object>
									{
									cbxSubjects.SelectedValue,
									cbxStudents.SelectedValue,
									cbxGrades.Text,
									chkIsExam.Checked ? 1 : 0
									};
										DbConn.InsertData(sql, 4, parameters);
										MessageBox.Show(Global.GradeAddedStatement);
									}
									else
									{
										sql = "UPDATE Grades SET Grade = @0, IsExam = @1 WHERE AverageID = (select ID from Averages where StudentID = @2 and SubjectID = @3) and ID = @4";
										parameters = new List<object>
										{
											cbxGrades.Text,
											chkIsExam.Checked ? "1" : "0",
											cbxStudents.SelectedValue,
											cbxSubjects.SelectedValue,
											gvGrades.CurrentRow.Cells[0].Value
										};
										DbConn.UpdateData(sql, 5, parameters);
										MessageBox.Show(Global.GradeEditedStatement);
									}
									UpdateDataGridView();
									//CalculateAverage();
									//DisplayAverage();
								}
								else
								{
									MessageBox.Show(Global.SelectGradeStatement);
								}

								//Update Averages table data
								sql = "exec Update_Data";
								DbConn.ExecuteStoredProcedure(sql);

								DisplayAverage();

								//Enable and disable controls
								gvGrades.Enabled = true;
								pbxSaveButton.Enabled = false;
								pbxSaveButton.Image = SaveButtonDisabledImage;
								pbxCancelButton.Enabled = false;
								pbxCancelButton.Image = CancelButtonDisabledImage;
								pbxAddButton.Enabled = true;
								pbxAddButton.Image = AddButtonImage;
								pbxEditButton.Enabled = true;
								pbxEditButton.Image = EditButtonImage;
								cbxStudents.Enabled = true;
								cbxSubjects.Enabled = true;
								cbxGrades.Enabled = false;
								chkIsExam.Enabled = false;
								lblAddEdit.Enabled = false;
								lblGradeControl.Enabled = false;
								cbxGrades.SelectedIndex = 0;
							}
						}
						catch (SqlException ex)
						{
							Logger.LogError(ex);
							MessageBox.Show("E308: " + Global.ExceptionMessage);
						}
						catch (Exception ex)
						{
							Logger.LogError(ex);
							MessageBox.Show("E308: " + Global.ExceptionMessage);
						}
						break;
					#endregion
					case 4:
						#region Cancel Button Operations
						//Enable and disable controls
						gvGrades.Enabled = true;
						pbxCancelButton.Image = CancelButtonHoverImage;
						pbxAddButton.Enabled = true;
						pbxAddButton.Image = AddButtonImage;
						pbxSaveButton.Enabled = false;
						pbxSaveButton.Image = SaveButtonImage;
						pbxCancelButton.Enabled = false;
						pbxCancelButton.Image = CancelButtonImage;
						if (gvGrades.Rows.Count == 0)
						{
							pbxEditButton.Enabled = false;
							pbxEditButton.Image = EditButtonDisabledImage;
						}
						else
						{
							pbxEditButton.Enabled = true;
							pbxEditButton.Image = EditButtonImage;
						}
						cbxStudents.Enabled = true;
						cbxSubjects.Enabled = true;
						cbxGrades.Enabled = false;
						chkIsExam.Enabled = false;
						chkIsExam.Enabled = false;
						lblAddEdit.Enabled = false;
						lblGradeControl.Enabled = false;
						cbxGrades.SelectedIndex = 0;
						chkIsExam.Checked = false;
						break;
						#endregion
				}
			}
			catch (Exception ex)
			{
				Logger.LogError(ex);
				MessageBox.Show("E309: " + Global.ExceptionMessage);
			}
		}
		void UpdateDataGridView()
		{
			try
			{
     //           cmd = new SqlCommand
     //           {
     //               CommandType = CommandType.Text,
     //               CommandText = "select gr.ID, st.FirstName + ' ' + st.LastName Name, sub.Name Subject, gr.Grade, " +
     //                       "case when gr.IsExam = 1 then 'Yes' " +
     //                       "when gr.IsExam = 0 then 'No' " +
     //                       "else 'no' end as 'Is Exam' " +
     //                       "from(Grades gr inner join Students st on st.ID = gr.StudentID) " +
     //                       "inner join Subjects sub on sub.ID = gr.SubjectID " +
     //                       "where (st.ID = @IDST or @IDST <= 0) and (sub.ID = @ID or @ID <= 0) and st.Active = 1 and gr.Active = 1",
     //               Connection = sqlConnection
     //           };
     //           cmd.Parameters.AddWithValue("@IDST", cbxStudents.SelectedValue);
     //           cmd.Parameters.AddWithValue("@ID", cbxSubjects.SelectedValue);

     //           dataReader = cmd.ExecuteReader();
     //           dtGridView.Clear();
     //           dtGridView.Load(dataReader);
     //           sql = @"select gr.ID, st.FirstName + ' ' + st.LastName Name, sub.Name Subject, gr.Grade, 
					//case when gr.IsExam = 1 then 'Yes' 
					//when gr.IsExam = 0 then 'No' 
					//else 'No' end as 'Is Exam' 
					//from(Grades gr inner join Students st on st.ID = gr.StudentID) 
					//inner join Subjects sub on sub.ID = gr.SubjectID 
					//where (st.ID = @0 or @0 <= 0) and (sub.ID = @1 or @1 <= 0) and st.Active = 1 and gr.Active = 1";

     //           sql = @"select gr.ID, st.LastName + ' ' + st.FirstName Name, sub.Name Subject, gr.Grade,
					//case when coalesce(gr.IsExam, 0) = 1 then 'Yes' else 'No' end as 'Is Exam'
					//from Grades gr
					//inner join Averages on gr.AverageID = Averages.ID
					//inner join Students st on st.ID = Averages.StudentID
					//inner join Subjects sub on sub.ID = Averages.SubjectID
					//where (st.ID = @0 or @0 <= 0) and (sub.ID = @1 or @1 <= 0) and st.Active = 1 and gr.Active = 1";

                if (DbConn.RoleID == 1)
                {
					sql = "select * from Admin_GradesTableViewFunction(@0, @1)";
				}
				else
                {
					sql = "select * from GradesTableViewFunction(@0, @1)";
				}
				parameters = new List<object>
				{
					cbxStudents.SelectedValue,
					cbxSubjects.SelectedValue
				};
				gvGrades.DataSource = DbConn.GetData(sql, 2, parameters);
				gvGrades.Columns[1].HeaderText = Global.Student;
				gvGrades.Columns[2].HeaderText = Global.Subject;
				gvGrades.Columns[3].HeaderText = Global.Grade;
				gvGrades.Columns[4].HeaderText = Global.IsExam;
                cbxGrades.SelectedIndex = 0;
				gvGrades.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                gvGrades.Columns[3].Width = 40;
                gvGrades.Columns[4].Width = 80;
				gvGrades.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				gvGrades.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
                gvGrades.ClearSelection();
            }
			catch (Exception ex)
			{
				Logger.LogError(ex);
				MessageBox.Show("E310: " + Global.ExceptionMessage);
				throw;
			}
		}

		bool CheckForExistingExam()
		{
			try
			{
				string sql = @"select IsExam from Grades
							inner join Averages av on AverageID = av.ID and av.SubjectID = @0 and av.StudentID = @1 and IsExam = 1";
				List<object> parameters = new List<object>
				{
					cbxSubjects.SelectedValue,
					cbxStudents.SelectedValue,
				};
				DataTable dt = DbConn.GetData(sql, 2, parameters);
				if (dt.Rows.Count != 0)
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

		bool CheckIfSubjectHasExam()
		{
			try
			{
				sql = "select HasExam from Subjects where ID = @0 and HasExam = 1";
				List<object> parameters = new List<object>
				{
					cbxSubjects.SelectedValue,
				};
				DataTable dt = DbConn.GetData(sql, 1, parameters);
				if (dt.Rows.Count != 0)
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

		void CalculateAverage()
		{
			try
			{
				sql = "exec CalculateAverage @0, @1";
				parameters = new List<object>
				{
					cbxSubjects.SelectedValue,
					cbxStudents.SelectedValue,
				};
				DbConn.ExecuteStoredProcedure(sql);
            }
			catch
			{
				throw;
			}
		}

		void DisplayAverage()
		{
			sql = "select cast(cast(Average as decimal(4, 2)) as varchar) Average from Averages where SubjectID = @0 and StudentID = @1";
			parameters = new List<object>
			{
				cbxSubjects.SelectedValue,
				cbxStudents.SelectedValue
			};
			DataTable dt = DbConn.GetData(sql, 2, parameters);
			DataRow dr = dt.Rows[0];
			lblAverage.Text = Global.Average;
			lblAverageValue.Text = dr.Field<string>("Average") ?? "-";
		}
	}
}
