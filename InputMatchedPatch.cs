using Harmony12;
using Kingmaker.GameModes;
using Kingmaker.UI;
using ModifierKeybindingFixKM.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Kingmaker.UI.KeyboardAccess;
using UnityEngine;

namespace ModifierKeybindingFixKM
{

    [HarmonyPatch(typeof(Binding), "InputMatched")]
    internal class InputMatchedPatch
    {
        static bool Prefix(Binding __instance, ref bool __result)
        {
            if (!(__instance.TriggerOnRelease ? Input.GetKeyUp(__instance.Key) : Input.GetKeyDown(__instance.Key)))
            {
                __result = false;
                return false;
            }

            if (__instance.Key != KeyCode.LeftShift && __instance.Key != KeyCode.RightShift && __instance.IsShiftDown != IsShiftHold(__instance.Side))
            {
                __result = false;
                return false;
            }

            if (__instance.Key != KeyCode.LeftControl && __instance.Key != KeyCode.RightControl && __instance.IsCtrlDown != IsCtrlHold(__instance.Side))
            {
                __result = false;
                return false;
            }

            if (__instance.Key != KeyCode.LeftAlt && __instance.Key != KeyCode.RightAlt && __instance.Key != KeyCode.AltGr && __instance.IsAltDown != IsAltHold(__instance.Side))
            {
                __result = false;
                return false;
            }
            __result = true;
            return false; // False so the original method is replaced
        }
    }
}
