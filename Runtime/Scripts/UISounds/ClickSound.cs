using UnityEngine.EventSystems;

namespace Kaynir.Audio.UI
{
    public class ClickSound : SelectableSound, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            Play();
        }
    }
}