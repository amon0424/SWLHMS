using System.Configuration;

namespace Mong.Properties {
    
    
    // This class allows you to handle specific events on the settings class:
    //  The SettingChanging event is raised before a setting's value is changed.
    //  The PropertyChanged event is raised after a setting's value is changed.
    //  The SettingsLoaded event is raised after the setting values are loaded.
    //  The SettingsSaving event is raised before the setting values are saved.
	internal sealed partial class Settings : ApplicationSettingsBase
	{
        
        public Settings() {
            // // To add event handlers for saving and changing settings, uncomment the lines below:
            //
            // this.SettingChanging += this.SettingChangingEventHandler;
            //
            // this.SettingsSaving += this.SettingsSavingEventHandler;
            //

        }

		private static Settings defaultInstance = ((Settings)(ApplicationSettingsBase.Synchronized(new Settings())));

		public static Settings Default
		{
			get
			{
				return defaultInstance;
			}
		}

        private void SettingChangingEventHandler(object sender, System.Configuration.SettingChangingEventArgs e) {
            // Add code to handle the SettingChangingEvent event here.
        }
        
        private void SettingsSavingEventHandler(object sender, System.ComponentModel.CancelEventArgs e) {
            // Add code to handle the SettingsSaving event here.
        }

		public static void ChangeConnectionString(string connectionString)
		{
			Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			string oriStr = Settings.Default.dbConnectionString;
			config.ConnectionStrings.ConnectionStrings["Mong.Properties.Settings.dbConnectionString"].ConnectionString = connectionString;
			config.Save(ConfigurationSaveMode.Modified);
			ConfigurationManager.RefreshSection(config.ConnectionStrings.SectionInformation.Name);
			Settings.Default.Reload();

			//config.ConnectionStrings.ConnectionStrings["Mong.Properties.Settings.dbConnectionString"].ConnectionString = oriStr;
			//config.Save(ConfigurationSaveMode.Modified);
		}

		public string dbConnectionString
		{
			get
			{
				return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\db.mdb;Jet OLEDB:Database Password=1111";
			}
		}
    }
}
