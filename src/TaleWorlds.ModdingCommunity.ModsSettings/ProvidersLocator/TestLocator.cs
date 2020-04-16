using TaleWorlds.Library;
using TaleWorlds.ModdingCommunity.ModsSettings.ViewModels;
using TaleWorlds.ModdingCommunity.ModsSettingsProvider;

namespace TaleWorlds.ModdingCommunity.ModsSettings.ProvidersLocator
{
    public class TestLocator : ILocator
    {
        public MBBindingList<ModSettingsViewModel> GetProvidedModSettings()
        {
            var modlist = new MBBindingList<ModSettingsViewModel>();

            var mod1Settings = new MBBindingList<ModsSettingsProvider.SettingsField>() {

                new BooleanSettingsFieldViewModel() { Name = "1.Is True", Description = "Boolean Settings Field for Sample mod1" },
                new BooleanSettingsFieldViewModel() { Name = "1.Is True two", Description = "Boolean Settings Field for Sample mod1" },
                new BooleanSettingsFieldViewModel() { Name = "1.Is True three", Description = "Boolean Settings Field for Sample mod1" },


            };

            var mod2Settings = new MBBindingList<ModsSettingsProvider.SettingsField>() {

                new BooleanSettingsFieldViewModel() { Name = "2.Is True", Description = "Boolean Settings Field for Sample mod2" },
                new BooleanSettingsFieldViewModel() { Name = "2.Is True two", Description = "Boolean Settings Field for Sample mod2" },
                new BooleanSettingsFieldViewModel() { Name = "2.Is True three", Description = "Boolean Settings Field for Sample mod2" },

            };

            modlist.Add(new ModSettingsViewModel()
            {
                ModName = "Sample mod1",
                ModSettingsList = mod1Settings
            });
            modlist.Add(new ModSettingsViewModel()
            {
                ModName = "Sample mod2",
                ModSettingsList = mod2Settings
            });
            return modlist;

        }
    }
}
