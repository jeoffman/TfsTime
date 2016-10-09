using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JkhSettings;

namespace TfsTime
{
	public class CustomSettings : CustomSettingsBase
	{
		public CustomSettings() : base(true)
		{
		}

		public const string TfsUrl = "TfsUrl";
		public const string TfsUrlDefault = "http://tfs.mydomain.com:8080/tfs/DefaultCollection/";

		public const string SelectedProject = "SelectedProject";
		public const string SelectedProjectDefault = "";

		public const string User = "User";
		public const string UserDefault = "";

		public const string Pass = "Pass";
		public const string PassDefault = "";

		public const string Domain = "Domain";
		public const string DomainDefault = "";

		public const string SavePass = "SavePass";
		public const bool SavePassDefault = false;
	}
}
