namespace TfsTime
{
	partial class FormMain
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
			if(disposing && (components != null))
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			this.comboBoxTfsUrl = new System.Windows.Forms.ComboBox();
			this.pictureBoxClientStatus = new System.Windows.Forms.PictureBox();
			this.checkBoxConnectSocket = new System.Windows.Forms.CheckBox();
			this.dataGridViewWiql = new System.Windows.Forms.DataGridView();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageTimesheet = new System.Windows.Forms.TabPage();
			this.buttonSave = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
			this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
			this.dataGridViewTimesheet = new System.Windows.Forms.DataGridView();
			this.buttonRefreshTimesheet = new System.Windows.Forms.Button();
			this.tabPageWiql = new System.Windows.Forms.TabPage();
			this.buttonWiqlSend = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxWiql = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.comboBoxProjects = new System.Windows.Forms.ComboBox();
			this.labelWorkingMessage = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxClientStatus)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewWiql)).BeginInit();
			this.tabControl.SuspendLayout();
			this.tabPageTimesheet.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewTimesheet)).BeginInit();
			this.tabPageWiql.SuspendLayout();
			this.SuspendLayout();
			// 
			// comboBoxTfsUrl
			// 
			this.comboBoxTfsUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxTfsUrl.FormattingEnabled = true;
			this.comboBoxTfsUrl.Location = new System.Drawing.Point(112, 12);
			this.comboBoxTfsUrl.Name = "comboBoxTfsUrl";
			this.comboBoxTfsUrl.Size = new System.Drawing.Size(368, 21);
			this.comboBoxTfsUrl.TabIndex = 2;
			this.comboBoxTfsUrl.Text = "http://tfs.mydomain.com:8080/tfs/DefaultCollection/";
			// 
			// pictureBoxClientStatus
			// 
			this.pictureBoxClientStatus.Image = global::TfsTime.Properties.Resources.Disconnected;
			this.pictureBoxClientStatus.Location = new System.Drawing.Point(13, 12);
			this.pictureBoxClientStatus.Name = "pictureBoxClientStatus";
			this.pictureBoxClientStatus.Size = new System.Drawing.Size(16, 16);
			this.pictureBoxClientStatus.TabIndex = 48;
			this.pictureBoxClientStatus.TabStop = false;
			// 
			// checkBoxConnectSocket
			// 
			this.checkBoxConnectSocket.AutoSize = true;
			this.checkBoxConnectSocket.Location = new System.Drawing.Point(35, 14);
			this.checkBoxConnectSocket.Name = "checkBoxConnectSocket";
			this.checkBoxConnectSocket.Size = new System.Drawing.Size(71, 17);
			this.checkBoxConnectSocket.TabIndex = 47;
			this.checkBoxConnectSocket.Text = "TFS URL";
			this.checkBoxConnectSocket.UseVisualStyleBackColor = true;
			this.checkBoxConnectSocket.CheckedChanged += new System.EventHandler(this.checkBoxConnectSocket_CheckedChanged);
			// 
			// dataGridViewWiql
			// 
			this.dataGridViewWiql.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewWiql.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewWiql.Location = new System.Drawing.Point(6, 67);
			this.dataGridViewWiql.Name = "dataGridViewWiql";
			this.dataGridViewWiql.Size = new System.Drawing.Size(753, 292);
			this.dataGridViewWiql.TabIndex = 49;
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.tabPageTimesheet);
			this.tabControl.Controls.Add(this.tabPageWiql);
			this.tabControl.Location = new System.Drawing.Point(13, 39);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(692, 203);
			this.tabControl.TabIndex = 50;
			// 
			// tabPageTimesheet
			// 
			this.tabPageTimesheet.Controls.Add(this.labelWorkingMessage);
			this.tabPageTimesheet.Controls.Add(this.buttonSave);
			this.tabPageTimesheet.Controls.Add(this.label3);
			this.tabPageTimesheet.Controls.Add(this.label2);
			this.tabPageTimesheet.Controls.Add(this.dateTimePickerTo);
			this.tabPageTimesheet.Controls.Add(this.dateTimePickerFrom);
			this.tabPageTimesheet.Controls.Add(this.dataGridViewTimesheet);
			this.tabPageTimesheet.Controls.Add(this.buttonRefreshTimesheet);
			this.tabPageTimesheet.Location = new System.Drawing.Point(4, 22);
			this.tabPageTimesheet.Name = "tabPageTimesheet";
			this.tabPageTimesheet.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageTimesheet.Size = new System.Drawing.Size(684, 177);
			this.tabPageTimesheet.TabIndex = 1;
			this.tabPageTimesheet.Text = "Timesheet";
			this.tabPageTimesheet.UseVisualStyleBackColor = true;
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(591, 6);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 5;
			this.buttonSave.Text = "Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(236, 11);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(20, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "To";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(87, 11);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(30, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "From";
			// 
			// dateTimePickerTo
			// 
			this.dateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePickerTo.Location = new System.Drawing.Point(262, 6);
			this.dateTimePickerTo.Name = "dateTimePickerTo";
			this.dateTimePickerTo.Size = new System.Drawing.Size(108, 20);
			this.dateTimePickerTo.TabIndex = 3;
			// 
			// dateTimePickerFrom
			// 
			this.dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePickerFrom.Location = new System.Drawing.Point(123, 6);
			this.dateTimePickerFrom.Name = "dateTimePickerFrom";
			this.dateTimePickerFrom.Size = new System.Drawing.Size(107, 20);
			this.dateTimePickerFrom.TabIndex = 3;
			// 
			// dataGridViewTimesheet
			// 
			this.dataGridViewTimesheet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewTimesheet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewTimesheet.Location = new System.Drawing.Point(6, 35);
			this.dataGridViewTimesheet.Name = "dataGridViewTimesheet";
			this.dataGridViewTimesheet.Size = new System.Drawing.Size(672, 136);
			this.dataGridViewTimesheet.TabIndex = 1;
			this.dataGridViewTimesheet.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTimesheet_CellValueChanged);
			// 
			// buttonRefreshTimesheet
			// 
			this.buttonRefreshTimesheet.Location = new System.Drawing.Point(6, 6);
			this.buttonRefreshTimesheet.Name = "buttonRefreshTimesheet";
			this.buttonRefreshTimesheet.Size = new System.Drawing.Size(75, 23);
			this.buttonRefreshTimesheet.TabIndex = 0;
			this.buttonRefreshTimesheet.Text = "Refresh";
			this.buttonRefreshTimesheet.UseVisualStyleBackColor = true;
			this.buttonRefreshTimesheet.Click += new System.EventHandler(this.buttonRefreshTimesheet_Click);
			// 
			// tabPageWiql
			// 
			this.tabPageWiql.Controls.Add(this.buttonWiqlSend);
			this.tabPageWiql.Controls.Add(this.label1);
			this.tabPageWiql.Controls.Add(this.textBoxWiql);
			this.tabPageWiql.Controls.Add(this.dataGridViewWiql);
			this.tabPageWiql.Location = new System.Drawing.Point(4, 22);
			this.tabPageWiql.Name = "tabPageWiql";
			this.tabPageWiql.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageWiql.Size = new System.Drawing.Size(684, 177);
			this.tabPageWiql.TabIndex = 0;
			this.tabPageWiql.Text = "WIQL";
			this.tabPageWiql.UseVisualStyleBackColor = true;
			// 
			// buttonWiqlSend
			// 
			this.buttonWiqlSend.Location = new System.Drawing.Point(684, 23);
			this.buttonWiqlSend.Name = "buttonWiqlSend";
			this.buttonWiqlSend.Size = new System.Drawing.Size(75, 23);
			this.buttonWiqlSend.TabIndex = 52;
			this.buttonWiqlSend.Text = "Query";
			this.buttonWiqlSend.UseVisualStyleBackColor = true;
			this.buttonWiqlSend.Click += new System.EventHandler(this.buttonWiqlSend_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 51;
			this.label1.Text = "WIQL";
			// 
			// textBoxWiql
			// 
			this.textBoxWiql.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxWiql.Location = new System.Drawing.Point(49, 6);
			this.textBoxWiql.Multiline = true;
			this.textBoxWiql.Name = "textBoxWiql";
			this.textBoxWiql.Size = new System.Drawing.Size(618, 55);
			this.textBoxWiql.TabIndex = 50;
			this.textBoxWiql.Text = "Select * from WorkItems WHERE ExternalLinkCount > 1";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(486, 15);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 13);
			this.label4.TabIndex = 51;
			this.label4.Text = "Project";
			// 
			// comboBoxProjects
			// 
			this.comboBoxProjects.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxProjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxProjects.FormattingEnabled = true;
			this.comboBoxProjects.Location = new System.Drawing.Point(532, 12);
			this.comboBoxProjects.Name = "comboBoxProjects";
			this.comboBoxProjects.Size = new System.Drawing.Size(173, 21);
			this.comboBoxProjects.TabIndex = 52;
			// 
			// labelWorkingMessage
			// 
			this.labelWorkingMessage.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.labelWorkingMessage.BackColor = System.Drawing.SystemColors.Info;
			this.labelWorkingMessage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelWorkingMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelWorkingMessage.Location = new System.Drawing.Point(123, 54);
			this.labelWorkingMessage.Name = "labelWorkingMessage";
			this.labelWorkingMessage.Size = new System.Drawing.Size(379, 69);
			this.labelWorkingMessage.TabIndex = 53;
			this.labelWorkingMessage.Text = "<working>";
			this.labelWorkingMessage.Visible = false;
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(717, 254);
			this.Controls.Add(this.comboBoxProjects);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.pictureBoxClientStatus);
			this.Controls.Add(this.checkBoxConnectSocket);
			this.Controls.Add(this.comboBoxTfsUrl);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormMain";
			this.Text = "TfsTime";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxClientStatus)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewWiql)).EndInit();
			this.tabControl.ResumeLayout(false);
			this.tabPageTimesheet.ResumeLayout(false);
			this.tabPageTimesheet.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewTimesheet)).EndInit();
			this.tabPageWiql.ResumeLayout(false);
			this.tabPageWiql.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ComboBox comboBoxTfsUrl;
		private System.Windows.Forms.PictureBox pictureBoxClientStatus;
		private System.Windows.Forms.CheckBox checkBoxConnectSocket;
		private System.Windows.Forms.DataGridView dataGridViewWiql;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageWiql;
		private System.Windows.Forms.Button buttonWiqlSend;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxWiql;
		private System.Windows.Forms.TabPage tabPageTimesheet;
		private System.Windows.Forms.Button buttonRefreshTimesheet;
		private System.Windows.Forms.DataGridView dataGridViewTimesheet;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dateTimePickerTo;
		private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox comboBoxProjects;
		private System.Windows.Forms.Label labelWorkingMessage;
	}
}

