using UnityEngine.EventSystems;

namespace Kaynir.Audio.Interactions
{
    public class SoundOnClick : SoundPlayer, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            PlayOneShot();
        }
    }
}