using UnityEngine;

namespace Kaynir.Audio.Tools
{
    public static class AudioTools
    {
        public static float MIN_DECIBELS = -80f;
        public static float MAX_DECIBELS = 0f;

        public static float MIN_VOLUME = 0f;
        public static float MAX_VOLUME = 1f;

        public static float VolumeToDecibels(float volume)
        {
            return Mathf.Lerp(MIN_DECIBELS, MAX_DECIBELS, volume);
        }

        public static float DecibelsToVolume(float decibels)
        {
            return Mathf.InverseLerp(MIN_DECIBELS, MAX_DECIBELS, decibels);
        }
    }
}