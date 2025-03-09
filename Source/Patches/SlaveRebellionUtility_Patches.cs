using HarmonyLib;
using RimWorld;
using System;
using Verse;

namespace UsefulTerror
{
    [HarmonyPatch(typeof(SlaveRebellionUtility))]
    internal static class SlaveRebellionUtility_Patches
    {
        private static bool errorAlreadyDisplayed = false;
        private static float GetAntiWeaponFactor(Pawn pawn) => Math.Min(4f, 1f + (pawn.GetStatValue(StatDefOf.Terror) * 4f));
        private static float GetAntiEscapeRouteFactor(Pawn pawn) => Math.Min(1.7f, 1f + (pawn.GetStatValue(StatDefOf.Terror) * 1.126f));
        private static float GetAntiUnattendedFactor(Pawn pawn) => 1f + (pawn.GetStatValue(StatDefOf.Terror) * 19f);

        [HarmonyPostfix]
        [HarmonyPatch("InitiateSlaveRebellionMtbDaysHelper")]
        private static void InitiateSlaveRebellionMtbDaysHelper(Pawn pawn, ref float __result)
        {
            if (__result > 0f)
            {
                if (InRoomTouchingMapEdge(pawn))
                {
                    __result *= GetAntiEscapeRouteFactor(pawn);
                }
                if (CanApplyWeaponFactor(pawn))
                {
                    __result *= GetAntiWeaponFactor(pawn);
                }
                if (SlaveRebellionUtility.IsUnattendedByColonists(pawn.Map))
                {
                    __result *= GetAntiUnattendedFactor(pawn);
                }
                __result *= Settings.RebellionMultiplier;
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch("GetSlaveRebellionMtbCalculationExplanation")]
        private static void GetSlaveRebellionMtbCalculationExplanation(Pawn pawn, ref string __result)
        {
            try
            {
                if (SlaveRebellionUtility.IsRebelling(pawn))
                    return;

                if (InRoomTouchingMapEdge(pawn))
                {
                    string escapeFactor = "SuppressionEscapeFactor".Translate();
                    int start = __result.IndexOf(escapeFactor, StringComparison.Ordinal);
                    int end = __result.IndexOf("\n", start, StringComparison.Ordinal);
                    __result = __result.Remove(start, end - start);
                    __result = __result.Insert(start, escapeFactor + ": x" + Math.Round(0.588235259f * GetAntiEscapeRouteFactor(pawn) * 100f, MidpointRounding.AwayFromZero) + "%");
                }
                if (CanApplyWeaponFactor(pawn))
                {
                    string weaponProximity = "SuppressionWeaponProximityFactor".Translate();
                    int start = __result.IndexOf(weaponProximity, StringComparison.Ordinal);
                    int end = __result.IndexOf("\n", start, StringComparison.Ordinal);
                    __result = __result.Remove(start, end - start);
                    __result = __result.Insert(start, weaponProximity + ": x" + Math.Round(0.25f * GetAntiWeaponFactor(pawn) * 100f, MidpointRounding.AwayFromZero) + "%");
                }
                if (SlaveRebellionUtility.IsUnattendedByColonists(pawn.Map))
                {
                    string unattendedFactor = "SuppressionUnattendedByColonists".Translate();
                    int start = __result.IndexOf(unattendedFactor, StringComparison.Ordinal);
                    int end = __result.IndexOf("\n", start, StringComparison.Ordinal);
                    __result = __result.Remove(start, end - start);
                    __result = __result.Insert(start, unattendedFactor + ": x" + Math.Round(0.05f * GetAntiUnattendedFactor(pawn) * 100f, MidpointRounding.AwayFromZero) + "%");
                }
                if (Settings.RebellionMultiplier != 1f)
                {
                    string finalInterval = "SuppressionFinalInterval".Translate();
                    int start = __result.IndexOf(finalInterval, StringComparison.Ordinal);
                    __result = __result.Insert(start, "UsefulTerror_Title".Translate() + ": x" + Math.Round(Settings.RebellionMultiplier * 100f, MidpointRounding.AwayFromZero) + "%\n");
                }
            }
            catch (Exception)
            {
                if (!errorAlreadyDisplayed)
                {
                    errorAlreadyDisplayed = true;
                    Log.Error($"Error: [Useful Terror: Failed to update tooltip:");
                    throw;
                }
            }
        }

        //Reverse patch to access private method
        [HarmonyReversePatch]
        [HarmonyPatch("CanApplyWeaponFactor")]
        private static bool CanApplyWeaponFactor(Pawn pawn)
        {
            throw new NotImplementedException("It's a stub");
        }

        //Reverse patch to access private method
        [HarmonyReversePatch]
        [HarmonyPatch("InRoomTouchingMapEdge")]
        private static bool InRoomTouchingMapEdge(Pawn pawn)
        {
            throw new NotImplementedException("It's a stub");
        }
    }
}