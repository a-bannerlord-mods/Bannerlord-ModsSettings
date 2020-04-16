using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.ModdingCommunity.ModsSettings.ViewModels;
using TaleWorlds.ModdingCommunity.ModsSettingsProvider;

namespace TaleWorlds.ModdingCommunity.ModsSettings.XMLDefined
{
    public class XMLDefinedSettingsProvider : ISettingsProvider
    {
        public List<ModSettingsViewModel> GetSettingsViewModel()
        {
            //
            return new List<ModSettingsViewModel>();
        }
    }
}
