using System;
using System.Collections.Generic;
using Kaynir.Audio.Modules;
using UnityEngine;

namespace Kaynir.Audio
{
    [Serializable]
    public class Sound
    {
        [SerializeField] private AudioClip clip = null;
        [SerializeField] private AudioSource source = null;
        [SerializeField] private List<AudioModule> modules = new List<AudioModule>();

        public Sound(AudioClip clip, AudioSource source, List<AudioModule> modules)
        {
            this.clip = clip;
            this.source = source;
            this.modules = modules;
        }

        public Sound() : this(null, null, new List<AudioModule>()) { }

        public void Play()
        {
            ConfigureSource();
            source.Play();
        }

        public void PlayOneShot()
        {
            ConfigureSource();
            source.PlayOneShot(source.clip);
        }

        private void ConfigureSource()
        {
            source.clip = clip;
            source.loop = false;
            modules.ForEach(m => m.Apply(source));
        }
    }
}