using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

namespace Kaynir.Audio.Tools
{
    public static class AudioExtensions
    {
        public static float GetVolume(this AudioMixer mixer, string parameter)
        {
            if (mixer.GetFloat(parameter, out float decibels))
            {
                return AudioTools.DecibelsToVolume(decibels);
            }

            Debug.LogWarning($"{parameter} is not exposed for {mixer.name}.");
            return AudioTools.MIN_VOLUME;
        }

        public static void SetVolume(this AudioMixer mixer, string parameter, float volume)
        {
            if (mixer.SetFloat(parameter, AudioTools.VolumeToDecibels(volume)))
            {
                return;
            }

            Debug.LogWarning($"{parameter} is not exposed for {mixer.name}.");
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

        public static bool IsPlaying(this AudioSource source, AudioClip clip)
        {
            if (!source.isPlaying) return false;
            return source.clip == clip;
        }
    }
}