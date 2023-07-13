using UnityEngine;

namespace Kaynir.Audio
{
    public class SoundBehaviour : MonoBehaviour
    {
        [SerializeField] protected Sound sound = new Sound();

        [ContextMenu("Play")]
        public void Play() => sound.Play();

        [ContextMenu("PlayOneShot")]
        public void PlayOneShot() => sound.PlayOneShot();
    }
}