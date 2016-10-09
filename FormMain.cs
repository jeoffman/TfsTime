using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.TeamFoundation.Core.WebApi;
using Microsoft.TeamFoundation.SourceControl.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Client;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;
using Microsoft.VisualStudio.Services.WebApi.Patch;
using Microsoft.VisualStudio.Services.WebApi.Patch.Json;

namespace TfsTime
{
	public partial class FormMain : Form
	{
		public FormMain()
		{
			InitializeComponent();
		}

		UriBuilder uriBuilder = new UriBuilder("http", @"tfs.mydomain.com", 8080, "tfs/DefaultCollection");
		string username;
		string password;
		string domain;
		bool loginFailed = false;
		string AuthorizedIdentity;

		VssConnection connection;

		DataTable table = new DataTable();

		const string Title = "System.Title";
		const string AssignedTo = "System.AssignedTo";
		const string Reviewer = "Custom.Reviewer";
		const string CompletedWork = "Microsoft.VSTS.Scheduling.CompletedWork";
		const string RemainingWork = "Microsoft.VSTS.Scheduling.RemainingWork";

		private void Form1_Load(object sender, EventArgs e)
		{
			DataColumn[] primaryKey = new DataColumn[1];
			primaryKey[0] = table.Columns.Add("WI");
			primaryKey[0].ReadOnly = true;
			table.PrimaryKey = primaryKey;
			DataColumn description = table.Columns.Add("Description");
			description.ReadOnly = true;
			DataColumn completed = table.Columns.Add("Completed");
			DataColumn remain = table.Columns.Add("Remain");

			dataGridViewTimesheet.DataSource = table;

			using(CustomSettings settings = new CustomSettings())
			{
				settings.RestoreWindowPlacement(this);
				settings.LoadItemStrings(comboBoxTfsUrl);
				comboBoxTfsUrl.Text = settings.GetSetting(CustomSettings.TfsUrl, CustomSettings.TfsUrlDefault);

				domain = settings.GetSetting(CustomSettings.Domain, CustomSettings.DomainDefault);
				username = settings.GetSetting(CustomSettings.User, CustomSettings.UserDefault);
				password = settings.GetEncryptedSetting(FormLogOn.SaltPassword, CustomSettings.Pass, CustomSettings.PassDefault);
				settings.RestoreColumnWidths(dataGridViewTimesheet, "timesheet");
			}

			int diff = DateTime.Now.DayOfWeek - DayOfWeek.Sunday;
			if(diff < 0)
				diff += 7;
			else if(diff == 0)	//on Sundays, look at the previous week
				diff = 7;

			dateTimePickerFrom.Value = DateTime.Now.AddDays(-1 * diff).Date;
			//dateTimePickerFrom.Value = DateTime.Now.AddDays(-10);
			dateTimePickerTo.Value = DateTime.Now;

// 				VssConnection connection = new VssConnection(uriBuilder.Uri, new VssCredentials(new Microsoft.VisualStudio.Services.Common.WindowsCredential(new NetworkCredential(username, password, domain))));
// 				var projectCollectionHttpClient = connection.GetClient<ProjectCollectionHttpClient>();
// 
// 				// iterate over the first 10 Project Collections (I am allowed to see)
// 				// however, if no parameter(s) were provided to the .GetProjectCollections() method, it would only retrieve one Collection,
// 				// so basically this allows / provides fine-grained pagination control
// 				foreach(var projectCollectionReference in projectCollectionHttpClient.GetProjectCollections(10, 0).Result)
// 				{
// 					// retrieve a reference to the actual project collection based on its (reference) .Id
// 					var projectCollection = projectCollectionHttpClient.GetProjectCollection(projectCollectionReference.Id.ToString()).Result;
// 
// 					// the 'web' Url is the one for the PC itself, the API endpoint one is different, see below
// 					var webUrlForProjectCollection = projectCollection.Links.Links["web"] as ReferenceLink;
// 
// 					Debug.WriteLine("Project Collection '{0}' (Id: {1}) at Web Url: '{2}' & API Url: '{3}'",
// 						projectCollection.Name,
// 						projectCollection.Id,
// 						webUrlForProjectCollection.Href,
// 						projectCollection.Url);
// 				}
		}

