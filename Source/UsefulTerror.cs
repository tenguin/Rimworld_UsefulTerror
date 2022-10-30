using HarmonyLib;
using Verse;

namespace UsefulTerror
{
	public class UsefulTerror : Mod
	{
		public UsefulTerror(ModContentPack content) : base(content)
		{
			Harmony harmony = new Harmony(content.PackageId);
			harmony.PatchAll();
			/*
			TerrorUtility.SuppressionFallRateOverTerror = new SimpleCurve
			{
				new CurvePoint(0f, 0f),
				new CurvePoint(25f, -5f),
				new CurvePoint(50f, -10f),
				new CurvePoint(75f, -15f),
				new CurvePoint(100f, -20f)
			};*/
		}
	}
}
