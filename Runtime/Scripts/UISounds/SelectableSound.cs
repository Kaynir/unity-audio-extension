using UnityEngine;
using UnityEngine.UI;

namespace Kaynir.Audio.UI
{
    public abstract class SelectableSound : MonoBehaviour
    {
        [SerializeField] protected SoundCollection _soundCollection = null;
        [SerializeField] protected Selectable _selectable = null;

        public virtual void Play()
        {
            if (IsInteractable())
            {
                _soundCollection.PlaySound();
            }
        }

        protected bool IsInteractable()
        {
            if (!_selectable) return true;
            return _selectable.interactable;
        }
    }
}