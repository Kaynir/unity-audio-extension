using UnityEngine.EventSystems;

namespace Kaynir.Audio.Interactions
{
    public class SoundOnClick : SoundBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            sound.PlayOneShot();
        }
    }
}