using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml.Linq;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace TaleWorlds.ModdingCommunity.ModsSettings
{
    public class ModsSettingsSubModule : MBSubModuleBase
    {
    
        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();
            new Harmony("MBModsSettings.Patches").PatchAll();
        }


    }
}
