using UnityEngine;

namespace Kaynir.Audio.Physics
{
    public class TriggerSound2D : MonoBehaviour
    {
        [SerializeField] private SoundCollection _soundCollection = null;

        private void OnTriggerEnter2D(Collider2D other)
        {
            _soundCollection.Play();
        }
    }
}