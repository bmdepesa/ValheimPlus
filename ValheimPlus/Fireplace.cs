﻿using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValheimPlus 
{
    class FireplaceFuel 
    {
        [HarmonyPatch(typeof(Fireplace), "UpdateFireplace")]
        public static class TorchesNoFuel 
        {
            private static void Postfix(Fireplace __instance, ref ZNetView ___m_nview) 
            {
                if (Settings.isEnabled("Fireplace"))
	            {
		            if (Settings.getBool("Fireplace", "onlyTorches"))
	                {
		                if (__instance.GetHoverText().Contains("torch") || __instance.GetHoverText().Contains("Scounce") || __instance.GetHoverText().Contains("brazier")) 
                        {
                            ___m_nview.GetZDO().Set("fuel", 1f);
                        }  
	                } 
                    else
                    {
                        ___m_nview.GetZDO().Set("fuel", 1f);
                    }
	            }

            }
        }
    }
}
