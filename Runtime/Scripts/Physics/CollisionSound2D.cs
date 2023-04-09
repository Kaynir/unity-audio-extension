using UnityEngine;

namespace Kaynir.Audio.Physics
{
    public class CollisionSound2D : MonoBehaviour
    {
        [SerializeField] private SoundCollection _soundCollection = null;

        private void OnCollisionEnter2D(Collision2D other)
        {
            _soundCollection.Play();
        }
    }
}