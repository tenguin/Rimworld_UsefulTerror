using Verse;

namespace UsefulTerror
{
    internal partial class Settings : ModSettings
    {
        public static float RebellionMultiplier;
        public static float PrisonBreakMultiplier;

        private static void Initialize()
        {
            RebellionMultiplier = 1f;
            PrisonBreakMultiplier = 1f;
        }
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref RebellionMultiplier, "RebellionMultiplier", 1f);
            Scribe_Values.Look(ref PrisonBreakMultiplier, "PrisonBreakMultiplier", 1f);
        }
        public Settings()
        {
            Initialize();
        }
    }
}
