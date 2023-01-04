using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

namespace Kaynir.Audio
{
    public static class AudioExtensions
    {
        public static void SetVolume(this AudioMixer mixer, string parameter, float volume)
        {
            if (mixer.SetFloat(parameter, VolumeToDecibels(volume))) return;

            Debug.LogWarning($"{parameter} is not exposed for {mixer.name}.");
        }

        public static float GetVolume(this AudioMixer mixer, string parameter)
        {
            if (mixer.GetFloat(parameter, out float decibels))
            {
                return DecibelsToVolume(decibels);
            }

            Debug.LogWarning($"{parameter} is not exposed for {mixer.name}.");
            return AudioConstants.MIN_VOLUME;
        }

        public static float VolumeToDecibels(float volume)
        {
            return Mathf.Lerp(AudioConstants.MIN_DECIBELS,
                              AudioConstants.MAX_DECIBELS,
                              volume);
        }

        public static float DecibelsToVolume(float decibels)
        {
            return Mathf.InverseLerp(AudioConstants.MIN_DECIBELS,
                                     AudioConstants.MAX_DECIBELS,
                                     decibels);
        }

        public static IEnumerator FadeVolumeRoutine(this AudioSource source, float endVolume, float seconds)
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