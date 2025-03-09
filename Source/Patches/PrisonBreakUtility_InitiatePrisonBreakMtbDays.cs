using HarmonyLib;
using Verse;
using RimWorld;
using System.Text;

namespace UsefulTerror
{
    [HarmonyPatch(typeof(PrisonBreakUtility), "InitiatePrisonBreakMtbDays")]
    internal static class PrisonBreakUtility_InitiatePrisonBreakMtbDays
    {
        [HarmonyPostfix]
        private static void InitiatePrisonBreakMtbDays(ref float __result, Pawn pawn, StringBuilder sb = null, bool ignoreAsleep = false)
        {
            __result *= Settings.PrisonBreakMultiplier;
            if (sb != null)
            {
                sb.AppendLineIfNotEmpty();
                sb.Append("  - " + "UsefulTerror_Title".Translate() + ": " + Settings.PrisonBreakMultiplier.ToStringPercent());
            }
        }
    }
}