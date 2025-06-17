using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableFile : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    public Text text;
    [HideInInspector] public Transform parentAfterDrag;

    public GameObject mainContainer;

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(mainContainer.transform);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
        text.raycastTarget = false;
        mainContainer.GetComponent<ContainerDetection>().AssignDraggingObject(gameObject);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        mainContainer.GetComponent<ContainerDetection>().dropAssignedObject();
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
        text.raycastTarget = true;
    }

}
