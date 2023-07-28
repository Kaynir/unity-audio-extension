using System.Collections;
using Kaynir.Audio.Tools;
using UnityEngine;

namespace Kaynir.Audio
{
    public class MusicPlayer : MonoBehaviour
    {
        private const float HALF_TRANSITION_RATE = .5f;

        [SerializeField] private AudioClip audioClip = null;
        [SerializeField] private AudioSource audioSource = null;
        [SerializeField] private bool allowRestart = false;
        [SerializeField, Min(0f)] private float fullTransitionTime = .5f;

        private void Awake()
        {
            audioSource.Stop();
        }

        private void OnEnable()
        {
            if (!audioSource.playOnAwake) return;
            SetTransition(audioClip, audioSource.volume);
        }

        public void SetTransition(AudioClip audioClip, float volume)
        {
            if (!allowRestart && audioSource.IsPlaying(audioClip))
            {
                return;
            }

            StopAllCoroutines();
            StartCoroutine(TransitionRoutine(audioClip, volume));
        }

        public void SetTransition(AudioClip audioClip)
        {
            SetTransition(audioClip, AudioTools.MAX_VOLUME);
        }

        private IEnumerator TransitionRoutine(AudioClip audioClip, float volume)
        {
            float lerpTime = fullTransitionTime * HALF_TRANSITION_RATE;

            if (audioSource.isPlaying)
            {
                yield return audioSource.LerpVolumeRoutine(AudioTools.MIN_VOLUME, lerpTime);
                audioSource.Stop();
            }

            audioSource.volume = AudioTools.MIN_VOLUME;
            audioSource.clip = audioClip;
            audioSource.Play();

            yield return audioSource.LerpVolumeRoutine(volume, lerpTime);
        }
    }
}