		private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			using(CustomSettings settings = new CustomSettings())
			{
				settings.SaveWindowPlacement(this);
				settings.SaveItemStrings(comboBoxTfsUrl, 10);
				settings.SaveColumnWidths(dataGridViewTimesheet, "timesheet");
				settings.PutSetting(CustomSettings.TfsUrl, comboBoxTfsUrl.Text);
				if(comboBoxProjects.SelectedIndex >= 0)
					settings.PutSetting(CustomSettings.SelectedProject, comboBoxProjects.Text);
			}
		}

		async Task SetupConnection()
		{
			labelWorkingMessage.Text = "Connecting...";
			labelWorkingMessage.Show();

			if(CheckLogon())
			{
				try
				{
					connection = new VssConnection(uriBuilder.Uri, new VssCredentials(new WindowsCredential(new NetworkCredential(username, password, domain))));
					await connection.ConnectAsync();

					AuthorizedIdentity = connection.AuthorizedIdentity.DisplayName;

					SetClientConnectBulbImage(true);

					// and retrieve the corresponding project client 
					using(var projectHttpClient = connection.GetClient<ProjectHttpClient>())
					{
						var result = await projectHttpClient.GetProjects(top: 100, skip: 0);
						// then - same as above.. iterate over the project references (with a hard-coded pagination of the first 10 entries only)
						foreach(var projectReference in result)
						{
							// and then get hold of the actual project
							TeamProject teamProject = projectHttpClient.GetProject(projectReference.Id.ToString()).Result;
							var urlForTeamProject = ((ReferenceLink)teamProject.Links.Links["web"]).Href;

							if(comboBoxProjects.Items.IndexOf(teamProject.Name) < 0)
								comboBoxProjects.Items.Add(teamProject.Name);
// 							Debug.WriteLine("Team Project '{0}' (Id: {1}) at Web Url: '{2}' & API Url: '{3}'",
// 								teamProject.Name,
// 								teamProject.Id,
// 								urlForTeamProject,
// 								teamProject.Url);
						}

// 						{
// 
// 							var projectReferences = await projectHttpClient.GetProjectHistory(0);
// 							foreach(var projectReference in projectReferences)
// 								Debug.WriteLine($"projectReference.Revision = {projectReference.Revision}");
// 						
// 
// 		// 					var workItemsForQueryResultForWiqlBasedQuery = await witClient.GetWorkItemsAsync(
// 		// 							workItemQueryResultForWiqlBasedQuery.WorkItems.Select(workItemReference => workItemReference.Id),
// 		// 							expand: WorkItemExpand.All);
// 
// 
// 		// 					List<QueryHierarchyItem> items = await witClient.GetQueriesAsync("Orion");
// 		// 
// 		// 					TeamProject teamProject = projectHttpClient.GetProject("Orion").Result;
// 
// 						}


	//  				TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(uriBuilder.Uri, new NetworkCredential(username, password, domain));
	//  				tpc.EnsureAuthenticated();
	// 
	// 
	// 				WorkItemStore workItemStore = tpc.GetService<WorkItemStore>();
	// 
	// 				string query = "SELECT * FROM WorkItems";
	// 				WorkItemCollection WIC = workItemStore.Query(query);
	// 
	// 
	// 				string requestedProject = "Orion";
	// 				Project teamProject = workItemStore.Projects[requestedProject];
	// 				Microsoft.TeamFoundation.WorkItemTracking.Client.WorkItemType workItemType = teamProject.WorkItemTypes["test"];




	// 
	// 				// Use default windows credentials, and if they fail, AllowInteractive=true
	// 				var tfsCreds = new TfsClientCredentials(new WindowsCredential(), true);
	// 
	// 				TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(
	// 					new Uri("http://yourserver:8080/tfs/DefaultCollection"),
	// 					tfsCreds);
	// 
	// 				//var connection = new VssConnection(uriBuilder.Uri, new VssClientCredentials());
	// 				//var credentials = new VssBasicCredential(@"domain\user", "password");
	// 				//credentials.CredentialType = VssCredentialsType.Windows;
	// 				var networkCredential = new NetworkCredential("domain\\user", "password");
	// 
	// 				BasicAuthCredential basicCred = new BasicAuthCredential(networkCredential);
	// 				TfsClientCredentials tfsCred = new TfsClientCredentials(basicCred);
	// 				tfsCred.AllowInteractive = false;
	// 
	// 				var connection = new VssConnection(uriBuilder.Uri, networkCredential);
	// 				//connection.Settings.
	// 
	// // 				using(TfsTeamProjectCollection collection = new TfsTeamProjectCollection(tfsURI, networkCredential))
	// // 				{
	// // 					collection.EnsureAuthenticated();
	// // 					Console.WriteLine(collection.InstanceId); //This works, uses network credentials
	// // 				}
	// 
	// 
	// 				//await connection.ConnectAsync(VssConnectMode.Secure);
	// 				WorkItemTrackingHttpClient witClient = connection.GetClient<WorkItemTrackingHttpClient>();
	// 				List<QueryHierarchyItem> items = witClient.GetQueriesAsync("SoftwareEng").Result;


					}

					using(CustomSettings settings = new CustomSettings())
					{
						string selectedProject = settings.GetSetting(CustomSettings.SelectedProject, CustomSettings.SelectedProjectDefault);
						if(!string.IsNullOrEmpty(selectedProject))
							comboBoxProjects.SelectedItem = selectedProject;
					}
				}
				catch(Exception exc)
				{
					MessageBox.Show(exc.Message);

					loginFailed = true;
					await CloseConnection();
				}

				labelWorkingMessage.Hide();
				//Close();
			}
		}

