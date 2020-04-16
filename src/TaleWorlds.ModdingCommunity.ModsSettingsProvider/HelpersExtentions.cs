using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.ModdingCommunity.ModsSettings.ViewModels;
using TaleWorlds.MountAndBlade;

namespace TaleWorlds.ModdingCommunity.ModsSettingsProvider
{
    public static class HelpersExtentions
    {
        static public ModSettingsViewModel ConfigureSettings<T>(this MBSubModuleBase module, string modName, T viewModel) where T : ModSettingsViewModel
        {
            return viewModel as ModSettingsViewModel;
        }

        static public ModSettingsViewModel ConfigureSettings(this MBSubModuleBase module, string modName)
        {
            return ConfigureSettings(module, modName, new ModSettingsViewModel());
        }
    }
}
