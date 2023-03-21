using System.Collections.Generic;
using UnityEngine;

namespace Kaynir.Audio
{
    public class AudioSystem : MonoBehaviour
    {
        private static AudioSystem _instance;
        private static Dictionary<AudioChannel, AudioSource> _sources;

        public static void Init()
        {
            if (_instance) Destroy(_instance.gameObject);

            _instance = new GameObject("AudioSystem").AddComponent<AudioSystem>();
            _sources = new Dictionary<AudioChannel, AudioSource>();

            DontDestroyOnLoad(_instance.gameObject);
        }

        public static AudioSource GetAudioSource(AudioChannel channel)
        {
            if (!_sources.ContainsKey(channel))
            {
                _sources[channel] = CreateAudioSource(channel);
            }

            return _sources[channel];
        }

        private static AudioSource CreateAudioSource(AudioChannel channel)
        {
            AudioSource source = new GameObject(channel.name).AddComponent<AudioSource>();

            source.transform.SetParent(_instance.transform);
            source.outputAudioMixerGroup = channel.MixerGroup;
            source.playOnAwake = false;

            return source;
        }
    }
}