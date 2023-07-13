using UnityEngine.EventSystems;

namespace Kaynir.Audio.Interactions
{
    public class SoundOnHover : SoundBehaviour, IPointerEnterHandler
    {
        public void OnPointerEnter(PointerEventData eventData)
        {
            sound.PlayOneShot();
        }
    }
}