using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace UsefulTerror
{
    [HarmonyPatch(typeof(PawnObserver), "ObserveSurroundingThings")]
    internal static class PawnObserver_ObserveSurroundingThings
    {
        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var codes = new List<CodeInstruction>(instructions);
            for (var i = 0; i < codes.Count; i++)
            {
                if (codes[i].opcode == OpCodes.Call)
                {
                    MethodInfo operand = (MethodInfo)codes[i].operand;
                    if (operand.Name.Equals("RemoveAllTerrorThoughts", StringComparison.Ordinal))
                    {
                        codes[i - 2].opcode = OpCodes.Nop;
                        codes[i - 1].opcode = OpCodes.Nop;
                        codes[i].opcode = OpCodes.Nop;
                        break;
                    }
                }
            }
            return codes.AsEnumerable();
        }
    }
}