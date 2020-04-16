using HarmonyLib;
using System;
using System.Linq;
using TaleWorlds.Core;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.Engine.Screens;
using TaleWorlds.GauntletUI.Data;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.ModdingCommunity.ModsSettings.ViewModels;
using TaleWorlds.MountAndBlade.GauntletUI;
using TaleWorlds.MountAndBlade.ViewModelCollection.GameOptions;
using TaleWorlds.MountAndBlade.ViewModelCollection.GameOptions.GameKeys;
using TaleWorlds.TwoDimension;

namespace TaleWorlds.ModdingCommunity.ModsSettings.Patching
{
    [HarmonyPatch(typeof(OptionsGauntletScreen), "OnInitialize")]
    public class OptionsGauntletScreenOnInitializePatch
    {

        static void Set(OptionsGauntletScreen __instance, string name, object value)
        {
            var prop = __instance.GetType().GetField(name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            prop.SetValue(__instance, value);
        }
        static object Get(OptionsGauntletScreen __instance, string name)
        {
            var prop = __instance.GetType().GetField(name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            return prop.GetValue(__instance);
        }

        private static void Postfix(OptionsGauntletScreen __instance)
        {

            __instance.RemoveLayer(__instance.Layers.FirstOrDefault());

            SpriteData spriteData = UIResourceManager.SpriteData;
            TwoDimensionEngineResourceContext resourceContext = UIResourceManager.ResourceContext;
            ResourceDepot uiresourceDepot = UIResourceManager.UIResourceDepot;

            var _spriteCategory = spriteData.SpriteCategories["ui_options"];
            _spriteCategory.Load(resourceContext, uiresourceDepot);
            OptionsWithModsViewModel _dataSource = new OptionsWithModsViewModel(true, false, (requestedHotKeyToChange) =>
            {
                Set(__instance, "_currentGameKey", requestedHotKeyToChange);
                ((KeybindingPopup)Get(__instance, "_keybindingPopup")).OnToggle(true);

            }, null);
            GauntletLayer _gauntletLayer = new GauntletLayer(4000, "GauntletLayer");
            GauntletMovie _gauntletMovie = _gauntletLayer.LoadMovie("Options", _dataSource);
            _gauntletLayer.Input.RegisterHotKeyCategory(HotKeyManager.GetCategory("GenericPanelGameKeyCategory"));
            _gauntletLayer.InputRestrictions.SetInputRestrictions(true, InputUsageMask.All);
            _gauntletLayer.IsFocusLayer = true;
            KeybindingPopup _keybindingPopup = new KeybindingPopup(new Action<Key>((key) =>
            {
                GameKeyOptionVM _currentGameKey = Get(__instance, "_currentGameKey") as GameKeyOptionVM;
                KeybindingPopup _keybindingPopupinner = Get(__instance, "_keybindingPopup") as KeybindingPopup;
                if (_dataSource.GameKeyOptionGroups.Groups.First((GameKeyGroupVM g) => g.GameKeys.Contains(_currentGameKey)).GameKeys.Any((GameKeyOptionVM k) => k.CurrentKey.InputKey == key.InputKey))
                {
                    InformationManager.AddQuickInformation(new TextObject("{=n4UUrd1p}Already in use", null), 0, null, "");
                    return;
                }
                if (_gauntletLayer.Input.IsHotKeyReleased("Exit"))
                {
                    _keybindingPopupinner.OnToggle(false);
                    return;
                }
                GameKeyOptionVM currentGameKey = _currentGameKey;
                if (currentGameKey != null)
                {
                    currentGameKey.Set(key.InputKey);
                }
                _currentGameKey = null;
                _keybindingPopupinner.OnToggle(false);


            }), __instance);
            __instance.AddLayer(_gauntletLayer);
            ScreenManager.TrySetFocus(_gauntletLayer);

            Set(__instance, "_spriteCategory", _spriteCategory);
            Set(__instance, "_dataSource", _dataSource);
            Set(__instance, "_gauntletLayer", _gauntletLayer);
            Set(__instance, "_gauntletMovie", _gauntletMovie);
            Set(__instance, "_keybindingPopup", _keybindingPopup);
        }


    }
}
