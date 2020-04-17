using TaleWorlds.Library;
using TaleWorlds.ModdingCommunity.ModsSettings.ViewModels;
using TaleWorlds.ModdingCommunity.ModsSettingsProvider;
using TaleWorlds.ModdingCommunity.ModsSettingsProvider.SettingsFieldTypes;
using TaleWorlds.MountAndBlade.ViewModelCollection.GameOptions;

namespace TaleWorlds.ModdingCommunity.ModsSettings.ProvidersLocator
{
    public class TestLocator : ILocator
    {
        public MBBindingList<ModSettingsViewModel> GetProvidedModSettings(OptionsVM vm)
        {
            var modlist = new MBBindingList<ModSettingsViewModel>();

            var mod1Settings = new MBBindingList<ModsSettingsProvider.SettingsField>() {

                new BooleanSettingsFieldViewModel(vm) { Name = "1.Is True", Description = "Boolean Settings Field for Sample mod1" },
                new BooleanSettingsFieldViewModel(vm) { Name = "1.Is True two", Description = "Boolean Settings Field for Sample mod1" },
                new NumericSettingsFieldViewModel(vm) { Name = "1.How much", Description = "Numeric Settings Field for Sample mod1",Max=2000,Min=200,OptionValue=300,DefaultValue=300},


            };

            var mod2Settings = new MBBindingList<ModsSettingsProvider.SettingsField>() {

                new BooleanSettingsFieldViewModel(vm) { Name = "2.Is True", Description = "Boolean Settings Field for Sample mod2" },
                new BooleanSettingsFieldViewModel(vm) { Name = "2.Is True two", Description = "Boolean Settings Field for Sample mod2" },
                new NumericSettingsFieldViewModel(vm) { Name = "2.How much", Description = "Numeric Settings Field for Sample mod1",IsDiscrete=true,Max=3000,Min=100,OptionValue=500,DefaultValue=500},
                new SelectSettingsFieldViewModel(vm,1,"Option1,Option2,Option3") { Name = "2.Please Select", Description = "Select Option from list"},
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
