using TaleWorlds.Library;
using TaleWorlds.ModdingCommunity.ModsSettings.ViewModels;
using TaleWorlds.MountAndBlade.ViewModelCollection.GameOptions;

namespace TaleWorlds.ModdingCommunity.ModsSettings.ProvidersLocator
{
    public interface ILocator
    {
        MBBindingList<ModSettingsViewModel> GetProvidedModSettings(OptionsVM vm);
    }
}