		private void SetClientConnectBulbImage(bool isConnected)
		{
			if(isConnected)
				pictureBoxClientStatus.Image = global::TfsTime.Properties.Resources.Connected;
			else
				pictureBoxClientStatus.Image = global::TfsTime.Properties.Resources.Disconnected;
		}

		void EnableGui(bool enabled)
		{
			UseWaitCursor = !enabled;
			buttonWiqlSend.Enabled = enabled;
			checkBoxConnectSocket.Enabled = enabled;
			buttonRefreshTimesheet.Enabled = enabled;
			foreach(TabPage page in tabControl.TabPages)
				page.Enabled = enabled;
		}

		private async void checkBoxConnectSocket_CheckedChanged(object sender, EventArgs e)
		{
			if(checkBoxConnectSocket.Checked)
				await OpenConnection();
			else
				await CloseConnection();
		}

		private async Task OpenConnection()
		{
			EnableGui(false);
			uriBuilder = new UriBuilder(comboBoxTfsUrl.Text);
			await SetupConnection();
			EnableGui(true);
		}

		private async Task CloseConnection()
		{
			EnableGui(false);
			checkBoxConnectSocket.Checked = false;
			SetClientConnectBulbImage(false);
			if(connection != null)
			{
				connection.Disconnect();
				connection = null;
			}
			await Task.FromResult(0);   //suppress CS1998
			EnableGui(true);
		}

