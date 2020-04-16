using System;
using TaleWorlds.Library;
using TaleWorlds.ModdingCommunity.ModsSettingsProvider;

namespace TaleWorlds.ModdingCommunity.ModsSettings.ViewModels
{
    public class ModSettingsViewModel : ViewModel
    {
        string modName;
        [DataSourceProperty]
        public string ModName
        {
            get { return modName; }
            set { modName = value; OnPropertyChanged(); }
        }

        string modPath;
        [DataSourceProperty]
        public string ModPath
        {
            get { return modPath; }
            set { modPath = value; OnPropertyChanged(); }
        }

        MBBindingList<SettingsField> modSettingsList = new MBBindingList<SettingsField>();
        public MBBindingList<SettingsField> ModSettingsList
        {
            get { return modSettingsList; }
            set { modSettingsList = value; OnPropertyChanged(); }
        }
        public virtual void RefreshValues()
        {
            //  ModOptionLists.RefreshValues();
        }

        public virtual void OnSavingChanges()
        {

        }
    }
}