using HarmonyLib;
using RimWorld;
using Verse;

namespace UsefulTerror
{
    [HarmonyPatch(typeof(TerrorUtility))]
    internal static class TerrorUtility_Patches
    {
        /* Obsolete reason: No real reason to limit it to only top 3 terror objects like Vanilla. Pointlessly wasting performance when this is called every few ticks per pawn
        [HarmonyPostfix]
        [HarmonyPatch("GetTerrorThoughts")]
        private static void GetTerrorThoughts(Pawn pawn, ref IEnumerable<Thought_MemoryObservationTerror> __result)
        {
            __result = TerrorUtility.TakeTopTerrorThoughts(__result);
        }*/

        [HarmonyPostfix]
        [HarmonyPatch("GetTerrorLevel")]
        private static void GetTerrorLevel(Pawn pawn, ref float __result)
        {
            if (pawn.IsSlave && pawn.health.hediffSet.HasHediff(HediffDefOf.UsefulTerror_HeartAcidifier))
            {
                __result = 1f;
            }
        }
    }
}
