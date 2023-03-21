using System.Collections;
using UnityEngine;

namespace Kaynir.Audio
{
    public class MusicSource : MonoBehaviour
    {
        [SerializeField] private AudioChannel _channel = null;
        [SerializeField] private AudioClip _clip = null;

        [Header("Fade Settings:")]
        [SerializeField, Min(0f)] private float _fadeTime = 1f;
        [SerializeField, Range(0f, 1f)] private float _volume = 1f;

        [Header("Play Settings:")]
        [SerializeField] private bool _loop = true;
        [SerializeField] private bool _allowRestart = false;
        [SerializeField] private bool _playOnStart = true;

        private void Start()
        {
            if (_playOnStart) Play();
        }

        public void Play(AudioSource source)
        {
            if (!_allowRestart && _clip == source.clip) return;

            StopAllCoroutines();
            StartCoroutine(PlayRoutine(source));
        }

        [ContextMenu("Play")]
        public void Play() => Play(AudioSystem.GetAudioSource(_channel));

        private IEnumerator PlayRoutine(AudioSource source)
        {
            yield return source.FadeVolume(AudioConstants.MIN_VOLUME, _fadeTime);

            source.Stop();
            source.clip = _clip;
            source.loop = _loop;
            source.Play();

            yield return source.FadeVolume(_volume, _fadeTime);
        }
    }
}