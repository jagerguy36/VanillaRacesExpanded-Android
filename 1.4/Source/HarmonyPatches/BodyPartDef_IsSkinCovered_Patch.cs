﻿using HarmonyLib;
using Verse;

namespace VREAndroids
{
    [HarmonyPatch(typeof(BodyPartDef), "IsSkinCovered")]
    public static class BodyPartDef_IsSkinCovered_Patch
    {
        public static bool Prefix(BodyPartDef __instance, ref bool __result, BodyPartRecord part, HediffSet body)
        {
            if (body.pawn.HasActiveGene(VREA_DefOf.VREA_SyntheticBody))
            {
                __result = __instance.skinCovered;
                return false;
            }
            return true;
        }
    }
}
