using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;


namespace TfsTime
{
	public partial class FormLogOn : Form
	{
		public const string SaltPassword = nameof(FormLogOn); //aint I horrible?

		public string Domain { get; private set; }
		public string UserName { get; private set; }
		public string Password { get; private set; }
		public bool SavePassword { get; private set; }

		public FormLogOn()
		{
			InitializeComponent();
		}

		private void FormLogOn_Load(object sender, EventArgs e)
		{
			Icon iconToUse = null;
			FormCollection fc = Application.OpenForms;
			if(fc.Count > 0)
				iconToUse = fc[0].Icon;

			if(iconToUse != null)
			{
				pictureBox.Image = iconToUse.ToBitmap();
			}
			else
			{
				//Debug.Assert(false);
			}

			using(CustomSettings settings = new CustomSettings())
			{
				settings.RestoreWindowPlacement(this);
				textBoxDomain.Text = settings.GetSetting(CustomSettings.Domain, CustomSettings.DomainDefault);
				textBoxLoginID.Text = settings.GetSetting(CustomSettings.User, CustomSettings.UserDefault);
				checkBoxSavePass.Checked = settings.GetSetting(CustomSettings.SavePass, false);
				textBoxPassword.Text = settings.GetEncryptedSetting(SaltPassword, CustomSettings.Pass, CustomSettings.PassDefault);
			}
		}

		private void FormLogOn_FormClosing(object sender, FormClosingEventArgs e)
		{
			using(CustomSettings settings = new CustomSettings())
			{
				settings.SaveWindowPlacement(this);
			}
		}

		private void CheckEnableSavePasswordBox()
		{
			// Old CPS would only let you save your password if the Telecenter username matched the Windows Workstation user name.
			//	Now we just let the user save ANY Telecenter user name
			//checkBoxSavePass.Enabled = textBoxLoginID.Text.Equals(Environment.UserName, StringComparison.CurrentCultureIgnoreCase);
		}

		private void textBoxLoginID_TextChanged(object sender, EventArgs e)
		{
			CheckEnableSavePasswordBox();
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			Domain = textBoxDomain.Text;
			UserName = textBoxLoginID.Text;
			Password = textBoxPassword.Text;
			SavePassword = checkBoxSavePass.Checked;
			using(CustomSettings settings = new CustomSettings())
			{
				settings.PutSetting(CustomSettings.Domain, textBoxDomain.Text);
				settings.PutSetting(CustomSettings.User, textBoxLoginID.Text);
				settings.PutEncryptedSetting(SaltPassword, CustomSettings.Pass, textBoxPassword.Text);
				if(checkBoxSavePass.Checked)
					settings.PutSetting(CustomSettings.SavePass, checkBoxSavePass.Checked);
				else
					settings.PutSetting(CustomSettings.SavePass, string.Empty);
			}
			DialogResult = DialogResult.OK;
		}
	}
}
