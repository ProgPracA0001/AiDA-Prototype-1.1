using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableIcon draggableIcon = dropped.GetComponent<DraggableIcon>();
            draggableIcon.parentAfterDrag = transform;

        }

    }

}
