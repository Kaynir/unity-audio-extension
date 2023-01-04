using UnityEngine.EventSystems;

namespace Kaynir.Audio.UI
{
    public class HoverSound : SelectableSound, IPointerEnterHandler
    {
        public void OnPointerEnter(PointerEventData eventData)
        {
            Play();
        }
    }
}