using System.Collections.Generic;
using UnityEngine;

namespace Kaynir.Audio
{
    public class AudioSystem : MonoBehaviour
    {
        public delegate AudioSource AudioEventHandler(AudioChannel channel);

        [SerializeField] private List<AudioChannel> _channels = new List<AudioChannel>();

        private Dictionary<AudioChannel, AudioSource> _sources;

        private void Awake()
        {
            InitializeSources();

            SoundCollection.OnSourceRequested += RetrieveSource;
            MusicSource.OnSourceRequested += RetrieveSource;
        }

        private void OnDestroy()
        {
            SoundCollection.OnSourceRequested -= RetrieveSource;
            MusicSource.OnSourceRequested -= RetrieveSource;
        }

        private void InitializeSources()
        {
            _sources = new Dictionary<AudioChannel, AudioSource>();
            _channels.ForEach(ch => _sources[ch] = CreateSource(ch));
        }

        private AudioSource CreateSource(AudioChannel channel)
        {
            AudioSource source = new GameObject(channel.name).AddComponent<AudioSource>();
            
            source.transform.SetParent(transform);
            source.outputAudioMixerGroup = channel.MixerGroup;
            source.playOnAwake = false;

            return source;
        }

        private AudioSource RetrieveSource(AudioChannel channel)
        {
            if (_sources.TryGetValue(channel, out AudioSource source)) return source;

            Debug.LogWarning($"Failed to retrieve source for [{channel}].");
            return null;
        }
    }
}