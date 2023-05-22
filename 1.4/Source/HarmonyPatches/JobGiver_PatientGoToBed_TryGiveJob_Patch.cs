﻿using HarmonyLib;
using RimWorld;
using Verse;
using Verse.AI;

namespace VREAndroids
{
    [HarmonyPatch(typeof(JobGiver_PatientGoToBed), "TryGiveJob")]
    public static class JobGiver_PatientGoToBed_TryGiveJob_Patch
    {
        public static void Postfix(ref Job __result, Pawn pawn)
        {
            if (__result != null && pawn.IsAndroid()) 
            {
                if (JobDriver_RepairAndroid.CanRepairAndroid(pawn) is false 
                    && pawn.health.hediffSet.GetFirstHediffOfDef(VREA_DefOf.VREA_NeutroLoss) != null)
                {
                    if (__result.targetA.Thing is not Building_NeutroCasket)
                    {
                        __result = null;
                    }
                }
            }
        }
    }
}
