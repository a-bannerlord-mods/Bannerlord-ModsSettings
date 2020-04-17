using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.Core.ViewModelCollection;
using TaleWorlds.Engine.Options;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.ViewModelCollection.GameOptions;

namespace TaleWorlds.ModdingCommunity.ModsSettingsProvider.SettingsFieldTypes
{
    public class SelectSettingsFieldViewModel : SettingsField, ISelectionOptionData
    {
        public OptionsVM Parent { get; set; }
        public List<SelectionData> SelectableOption { get; set; }


        //float _optionValue;
        //public float OptionValue
        //{
        //    get
        //    {
        //        return this._optionValue;
        //    }
        //    set
        //    {
        //        if (value != this._optionValue)
        //        {
        //            this._optionValue = value;
        //            base.OnPropertyChanged();
        //        }
        //    }
        //}


        float _defaultValue;
        [DataSourceProperty]
        public float DefaultValue
        {
            get
            {
                return this._defaultValue;
            }
            set
            {
                if (value != this._defaultValue)
                {
                    this._defaultValue = value;
                    base.OnPropertyChanged();
                }
            }
        }

        public SelectSettingsFieldViewModel(OptionsVM parent, int initialValue, string selectableOptions)
        {
            Parent = parent;

            SelectableOption = selectableOptions.Split(',').ToList()?.Select(d => new SelectionData { Data = d }).ToList();

            IEnumerable<SelectionData> selectableOptionNames = this.GetSelectableOptionNames();
            if (selectableOptionNames.All((SelectionData n) => n.IsLocalizationId))
            {
                List<TextObject> list = new List<TextObject>();
                foreach (SelectionData selectionData in selectableOptionNames)
                {
                    TextObject item = Module.CurrentModule.GlobalTextManager.FindText(selectionData.Data, null);
                    list.Add(item);
                }
                this._selector = new SelectorVM<SelectorItemVM>(list, (int)this.Option.GetValue(), new Action<SelectorVM<SelectorItemVM>>(this.UpdateValue));
            }
            else
            {
                List<string> list2 = new List<string>();
                foreach (SelectionData selectionData2 in selectableOptionNames)
                {
                    if (selectionData2.IsLocalizationId)
                    {
                        TextObject textObject = Module.CurrentModule.GlobalTextManager.FindText(selectionData2.Data, null);
                        list2.Add(textObject.ToString());
                    }
                    else
                    {
                        list2.Add(selectionData2.Data);
                    }
                }
                this._selector = new SelectorVM<SelectorItemVM>(list2, (int)this.Option.GetValue(), new Action<SelectorVM<SelectorItemVM>>(this.UpdateValue));
            }
            this._initialValue = initialValue;
            this.Selector.SelectedIndex = this._initialValue;

        }


        public override void RefreshValues()
        {
            base.RefreshValues();
            SelectorVM<SelectorItemVM> selector = this._selector;
            if (selector == null)
            {
                return;
            }
            selector.RefreshValues();
        }


        [DataSourceProperty]
        public SelectorVM<SelectorItemVM> Selector
        {
            get
            {

                return this._selector;
            }
            set
            {
                if (value != this._selector)
                {
                    this._selector = value;
                    base.OnPropertyChanged("Selector");
                }
            }
        }


        public void UpdateValue(SelectorVM<SelectorItemVM> selector)
        {
            if (selector.SelectedIndex >= 0)
            {
                this.Option.SetValue((float)selector.SelectedIndex);
                this.Option.Commit();
                this.Parent.SetConfig(this.Option, (float)selector.SelectedIndex);
            }
        }

        public void UpdateValue()
        {
            if (this.Selector.SelectedIndex >= 0 && (float)this.Selector.SelectedIndex != this.Option.GetValue())
            {
                this.Option.Commit();
                this.Parent.SetConfig(this.Option, (float)this.Selector.SelectedIndex);
            }
        }

        public void Cancel()
        {
            if (Selector != null)
            {
                Selector.SelectedIndex = this._initialValue;
            }

            UpdateValue();
        }


        public void SetValue(float value)
        {
            if (Selector != null)
            {
                Selector.SelectedIndex = (int)value;
            }
        }

        public void ResetData()
        {
            this.Selector.SelectedIndex = (int)this.Option.GetDefaultValue();
        }

        public bool IsChanged()
        {
            return this._initialValue != this.Selector.SelectedIndex;
        }

        public int GetSelectableOptionsLimit()
        {
            return _selector.ItemList.Count();
        }

        public IEnumerable<SelectionData> GetSelectableOptionNames()
        {
            return SelectableOption;
        }

        public override object GetOptionType()
        {
            return 3;
        }

        public override object GetValue()
        {
            if (Selector == null)
            {
                return (float)-1;
            }
            return Selector.SelectedIndex;
        }

        public override object GetDefaultValue()
        {
            return _defaultValue;
        }

        public override void SetValue(object value)
        {
            SetValue((float)value);
        }

        private readonly int _initialValue;

        public SelectorVM<SelectorItemVM> _selector;
    }
}
