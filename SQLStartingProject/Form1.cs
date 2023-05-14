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
using SQLStartingProject.Resx;

namespace SQLStartingProject
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			CultureInfo culture = CultureInfo.InstalledUICulture;
			Thread.CurrentThread.CurrentUICulture = culture;
		}

		private void CloseAllChildren()
		{
			foreach (Form frm in this.MdiChildren)
			{
				frm.Dispose();
				frm.Close();
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
            menuStrip1.Visible = false;
            LoginForm loginForm = new LoginForm(menuStrip1, addUserToolStripMenuItem);
            loginForm.FormBorderStyle = FormBorderStyle.None;
            loginForm.MdiParent = this;
            loginForm.Dock = DockStyle.Fill;
            loginForm.Show();
		}

		private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CloseAllChildren();
			NameForm nameform = new NameForm();
			nameform.FormBorderStyle = FormBorderStyle.None;
			nameform.MdiParent = this;
			nameform.Dock = DockStyle.Fill;
			nameform.Show();
		}

		private void subjectsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CloseAllChildren();
            SubjectsForm subjectsForm = new SubjectsForm
            {
                FormBorderStyle = FormBorderStyle.None,
                MdiParent = this,
                Dock = DockStyle.Fill
            };
            subjectsForm.Show();
		}

		private void gradesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CloseAllChildren();
			GradesForm gradesForm = new GradesForm();
			gradesForm.FormBorderStyle = FormBorderStyle.None;
			gradesForm.MdiParent = this;
			gradesForm.Dock = DockStyle.Fill;
			gradesForm.Show();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AboutBox1 about = new AboutBox1();
			about.Show();
		}

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
			if (Thread.CurrentThread.CurrentUICulture.Name != "en-EN")
			{
				if (MessageBox.Show(Global.ChangeLaguageStatement, Global.Confirm, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
				{
					string sql = "UPDATE Users SET Language = 'en-EN' WHERE ID = @0";
					List<object> parameters = new List<object>
					{
						DbConn.UserID,
					};
					DbConn.UpdateData(sql, 1, parameters);
					Thread.CurrentThread.CurrentUICulture = CultureInfo.InstalledUICulture;
					CloseAllChildren();
					LoginForm loginForm = new LoginForm(menuStrip1, addUserToolStripMenuItem);
					loginForm.FormBorderStyle = FormBorderStyle.None;
					loginForm.MdiParent = this;
					loginForm.Dock = DockStyle.Fill;
					loginForm.Show();

					menuStrip1.Visible = false;
				}
			}

        }

        private void romanianToolStripMenuItem_Click(object sender, EventArgs e)
        {
			if (Thread.CurrentThread.CurrentUICulture.Name != "ro-RO")
			{
				if (MessageBox.Show(Global.ChangeLaguageStatement, Global.Confirm, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
				{
					string sql = "UPDATE Users SET Language = 'ro-RO' WHERE ID = @0";
					List<object> parameters = new List<object>
					{
						DbConn.UserID,
					};
					DbConn.UpdateData(sql, 1, parameters);
					Thread.CurrentThread.CurrentUICulture = CultureInfo.InstalledUICulture;

					menuStrip1.Visible = false;
					LoginForm loginForm = new LoginForm(menuStrip1, addUserToolStripMenuItem);
					loginForm.FormBorderStyle = FormBorderStyle.None;
					loginForm.MdiParent = this;
					loginForm.Dock = DockStyle.Fill;
					loginForm.Show();
				}
			}
		}

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Thread.CurrentThread.CurrentUICulture = CultureInfo.InstalledUICulture;

			menuStrip1.Visible = false;
			LoginForm loginForm = new LoginForm(menuStrip1, addUserToolStripMenuItem);
			loginForm.FormBorderStyle = FormBorderStyle.None;
			loginForm.MdiParent = this;
			loginForm.Dock = DockStyle.Fill;
			loginForm.Show();
		}

        private void menuStrip1_VisibleChanged(object sender, EventArgs e)
        {
			menuStrip1.Items[0].Text = Global.Students;
			menuStrip1.Items[1].Text = Global.Subjects;
			menuStrip1.Items[2].Text = Global.Grades;
			menuStrip1.Items[3].Text = Global.Settings;
			languageToolStripMenuItem1.Text = Global.Language;
			englishToolStripMenuItem1.Text = Global.English;
			romanianToolStripMenuItem1.Text = Global.Romanian;
			logOutToolStripMenuItem1.Text = Global.LogOut;
			aboutToolStripMenuItem1.Text = Global.About;
			addUserToolStripMenuItem.Text = Global.AddUser;
		}

        private void addProfessorToolStripMenuItem_Click(object sender, EventArgs e)
        {
			AddUserForm addProfessorForm = new AddUserForm();
			addProfessorForm.StartPosition = FormStartPosition.CenterScreen;
			addProfessorForm.Show();
        }
    }
}
