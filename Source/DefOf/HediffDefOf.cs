using RimWorld;
using Verse;

namespace UsefulTerror
{
    [DefOf]
    public static class HediffDefOf
    {
        public static HediffDef UsefulTerror_HeartAcidifier;

        static HediffDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(HediffDefOf));
        }
    }
}
