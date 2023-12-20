using System;
using System.Reflection;
using UnityEngine;
using Unity;
using ProwlerBracken;
using ProwlerBracken.AssetManagement;

namespace ProwlerBracken.Libraries
{
    internal class ProwlerBehavior : MonoBehaviour
    {
        private AudioSource AmbienceSource;
        public const float PLAY_INTERVAL_MIN = 15f;
        public const float PLAY_INTERVAL_MAX = 40f;
        public const float MAX_AUDIO_DIST = 100f;
        private float NextAudioTime;
        private EnemyAI ProwlerAI;

        public void Initialize(EnemyAI ProwlerAI)
        {
            this.ProwlerAI = ProwlerAI;
            this.AmbienceSource = ProwlerAI.creatureVoice;
            this.SetNextTime();
        }

        private void Update()
        {
            if ((double) Time.time > this.NextAudioTime)
            {
                this.SetNextTime();

                AudioClip AmbienceClip = Assets.GetRandomAmbienceSFX();
                ProwlerBrackenBase.LogInfo("Played ambience audio " + AmbienceClip.name);
                this.AmbienceSource.PlayOneShot(AmbienceClip);
            }
        }

        private void SetNextTime()
        {
            this.NextAudioTime = Time.time + UnityEngine.Random.Range(PLAY_INTERVAL_MIN, PLAY_INTERVAL_MAX);
        }
    }
}
