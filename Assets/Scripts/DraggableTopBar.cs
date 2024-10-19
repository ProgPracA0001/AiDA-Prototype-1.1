using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
public class DraggableTopBar : MonoBehaviour
{

    private Vector3 mouseOffset;
    private RectTransform parentRect;

    private Vector3[] parentRectCorners = new Vector3[4];

    // Start is called before the first frame update
    private void Awake()
    {
        parentRect = transform.parent.GetComponent<RectTransform>();

    }

    // Update is called once per frame
    public void OnBeginDrag()
    {
        mouseOffset = parentRect.position - Input.mousePosition;
        Debug.Log("Beginning Drag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        parentRect.position = Input.mousePosition + mouseOffset;
        KeepInScreen();
        Debug.Log("Dragging");
    }

    private void KeepInScreen()
    {
        parentRect.GetWorldCorners(parentRectCorners);
        Vector3 bottomLeftCorner = parentRectCorners[0];
        Vector3 topRightCorner = parentRectCorners[2];

        float xPush = 0f;
        float yPush = 0f;

        if(bottomLeftCorner.x < 0)
        {
            xPush -= parentRectCorners[0].x;
        }
        if (bottomLeftCorner.y < 0)
        {
            xPush -= parentRectCorners[0].y;
        }

        if (topRightCorner.x < 0)
        {
            xPush += (Screen.width - topRightCorner.x);
        }
        if (topRightCorner.x < 0)
        {
            yPush += (Screen.height - topRightCorner.y);
        }

        if (Mathf.Abs(xPush) > 0f || Mathf.Abs(yPush) > 0f)
        {
            parentRect.position = new Vector3(
                parentRect.position.x + xPush,
                parentRect.position.y + yPush,
                parentRect.position.z);

            mouseOffset = parentRect.position - Input.mousePosition;
        }
    } 


}
