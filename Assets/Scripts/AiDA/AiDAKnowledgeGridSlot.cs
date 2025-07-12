using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AiDAKnowledgeGridSlot : MonoBehaviour, IDropHandler
{
    public Text fileDetectedLabel;
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            AiDAKnowledgeFile draggableIcon = dropped.GetComponent<AiDAKnowledgeFile>();
            draggableIcon.parentAfterDrag = transform;

            fileDetectedLabel.text = draggableIcon.name;

        }

    }
}
