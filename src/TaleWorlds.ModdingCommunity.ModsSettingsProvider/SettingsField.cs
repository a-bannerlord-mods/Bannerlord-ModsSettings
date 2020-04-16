using TaleWorlds.Engine.Options;
using TaleWorlds.Library;

namespace TaleWorlds.ModdingCommunity.ModsSettingsProvider
{
    public class BooleanSettingsFieldViewModel : SettingsField
    {
        private bool _optionValue;

        // Token: 0x06000C3C RID: 3132 RVA: 0x0002A1D4 File Offset: 0x000283D4
        //public BooleanOptionDataVM(OptionsVM optionsVM, IBooleanOptionData option, TextObject name, TextObject description) : base(optionsVM, option, name, description, OptionsVM.OptionsDataType.BooleanOption)
        //{
        //	this._booleanOptionData = option;
        //	this._initialValue = option.GetValue().Equals(1f);
        //	this.OptionValueAsBoolean = this._initialValue;
        //}

        // Token: 0x17000418 RID: 1048
        // (get) Token: 0x06000C3D RID: 3133 RVA: 0x0002A219 File Offset: 0x00028419
        // (set) Token: 0x06000C3E RID: 3134 RVA: 0x0002A221 File Offset: 0x00028421
        [DataSourceProperty]
        public bool OptionValueAsBoolean
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
                    base.OnPropertyChanged("OptionValueAsBoolean");

                }
            }
        }

        public override object GetDefaultValue()
        {
            return default(bool);
        }

        public override object GetValue()
        {
            return OptionValueAsBoolean;
        }

        public override void SetValue(object value)
        {
            OptionValueAsBoolean = (bool)value;
        }
    }

    public abstract class SettingsField : ViewModel, IOptionData
    {
        protected IOptionData Option;

        public SettingsField()
        {
            Option = this;
        }

        public string Key { get; set; }

        [DataSourceProperty]
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                if (value != this._name)
                {
                    this._name = value;
                    base.OnPropertyChanged("Name");
                }
            }
        }
        private string _description;


        private string _name;


        [DataSourceProperty]
        public string Description
        {
            get
            {
                return this._description;
            }
            set
            {
                if (value != this._description)
                {
                    this._description = value;
                    base.OnPropertyChanged("Description");
                }
            }
        }
        public bool IsHidden { get; set; }

        public void Commit()
        {

        }

        float IOptionData.GetDefaultValue()
        {
            return (float)this.GetDefaultValue();
        }

        public object GetOptionType()
        {
            return 0;
        }


        public bool IsNative()
        {
            return false;
        }



        public void SetValue(float value)
        {
            SetValue(value);
        }

        float IOptionData.GetValue()
        {
            return (float)GetValue();
        }

        public abstract object GetValue();
        public abstract object GetDefaultValue();
        public abstract void SetValue(object value);

        public override void RefreshValues()
        {
            base.RefreshValues();

        }




    }
}