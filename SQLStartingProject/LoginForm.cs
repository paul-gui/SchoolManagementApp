using SQLStartingProject.Resx;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;

namespace SQLStartingProject
{
    public partial class LoginForm : Form
    {
        MenuStrip MenuStrip { get; set; }
        ToolStripMenuItem AddProfessor { get; set; }
        public LoginForm(MenuStrip menuStrip, ToolStripMenuItem addProfessor)
        {
            try
            {
                InitializeComponent();
                MenuStrip = menuStrip;
                AddProfessor = addProfessor;

                lblLogin.Text = Global.Login;
                lblUsername.Text = Global.Username;
                lblPassword.Text = Global.Password;
                btnLogin.Text = Global.Login;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("E400" + Global.ExceptionMessage);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text.Length != 0 && txtPassword.Text.Length != 0)
                {
                    DataTable dt = new DataTable();
                    string sql = "SELECT Language, ID, RoleId FROM Users WHERE UserName = @0 AND Password = @1";
                    List<object> parameters = new List<object>
                    {
                        txtUsername.Text,
                        CreateMD5(txtPassword.Text),
                    };
                    dt = DbConn.GetData(sql, 2, parameters);
                    if (dt.Rows.Count > 0)
                    {
                        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(dt.Rows[0][0].ToString());
                        DbConn.UserID = (int)dt.Rows[0][1];
                        DbConn.RoleID = (int)dt.Rows[0][2];

                        MenuStrip.Visible = true;
                        if (DbConn.RoleID == 1)
                        {
                            AddProfessor.Visible = true;
                        }
                        else
                        {
                            AddProfessor.Visible = false;
                        }
                        NameForm nameform = new NameForm();
                        nameform.FormBorderStyle = FormBorderStyle.None;
                        nameform.MdiParent = this.MdiParent;
                        nameform.Dock = DockStyle.Fill;
                        this.Close();
                        nameform.Show();
                    }
                    else
                    {
                        MessageBox.Show(Global.IncorrectCredentialsStatement);
                    }
                }
                else if (txtUsername.Text.Length == 0 && txtPassword.Text.Length == 0)
                {
                    MessageBox.Show(Global.EmptyUsernamePasswordStatement);
                }
                else if (txtUsername.Text.Length == 0)
                {
                    MessageBox.Show(Global.NullUsernameStatement);
                }
                else if (txtPassword.Text.Length == 0)
                {
                    MessageBox.Show(Global.NullPasswordStatement);
                }   
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("E401" + Global.ExceptionMessage);
            }
        }
        public static string CreateMD5(string input)
        {
            try
            {
                // Use input string to calculate MD5 hash
                using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
                {
                    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                    byte[] hashBytes = md5.ComputeHash(inputBytes);

                    //Convert the byte array to hexadecimal string prior to.NET 5
                    StringBuilder sb = new System.Text.StringBuilder();
                    for (int i = 0; i < hashBytes.Length; i++)
                    {
                        sb.Append(hashBytes[i].ToString("X2"));
                    }
                    return sb.ToString();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
