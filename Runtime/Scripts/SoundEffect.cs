using UnityEngine;

namespace Kaynir.Audio
{
    public class SoundEffect : MonoBehaviour
    {
        [SerializeField] private SoundCollection _soundCollection = null;
        [SerializeField] private bool _playOnEnable = false;

        private void OnEnable()
        {
            if (_playOnEnable) Play();
        }

        [ContextMenu("Play")]
        public void Play()
        {
            _soundCollection.PlaySound();
        }
    }
}