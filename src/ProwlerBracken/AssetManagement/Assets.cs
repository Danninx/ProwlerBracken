using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using BepInEx.Logging;

namespace ProwlerBracken.AssetManagement
{
    public static class Assets
    {
        public static AssetBundle AssetBundle { get; private set; }
        
        public static AudioClip ProwlerKill {  get; private set; }

        public static List<AudioClip> ProwlerAmbienceSFX { get; private set; }
        public static AudioClip ProwlerChase { get; private set; }

        private static string GetAssemblyName()
		{
            return Assembly.GetExecutingAssembly().FullName.Split(',')[0];
        }
        //ProwlerBracken.AssetManagement
        public static void PopulateAssets(ManualLogSource ModLogger)
        {
            if ((Object)(object)AssetBundle != (Object)null)
            {
                return;
            }
            else
            {
                string name = Assets.GetAssemblyName() + ".AssetManagement.prowleraudio";
                using (Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(name))
                {
                    Assets.AssetBundle = AssetBundle.LoadFromStream(manifestResourceStream);
                }
                
                // Kill & chase sounds
                ProwlerKill = Assets.AssetBundle.LoadAsset<AudioClip>("Assets/ProwlerKill.mp3");
                ProwlerChase = Assets.AssetBundle.LoadAsset<AudioClip>("Assets/ProwlerChase.mp3");

                // Ambience sounds
                ProwlerAmbienceSFX = new List<AudioClip>();
                ModLogger.LogInfo("Prowler ambience clips loaded.");
                foreach (string AssetName in Assets.AssetBundle.GetAllAssetNames())
                {
                    string[] SubNames = AssetName.Split('/');
                    if (SubNames[1] == "ambiencesfx")
                    {
                        AudioClip AmbienceClip = Assets.AssetBundle.LoadAsset<AudioClip>(AssetName);
                        ProwlerAmbienceSFX.Add(AmbienceClip);
                    }
                }
            }
        }

        public static AudioClip GetRandomAmbienceSFX()
        {
            if (ProwlerAmbienceSFX.Count == 0) 
            { 
                return (AudioClip) null; 
            }

            int index = UnityEngine.Random.Range(0, ProwlerAmbienceSFX.Count - 1);
            AudioClip ChosenAmbience = ProwlerAmbienceSFX[index];

            return ChosenAmbience;
        }
    }
}
