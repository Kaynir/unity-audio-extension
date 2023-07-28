using UnityEngine;

namespace Kaynir.Audio
{
    public class SoundPlayer : MonoBehaviour
    {
        [SerializeField] private SoundAsset soundAsset = null;
        [SerializeField] private AudioSource audioSource = null;

        private void Awake()
        {
            audioSource.Stop();
        }

        private void OnEnable()
        {
            if (!audioSource.playOnAwake) return;
            Play();
        }

        [ContextMenu("Play")]
        public void Play()
        {
            soundAsset.Play(audioSource);
        }

        [ContextMenu("PlayOneShot")]
        public void PlayOneShot()
        {
            soundAsset.PlayOneShot(audioSource);
        }
    }
}