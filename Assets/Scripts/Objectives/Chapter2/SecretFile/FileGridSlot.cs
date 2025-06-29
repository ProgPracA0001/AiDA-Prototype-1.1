using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FileGridSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableFile draggableFile = dropped.GetComponent<DraggableFile>();
            draggableFile.parentAfterDrag = transform;
            

        }

    }

}
