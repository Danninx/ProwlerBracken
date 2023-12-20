using HarmonyLib;
using ProwlerBracken.AssetManagement;

namespace ProwlerBracken.Patches
{
    [HarmonyPatch(typeof(FlowermanAI))]
    internal class BrackenPatch
    {
        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        public static void ChangeBrackenSounds(FlowermanAI __instance)
        {
            // Bracken angry
            __instance.creatureAngerVoice.clip = Assets.ProwlerChase;
            
            // Bracken spotted
            __instance.creatureVoice.clip = Assets.ProwlerAmbient2;

            // ??
            __instance.creatureSFX.clip = Assets.ProwlerAmbient1;

            // Change bracken kill noise
            __instance.crackNeckAudio.clip = Assets.ProwlerKill;
            __instance.crackNeckSFX = Assets.ProwlerKill;


        }

        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        public static void DisableRandomPitch(FlowermanAI __instance)
        {
            // Disable random pitch
            __instance.creatureAngerVoice.pitch = 1f;

            // Disable audio distortion
        }
    }
}
    