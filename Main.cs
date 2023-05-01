using Harmony12;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityModManagerNet;
using ModifierKeybindingFixKM.Utilities;

namespace ModifierKeybindingFixKM
{
    static class Main
    {
        private static HarmonyInstance harmony;
        public static UnityModManager.ModEntry modEntry { get; private set; }

        static bool Load(UnityModManager.ModEntry modEntry)
        {
            try
            {
                // Main Variables
                Main.modEntry = modEntry;
                KMLogger.InitializeLogger(modEntry);

                // Setup Harmony
                harmony = HarmonyInstance.Create(modEntry.Info.Id);
                harmony.PatchAll();
            } 
            catch (Exception e)
            {
                throw KMLogger.Error("Unable to Load ModifierKeybindingFixKM", e);
            }
            return true;
        }
    }
}
