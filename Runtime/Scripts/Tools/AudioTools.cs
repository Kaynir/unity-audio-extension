using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

namespace Kaynir.Audio.Tools
{
    public static class AudioTools
    {
        public static float MIN_DECIBELS = -80f;
        public static float MAX_DECIBELS = 0f;

        public static float MIN_VOLUME = 0f;
        public static float MAX_VOLUME = 1f;

        public static float GetVolume(this AudioMixer mixer, string parameter)
        {
            if (mixer.GetFloat(parameter, out float decibels))
            {
                return DecibelsToVolume(decibels);
            }

            Debug.LogWarning($"{parameter} is not exposed for {mixer.name}.");
            return MIN_VOLUME;
        }

        public static void SetVolume(this AudioMixer mixer, string parameter, float volume)
        {
            if (mixer.SetFloat(parameter, VolumeToDecibels(volume))) return;

            Debug.LogWarning($"{parameter} is not exposed for {mixer.name}.");
        }

        public static float VolumeToDecibels(float volume)
        {
            return Mathf.Lerp(MIN_DECIBELS, MAX_DECIBELS, volume);
        }

        public static float DecibelsToVolume(float decibels)
        {
            return Mathf.InverseLerp(MIN_DECIBELS, MAX_DECIBELS, decibels);
        }

        public static IEnumerator LerpVolumeRoutine(this AudioSource source, float endVolume, float seconds)
        {
            float startVolume = source.volume;

            for (float t = 0; t < seconds; t += Time.deltaTime)
            {
                source.volume = Mathf.Lerp(startVolume, endVolume, t / seconds);
                yield return null;
            }

            source.volume = endVolume;
        }
    }
}