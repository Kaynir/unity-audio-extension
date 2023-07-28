using System.Collections.Generic;
using Kaynir.Audio.Filters;
using Kaynir.Audio.Tools;
using UnityEngine;

namespace Kaynir.Audio
{
    [CreateAssetMenu(menuName = AssetMenuTools.MAIN_PATH + "Sound Asset")]
    public class SoundAsset : ScriptableObject
    {
        [SerializeField] private List<AudioClip> variants = new List<AudioClip>();
        [SerializeField] private List<AudioSourceFilter> filters = new List<AudioSourceFilter>();

        public void Play(AudioSource source, AudioClip clip)
        {
            ApplyFilters(source);
            source.clip = clip;
            source.Play();
        }

        public void Play(AudioSource source)
        {
            Play(source, GetAudioClip());
        }

        public void PlayOneShot(AudioSource source, AudioClip clip)
        {
            ApplyFilters(source);
            source.PlayOneShot(clip);
        }

        public void PlayOneShot(AudioSource source)
        {
            PlayOneShot(source, GetAudioClip());
        }

        public AudioClip GetAudioClip(int index)
        {
            return variants[index];
        }

        public AudioClip GetAudioClip()
        {
            int index = Random.Range(0, variants.Count);
            return GetAudioClip(index);
        }

        private void ApplyFilters(AudioSource source)
        {
            filters.ForEach(f => f.Apply(source));
        }
    }
}