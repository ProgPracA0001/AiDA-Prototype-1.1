using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
public class DraggableTopBar : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public bool KeepWithinScreen = false;

    private Vector3 mouseOffset;
    private RectTransform parentRect;
    private GameObject parentObject;

    private Vector3[] parentRectCorners = new Vector3[4];

    private int parentChildren;
    private int grandParentChildren;

    // Start is called before the first frame update
    private void Awake()
    {
        parentRect = transform.parent.GetComponent<RectTransform>();
        parentObject = parentRect.gameObject;

    }

    void Update()
    {
        parentChildren = parentObject.transform.parent.childCount;
        grandParentChildren = parentObject.transform.parent.parent.childCount;

    }


    // Update is called once per frame
    public void OnBeginDrag(PointerEventData eventData)
    {
        BringToFront();
        mouseOffset = parentRect.position - Input.mousePosition;
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        parentRect.position = Input.mousePosition + mouseOffset;
        if (KeepWithinScreen)
        {
            KeepParentRectInScreen();
        }
    }

    private void KeepParentRectInScreen()
    {
        parentRect.GetWorldCorners(parentRectCorners);
        Vector3 bottomLeftCorner = parentRectCorners[0];
        Vector3 topRightCorner = parentRectCorners[2];

        // keep track of how much to move the rect to keep it in the screen
        float xPush = 0f;
        float yPush = 0f;

        // calculate amount to move the rect based on position of rect corners and screen size
        if (bottomLeftCorner.x < 0)
        {
            xPush -= parentRectCorners[0].x;
        }
        if (bottomLeftCorner.y < 0)
        {
            yPush -= parentRectCorners[0].y;
        }

        if (topRightCorner.x > Screen.width)
        {
            xPush += (Screen.width - topRightCorner.x);
        }
        if (topRightCorner.y > Screen.height)
        {
            yPush += (Screen.height - topRightCorner.y);
        }

        // reposition the rect
        if (Mathf.Abs(xPush) > 0f || Mathf.Abs(yPush) > 0f)
        {
            parentRect.position = new Vector3(
                parentRect.position.x + xPush,
                parentRect.position.y + yPush,
                parentRect.position.z
            );

            // reset mouse offset position so draging is anchored to the new mouse position
            mouseOffset = parentRect.position - Input.mousePosition;
        }
    }

    public void BringToFront()
    {

        parentObject.transform.SetSiblingIndex(parentChildren - 1);
        parentObject.transform.parent.SetSiblingIndex(grandParentChildren - 1);


    }

}
