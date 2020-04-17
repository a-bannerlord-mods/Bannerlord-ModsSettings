using System;
using TaleWorlds.Library;
using TaleWorlds.ModdingCommunity.ModsSettings.ProvidersLocator;
using TaleWorlds.ModdingCommunity.ModsSettingsProvider;
using TaleWorlds.MountAndBlade.ViewModelCollection.GameOptions;

namespace TaleWorlds.ModdingCommunity.ModsSettings.ViewModels
{
    public class OptionsWithModsViewModel : OptionsVM
    {
        private ModOptionsCategoryViewModel modOptionsCategory;

        [DataSourceProperty]
        public ModOptionsCategoryViewModel ModOptionsCategory
        {
            get
            {
                return this.modOptionsCategory;
            }
            set
            {
                if (value != this.modOptionsCategory)
                {
                    this.modOptionsCategory = value;
                    base.OnPropertyChanged();
                }
            }
        }

        public override void RefreshValues()
        {
            base.RefreshValues();
            ModOptionsCategory?.RefreshValues();

        }
        public void OnSavingChanges()
        {
            foreach (var item in ModOptionsCategory.ModSettings)
            {
                try
                {
                    item.OnSavingChanges();
                }
                catch (Exception e)
                {

                }

            }
        }

        ILocator locator;
        public OptionsWithModsViewModel(bool autoHandleClose, bool openedFromMultiplayer, Action<GameKeyOptionVM> onKeybindRequest, Action onBrightnessExecute = null) : base(autoHandleClose, openedFromMultiplayer, onKeybindRequest, onBrightnessExecute)
        {

            locator = new TestLocator();


            this.modOptionsCategory = new ModOptionsCategoryViewModel(this, locator.GetProvidedModSettings(this));// should get the acual mods instead from any class implement ISettingsProvider
        }

        public OptionsWithModsViewModel(bool openedFromMultiplayer, Action onClose, Action<GameKeyOptionVM> onKeybindRequest, Action onBrightnessExecute = null) : base(openedFromMultiplayer, onClose, onKeybindRequest, onBrightnessExecute)
        {
            locator = new TestLocator();

            this.modOptionsCategory = new ModOptionsCategoryViewModel(this, locator.GetProvidedModSettings(this));// should get the acual mods instead from any class implement ISettingsProvider

        }
    }
}
