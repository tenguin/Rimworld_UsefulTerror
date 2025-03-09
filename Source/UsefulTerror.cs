using HarmonyLib;
using UnityEngine;
using Verse;

namespace UsefulTerror
{
	public class UsefulTerror : Mod
	{
		public UsefulTerror(ModContentPack content) : base(content)
		{
			Harmony harmony = new Harmony(content.PackageId);
			harmony.PatchAll();
            GetSettings<Settings>();
        }
        public override string SettingsCategory()
        {
            return "UsefulTerror_Title".Translate();
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            Settings.DoWindowContents(inRect);
        }
    }
}
