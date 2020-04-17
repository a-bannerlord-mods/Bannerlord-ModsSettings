using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.Engine.Options;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.ViewModelCollection.GameOptions;

namespace TaleWorlds.ModdingCommunity.ModsSettingsProvider.SettingsFieldTypes
{
    public class NumericSettingsFieldViewModel : SettingsField, INumericOptionData
    {


        public OptionsVM Parent { get; set; }
        public NumericSettingsFieldViewModel(OptionsVM parent)
        {
            Parent = parent;
        }

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


        [DataSourceProperty]
        public float Min
        {
            get
            {
                return this._min;
            }
            set
            {
                if (value != this._min)
                {
                    this._min = value;
                    base.OnPropertyChanged("Min");
                }
            }
        }


        [DataSourceProperty]
        public float Max
        {
            get
            {
                return this._max;
            }
            set
            {
                if (value != this._max)
                {
                    this._max = value;
                    base.OnPropertyChanged("Max");
                }
            }
        }

        [DataSourceProperty]
        public float OptionValue
        {
            get
            {
                return this._optionValue;
            }
            set
            {
                if (value != this._optionValue)
                {
                    this._optionValue = value;
                    base.OnPropertyChanged("OptionValue");
                    base.OnPropertyChanged("OptionValueAsString");
                    this.UpdateValue();
                }
            }
        }


        [DataSourceProperty]
        public bool IsDiscrete
        {
            get
            {
                return this._isDiscrete;
            }
            set
            {
                if (value != this._isDiscrete)
                {
                    this._isDiscrete = value;
                    base.OnPropertyChanged("IsDiscrete");
                }
            }
        }


        [DataSourceProperty]
        public string OptionValueAsString
        {
            get
            {
                if (!this.IsDiscrete)
                {
                    return this._optionValue.ToString("F");
                }
                return ((int)this._optionValue).ToString();
            }
        }


        public void UpdateValue()
        {
            this.Option.SetValue(this.OptionValue);
            this.Option.Commit();
            this.Parent.SetConfig(this.Option, this.OptionValue);
        }




        public bool IsChanged()
        {
            return this._initialValue != this.OptionValue;
        }

        public float GetMinValue()
        {
            return Min;
        }

        public float GetMaxValue()
        {
            return Max;
        }
        public bool GetIsDiscrete()
        {
            return IsDiscrete;
        }

        public override object GetValue()
        {
            return OptionValue;
        }

        public override object GetDefaultValue()
        {
            return this.DefaultValue;
        }

        public override void SetValue(object value)
        {
            OptionValue = (float)value;
        }

        public override object GetOptionType()
        {
            return 1;
        }

        private readonly float _initialValue;
        private float _defaultValue;
        private float _min;
        private float _max;
        private float _optionValue;
        private bool _isDiscrete;
    }
}
