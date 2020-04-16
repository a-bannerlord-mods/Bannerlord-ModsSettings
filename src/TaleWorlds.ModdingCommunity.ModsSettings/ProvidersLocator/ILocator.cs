using TaleWorlds.Library;
using TaleWorlds.ModdingCommunity.ModsSettings.ViewModels;

namespace TaleWorlds.ModdingCommunity.ModsSettings.ProvidersLocator
{
    public interface ILocator
    {
        MBBindingList<ModSettingsViewModel> GetProvidedModSettings();
    }
}