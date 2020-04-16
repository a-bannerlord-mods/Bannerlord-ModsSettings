using HarmonyLib;
using TaleWorlds.ModdingCommunity.ModsSettings.ViewModels;
using TaleWorlds.MountAndBlade.ViewModelCollection.GameOptions;

namespace MBModsSettings
{
    [HarmonyPatch(typeof(OptionsVM), "ExecuteDone")]
    public class OptionsVMExecuteDonePatch
    {
        private static void Postfix(OptionsVM __instance)
        {
            if (__instance is OptionsWithModsViewModel)
            {
                (__instance as OptionsWithModsViewModel).OnSavingChanges();
            }
        }
    }
}
