using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class ContainerDetection : MonoBehaviour
{
    public GameObject draggedObject;


    public GameObject topContainer;
    public GameObject bottomContainer;

    public Rect dragged;
    public Rect top;
    public Rect bottom;

    public void Awake()
    {
        top = topContainer.GetComponent<RectTransform>().rect;
        bottom = bottomContainer.GetComponent<RectTransform>().rect;
    }
    public void DragStart()
    {
        if(dragged.)
        {
            Debug.Log("In Top Container");
        }
        else if (dragged == bottom)
        {
            Debug.Log("In Bottom Container");
        }
       
    }

    public void AssignDraggingObject(GameObject targetFile)
    {
        draggedObject = targetFile;
        dragged = draggedObject.GetComponent<RectTransform>().rect;
    }

    public void dropAssignedObject()
    {
        draggedObject = null;
        Debug.Log(dragged.ToString());
    }
}
