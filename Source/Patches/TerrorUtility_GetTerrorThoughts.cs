using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using Verse;

namespace UsefulTerror
{
    [HarmonyPatch(typeof(TerrorUtility))]
    internal static class TerrorUtility_GetTerrorThoughts
    {
        [HarmonyPostfix]
        [HarmonyPatch("GetTerrorThoughts")]
        private static void GetTerrorThoughts(Pawn pawn, ref IEnumerable<Thought_MemoryObservationTerror> __result)
        {
            __result = TerrorUtility.TakeTopTerrorThoughts(__result);
            //Log.Message($"CROSS MOD SUPPORT: {UncompromisingFires.UncompromisingFires.GetGUIDrynessLabel()} {UncompromisingFires.UncompromisingFires.GetGUITooltipLabel()}");
        }
    }
}
