using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;
using SQLStartingProject.Resx;
using System.Windows.Forms;

namespace SQLStartingProject
{
    public partial class AddUserForm : Form
    {
        string sql;
        public AddUserForm()
        {
            InitializeComponent();
            this.Text = Global.AddUser;
            lblUserName.Text = Global.Username;
            lblPassword.Text = Global.Password;
            btnCancel.Text = Global.Cancel;
            btnSave.Text = Global.Save;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Dispose();
                this.Close();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("E501" + Global.ExceptionMessage);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserName.Text.Length > 3 && txtPassword.Text.Length > 3)
                {
                    if (chkAdmin.Checked)
                    {
                        sql = "INSERT INTO Users(RoleId, UserName, Password, Language) VALUES (1, @0 , @1, @2)";
                    }
                    else
                    {
                        sql = "INSERT INTO Users(RoleId, UserName, Password, Language) VALUES (2, @0 , @1, @2)";
                    }
                    List<object> parameters = new List<object>
                    {
                        txtUserName.Text,
                        CreateMD5(txtPassword.Text),
                        CultureInfo.InstalledUICulture.Name
                    };
                    DbConn.UpdateData(sql, 3, parameters);
                    MessageBox.Show(Global.UserAddedStatement);
                    this.Dispose();
                    this.Close();
                }
                else if (txtUserName.Text.Length == 0 || txtPassword.Text.Length == 0)
                {
                    MessageBox.Show(Global.NullUsernamePasswordStatement);   
                }
                else
                {
                    MessageBox.Show(Global.UsernamePasswordStatement);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("E502" + Global.ExceptionMessage);
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
