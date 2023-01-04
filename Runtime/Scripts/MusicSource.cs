using System.Collections;
using UnityEngine;
using static Kaynir.Audio.AudioSystem;

namespace Kaynir.Audio
{
    public class MusicSource : MonoBehaviour
    {
        public static event AudioEventHandler OnSourceRequested;

        [SerializeField] private AudioChannel _channel = null;
        [SerializeField] private AudioClip _clip = null;
        [SerializeField, Range(0f, 1f)] private float _volume = 1f;
        [SerializeField, Min(0f)] private float _fadeTime = 1f;
        [SerializeField] private bool _loop = true;
        [SerializeField] private bool _playOnStart = true;

        private void Start()
        {
            if (_playOnStart) PlayMusic();
        }

        [ContextMenu("Play Music")]
        public void PlayMusic()
        {
            AudioSource source = OnSourceRequested?.Invoke(_channel); 
            if (!source) return;

            StopAllCoroutines();
            StartCoroutine(PlayRoutine(source));
        }

        private IEnumerator PlayRoutine(AudioSource source)
        {
            yield return source.FadeVolumeRoutine(AudioConstants.MIN_VOLUME, _fadeTime);

            source.Stop();
            source.clip = _clip;
            source.loop = _loop;
            source.Play();

            yield return source.FadeVolumeRoutine(_volume, _fadeTime);
        }
    }
}