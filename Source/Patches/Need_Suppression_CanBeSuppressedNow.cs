using HarmonyLib;
using RimWorld;
using Verse;

namespace UsefulTerror
{
    [HarmonyPatch(typeof(Need_Suppression), "CanBeSuppressedNow", MethodType.Getter)]
    internal static class Need_Suppression_CanBeSuppressedNow
    {
        [HarmonyPostfix]
        private static void CanBeSuppressedNow(ref Need_Suppression __instance, ref Pawn ___pawn, ref bool __result)
        {
            if(___pawn.GetStatValue(StatDefOf.SlaveSuppressionFallRate) <= 0f && __instance.CurLevel < 1f)
            {
                __result = true;
            }
            else if (__instance.CurLevel < 0.9f)
                __result = true;
        }
    }
}
