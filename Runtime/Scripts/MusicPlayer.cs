using System.Collections;
using Kaynir.Audio.Tools;
using UnityEngine;

namespace Kaynir.Audio
{
    public class MusicPlayer : MonoBehaviour
    {
        [SerializeField] private AudioClip clip = null;
        [SerializeField] private AudioSource source = null;
        [SerializeField] private bool allowRestart = false;
        [SerializeField, Min(0f)] private float transitionTime = .5f;

        private void Awake()
        {
            if (!source.playOnAwake) return;
            
            source.Stop();
            SetTransition(clip, source.volume);
        }

        public void SetTransition(AudioClip clip, float volume)
        {
            if (!allowRestart && source.isPlaying && source.clip == clip) return;

            StopAllCoroutines();
            StartCoroutine(TransitionRoutine(clip, volume));
        }

        public void SetTransition(AudioClip clip) => SetTransition(clip, AudioTools.MAX_VOLUME);

        private IEnumerator TransitionRoutine(AudioClip clip, float volume)
        {
            float lerpTime = transitionTime * .5f;

            if (source.isPlaying)
            {
                yield return source.LerpVolumeRoutine(AudioTools.MIN_VOLUME, lerpTime);
                source.Stop();
            }

            source.volume = AudioTools.MIN_VOLUME;
            source.clip = clip;
            source.Play();

            yield return source.LerpVolumeRoutine(volume, lerpTime);
        }
    }
}