		private bool CheckLogon()
		{
			bool retval = true;
			if(loginFailed || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
			{
				retval = false;
				using(FormLogOn form = new FormLogOn())
				{
					if(form.ShowDialog(this) == DialogResult.OK)
					{
						username = form.UserName;
						password = form.Password;
						domain = form.Domain;
						retval = true;
					}
				}
			}
			return retval;
		}

		private async void buttonWiqlSend_Click(object sender, EventArgs e)
		{
			EnableGui(false);
			labelWorkingMessage.Text = "Working...";
			labelWorkingMessage.Show();

			WorkItemTrackingHttpClient witClient = connection.GetClient<WorkItemTrackingHttpClient>();
			var wiqlQuery = new Wiql() { Query = textBoxWiql.Text };
			var workItemQueryResultForWiqlBasedQuery = await witClient.QueryByWiqlAsync(wiqlQuery);
			dataGridViewWiql.DataSource = workItemQueryResultForWiqlBasedQuery.WorkItems;

// 			TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(uriBuilder.Uri, new NetworkCredential(username, password, domain));
// 			tpc.EnsureAuthenticated();
// 			VersionControlServer versionControlServer = tpc.GetService<VersionControlServer>();

			EnableGui(true);
			labelWorkingMessage.Hide();
		}

		private async void buttonRefreshTimesheet_Click(object sender, EventArgs e)
		{
			EnableGui(false);
			labelWorkingMessage.Text = "Working...";
			labelWorkingMessage.Show();

			try
			{
				table.Clear();

				TfvcHttpClient tfvcClient = connection.GetClient<TfvcHttpClient>();	//WARN: do NOT "using" this!!!!

				var fromDate = dateTimePickerFrom.Value;
				var toDate = dateTimePickerTo.Value.AddDays(1);	//it looks like the "from" is not inclusive, so accommodate
				WorkItemTrackingHttpClient witClient = connection.GetClient<WorkItemTrackingHttpClient>();

				TfvcChangesetSearchCriteria searchCriteria = new TfvcChangesetSearchCriteria() { FromDate = fromDate.ToString("G"), ToDate = toDate.ToString("G") };
				searchCriteria.ItemPath = "$/" + comboBoxProjects.Text;
				List<TfvcChangesetRef> changesets = await tfvcClient.GetChangesetsAsync(top: 1000, orderby: "ChangesetId", searchCriteria: searchCriteria);

				labelWorkingMessage.Text += Environment.NewLine;
				labelWorkingMessage.Text += $"Scanning {changesets.Count} changesets...";

				foreach(TfvcChangesetRef changeset in changesets)
				{
					List<AssociatedWorkItem> workItems = await tfvcClient.GetChangesetWorkItemsAsync(id: changeset.ChangesetId);
					foreach(AssociatedWorkItem workItemReference in workItems)
					{
						WorkItem workItem = await witClient.GetWorkItemAsync(workItemReference.Id);
						if(workItem.Fields.ContainsKey(AssignedTo) && workItem.Fields.ContainsKey(Reviewer))
						{
							var assignedTo = workItem.Fields[AssignedTo].ToString();
							var reviewer = workItem.Fields[Reviewer].ToString();
							if(	assignedTo.ToLower().Contains(username.ToLower()) ||
								reviewer.ToLower().Contains(username.ToLower()) ||
								assignedTo.ToLower().Contains(AuthorizedIdentity.ToLower()) ||
								reviewer.ToLower().Contains(AuthorizedIdentity.ToLower())
								)
							{
								int completedWork;
								int remainingWork;

								if(workItem.Fields.ContainsKey(CompletedWork))
									completedWork = Convert.ToInt32(workItem.Fields[CompletedWork]);
								else
									completedWork = 0;
								if(workItem.Fields.ContainsKey(RemainingWork))
									remainingWork = Convert.ToInt32(workItem.Fields[RemainingWork]);
								else
									remainingWork = 0;

								DataRow foundRow = table.Rows.Find(workItem.Id);
								if(foundRow != null)
								{
									//int completed = (int)foundRow.ItemArray[2];

									//maybe check if the values are different or something?
									foundRow.ItemArray[1] = completedWork;
									foundRow.ItemArray[2] = remainingWork;
// 									foundRow.ItemArray[1] = int.Parse(foundRow.ItemArray[2].ToString()) + completedWork;
// 									foundRow.ItemArray[2] = int.Parse(foundRow.ItemArray[3].ToString()) + remainingWork;
								}
								else
								{
									table.Rows.Add(new object[] { workItem.Id.Value, workItem.Fields[Title].ToString(), completedWork, remainingWork });
								}
							}
						}
					}
				}
				table.AcceptChanges();	//done loading, ready to track changes
				buttonSave.Enabled = false;
			}
			catch(Exception exc)
			{
				MessageBox.Show(exc.Message);
			}
			labelWorkingMessage.Hide();
			EnableGui(true);
		}

		private void dataGridViewTimesheet_CellValueChanged(object sender, DataGridViewCellEventArgs dgvcea)
		{
			dataGridViewTimesheet.Rows[dgvcea.RowIndex].DefaultCellStyle.Font = new Font(dataGridViewTimesheet.Font, FontStyle.Bold);
			buttonSave.Enabled = true;
		}

		private async void buttonSave_Click(object sender, EventArgs e)
		{
			EnableGui(false);
			labelWorkingMessage.Show();
			labelWorkingMessage.Text = "Saving...";
			try
			{
				DataTable changes = new DataTable();
				changes = table.GetChanges();
				if(changes != null && changes.Rows.Count > 0)
				{
					labelWorkingMessage.Text += Environment.NewLine;
					labelWorkingMessage.Text += $"Saving {changes.Rows.Count} changes...";

					WorkItemTrackingHttpClient witClient = connection.GetClient<WorkItemTrackingHttpClient>();
					foreach(DataRow change in changes.Rows)
					{
						WorkItem workItem = await witClient.GetWorkItemAsync(int.Parse(change[0].ToString()));

						//And here is where things get weird...
						var patchDocument = new JsonPatchDocument();

						int oldCompletedWork = 0;
						if(workItem.Fields.ContainsKey(CompletedWork))
							oldCompletedWork = Convert.ToInt32(workItem.Fields[CompletedWork]);
						int newCompletedWork = int.Parse(change.ItemArray[2].ToString());
						if(oldCompletedWork != newCompletedWork)
						{
//							workItem.Fields[CompletedWork] = newCompletedWork;	HA! it should be so easy!
							patchDocument.Add(
								new JsonPatchOperation()
								{
									Operation = Operation.Add,
									Path = $"/fields/{CompletedWork}",
									Value = newCompletedWork
								}
							);
						}

						int oldRemainingWork = 0;
						if(workItem.Fields.ContainsKey(RemainingWork))
							oldRemainingWork = Convert.ToInt32(workItem.Fields[RemainingWork]);
						int newRemainingWork = int.Parse(change.ItemArray[3].ToString());
						if(oldRemainingWork != newRemainingWork)
						{
//							workItem.Fields[RemainingWork] = newRemainingWork;	HA! it should be so easy!
							patchDocument.Add(
								new JsonPatchOperation()
								{
									Operation = Operation.Add,
									Path = $"/fields/{RemainingWork}",
									Value = newRemainingWork
								}
							);
						}

						var newWi = await witClient.UpdateWorkItemAsync(patchDocument, workItem.Id.Value, false);
					}
					table.AcceptChanges();
					buttonSave.Enabled = false;

					//reset the "changed" font (bold)
					foreach(DataGridViewRow dgvRow in dataGridViewTimesheet.Rows)
						dgvRow.DefaultCellStyle.Font = dataGridViewTimesheet.Font;
				}
				else
				{
					MessageBox.Show("No changes detected!");
				}
			}
			catch(Exception exc)
			{
				MessageBox.Show(exc.Message);

				loginFailed = true;
				await CloseConnection();
			}
			EnableGui(true);
			labelWorkingMessage.Hide();
		}
	}
}
