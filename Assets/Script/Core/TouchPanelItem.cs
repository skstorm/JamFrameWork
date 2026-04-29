using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Umber
{
    public class TouchPanelItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public bool IsPressed { get; private set; } = false;

        public void OnPointerDown(PointerEventData eventData)
        {
            IsPressed = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            IsPressed = false;
        }
    }
}