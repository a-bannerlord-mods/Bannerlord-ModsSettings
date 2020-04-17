using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.Library;
using TaleWorlds.ModdingCommunity.ModsSettings.ViewModels;
using TaleWorlds.MountAndBlade.ViewModelCollection.GameOptions;

namespace TaleWorlds.ModdingCommunity.ModsSettings.ProvidersLocator
{
    public class ProvidersLocator : ILocator
    {
        public MBBindingList<ModSettingsViewModel> GetProvidedModSettings(OptionsVM vm)
        {
            // should scan for all provided mods 
            return new MBBindingList<ModSettingsViewModel>();
        }
    }
}
