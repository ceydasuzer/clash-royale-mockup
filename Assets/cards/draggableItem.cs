using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class draggableItem : MonoBehaviour, IDragHandler
{

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }



}
