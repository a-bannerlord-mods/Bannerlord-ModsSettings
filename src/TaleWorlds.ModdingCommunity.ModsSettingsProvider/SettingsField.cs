using TaleWorlds.Engine.Options;
using TaleWorlds.Library;

namespace TaleWorlds.ModdingCommunity.ModsSettingsProvider
{

    public abstract class SettingsField : ViewModel, IOptionData
    {
        protected IOptionData Option;

        object _optionTypeID;
        [DataSourceProperty]
        public object OptionTypeID
        {
            get
            {
                return this._optionTypeID;
            }
            set
            {
                if (value != this._optionTypeID)
                {
                    this._optionTypeID = value;
                    base.OnPropertyChanged();
                }
            }
        }
        public SettingsField()
        {
            Option = this;
            OptionTypeID = this.GetOptionType();
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

        public abstract object GetOptionType();



        public bool IsNative()
        {
            return false;
        }



        void IOptionData.SetValue(float value)
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