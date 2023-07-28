using UnityEngine.EventSystems;

namespace Kaynir.Audio.Interactions
{
    public class SoundOnHover : SoundPlayer, IPointerEnterHandler
    {
        public void OnPointerEnter(PointerEventData eventData)
        {
            PlayOneShot();
        }
    }
}