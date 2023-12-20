using BepInEx;
using ProwlerBracken.AssetManagement;
using ProwlerBracken.Patches;
using HarmonyLib;
using UnityEngine;

namespace ProwlerBracken
{
    [BepInPlugin("Danninx.Prowler", "Prowler Bracken", "0.0.1")]
    public class ProwlerBrackenBase : BaseUnityPlugin
    {
        private static ProwlerBrackenBase _instance;

        private readonly Harmony Harmony = new Harmony("Danninx.Prowler");

        internal static ProwlerBrackenBase Instance
        {
            get
            {
                return _instance;
            }
            set
            {
                if ((Object)(object)_instance == (Object)null)
                {
                    _instance = value;
                }
                else
                {
                    Object.Destroy((Object)(object)value);
                }
            }
        }

        void Awake()
        {
            Instance = this;
            Assets.PopulateAssets(((ProwlerBrackenBase)this).Logger);
            ((ProwlerBrackenBase)this).Logger.LogError((object)"You're the best of all of us Miles...");
            Harmony.PatchAll(typeof(ProwlerBrackenBase));
            Harmony.PatchAll(typeof(BrackenPatch));
        }

        internal static void LogInfo(object message)
        {
            ((ProwlerBrackenBase)Instance).Logger.LogInfo(message);
        }

        internal static void LogWarning(object message)
        {
            ((ProwlerBrackenBase)Instance).Logger.LogWarning(message);
        }

        internal static void LogError(object message)
        {
            ((ProwlerBrackenBase)Instance).Logger.LogError(message);
        }
    }


    public static class PluginInfo
    {
        public const string GUID = "Danninx.Prowler";
        public const string NAME = "Prowler Bracken";
        public const string VERSION = "0.0.1";
        public const string ASSET_BUNDLE_NAME = "prowleraudio";
    }
}
