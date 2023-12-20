using System.IO;
using System.Reflection;
using UnityEngine;

namespace ProwlerBracken.AssetManagement
{
    public static class Assets
    {
        public static AssetBundle AssetBundle { get; private set; }
        
        public static AudioClip ProwlerKill {  get; private set; }
        public static AudioClip ProwlerAmbient1 { get; private set; }
        public static AudioClip ProwlerAmbient2 { get; private set; }
        public static AudioClip ProwlerChase { get; private set; }

        private static string GetAssemblyName()
		{
            return Assembly.GetExecutingAssembly().FullName.Split(',')[0];
        }
        //ProwlerBracken.AssetManagement
        public static void PopulateAssets()
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
                
                ProwlerKill = Assets.AssetBundle.LoadAsset<AudioClip>("Assets/ProwlerKill.mp3");
                ProwlerAmbient1 = Assets.AssetBundle.LoadAsset<AudioClip>("Assets/ProwlerAmbient1.mp3");
                ProwlerAmbient2 = Assets.AssetBundle.LoadAsset<AudioClip>("Assets/ProwlerAmbient2.mp3");
                ProwlerChase = Assets.AssetBundle.LoadAsset<AudioClip>("Assets/ProwlerChase.mp3");
            }
        }
    }
}
