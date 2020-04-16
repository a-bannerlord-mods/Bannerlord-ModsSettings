using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.ModdingCommunity.ModsSettings.ViewModels;

namespace TaleWorlds.ModdingCommunity.ModsSettingsProvider
{
    //should implement any of this classess to provide settings 
    public interface ISettingsProvider<T> where T : ModSettingsViewModel
    {
        List<T> GetSettingsViewModel();

    }

    public interface ISettingsProvider : ISettingsProvider<ModSettingsViewModel>
    {



    }
}
