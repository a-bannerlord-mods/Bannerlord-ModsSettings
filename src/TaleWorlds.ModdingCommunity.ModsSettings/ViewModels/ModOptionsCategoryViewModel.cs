using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.ViewModelCollection.GameOptions;

namespace TaleWorlds.ModdingCommunity.ModsSettings.ViewModels
{
    public class ModOptionsCategoryViewModel : ViewModel
    {

        public ModOptionsCategoryViewModel(OptionsVM parent, MBBindingList<ModSettingsViewModel> modSettings)
        {
            ModSettings = modSettings;

        }


        private string _name = "Mods Settings";
        [DataSourceProperty]
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                if (value != this._name)
                {
                    this._name = value;
                    base.OnPropertyChanged();
                }
            }
        }


        MBBindingList<ModSettingsViewModel> modSettings = new MBBindingList<ModSettingsViewModel>();
        public MBBindingList<ModSettingsViewModel> ModSettings
        {
            get { return modSettings; }
            set { modSettings = value; OnPropertyChanged(); }
        }

        public override void RefreshValues()
        {
            foreach (var item in modSettings)
            {
                item.RefreshValues();
            }
        }
    }
}
