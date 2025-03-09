using System;
using UnityEngine;
using Verse;

namespace UsefulTerror
{
    internal partial class Settings : ModSettings
    {
        internal static void DoWindowContents(Rect inRect)
        {
            //30f for top page description and bottom close button
            Rect viewRect = new Rect(0f, 30f, inRect.width, inRect.height - 30f);

            Listing_Standard listingStandard = new Listing_Standard();
            listingStandard.ColumnWidth = viewRect.width;
            listingStandard.Begin(viewRect);
            listingStandard.Gap(5f);

            listingStandard.Label("UsefulTerror_RebellionMultiplier".Translate() + ": " + Mathf.RoundToInt(RebellionMultiplier * 100f) + "%");
            RebellionMultiplier = (float) Math.Round(listingStandard.Slider(RebellionMultiplier, 0.1f, 10f), 1, MidpointRounding.AwayFromZero);

            listingStandard.Label("UsefulTerror_PrisonBreakMultiplier".Translate() + ": " + Mathf.RoundToInt(PrisonBreakMultiplier * 100f) + "%");
            PrisonBreakMultiplier = (float)Math.Round(listingStandard.Slider(PrisonBreakMultiplier, 0.1f, 10f), 1, MidpointRounding.AwayFromZero);

            listingStandard.Gap(400f);
            if (listingStandard.ButtonText("UsefulTerror_ResetAll".Translate()))
            {
                Initialize();
            }
            listingStandard.End();
        }
    }
}
