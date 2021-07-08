using TaleWorlds.Library;

namespace TaleWorlds.ModdingCommunity.ModsSettingsProvider.SettingsFieldTypes
{
    public class BooleanSettingsFieldViewModel : SettingsField
    {
        private bool _optionValue;

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
}