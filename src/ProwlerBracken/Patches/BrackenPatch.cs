using HarmonyLib;
using ProwlerBracken;
using ProwlerBracken.AssetManagement;
using ProwlerBracken.Libraries;

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

            // Change bracken kill noise
            __instance.crackNeckAudio.clip = Assets.ProwlerKill;
            __instance.crackNeckSFX = Assets.ProwlerKill;

            __instance.gameObject.AddComponent<ProwlerBehavior> ().Initialize(__instance);

            ProwlerBrackenBase.LogInfo("Prowler initiated.");
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
    