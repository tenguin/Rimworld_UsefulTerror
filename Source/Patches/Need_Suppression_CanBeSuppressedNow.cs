using HarmonyLib;
using RimWorld;

namespace UsefulTerror
{
    [HarmonyPatch(typeof(Need_Suppression), "CanBeSuppressedNow", MethodType.Getter)]
    internal static class Need_Suppression_CanBeSuppressedNow
    {
        [HarmonyPostfix]
        private static void CanBeSuppressedNow(ref Need_Suppression __instance, ref bool __result)
        {
            if (__instance.CurLevel < 0.8f)
                __result = true;
        }
    }
}
