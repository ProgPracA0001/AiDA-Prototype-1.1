using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AiDAKnowledgeFile : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler

{
    public UpdateAiDA updateAiDA;

    public Image image;
    public Text text;

    public string filename;

    public string knowledgeType;

    public Transform parentAfterDrag;

    public void OnBeginDrag(PointerEventData eventData)
    {

        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
        text.raycastTarget = false;

        updateAiDA.CheckBIOSContainer();
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
        text.raycastTarget = true;

        updateAiDA.CheckBIOSContainer();

    }
}
