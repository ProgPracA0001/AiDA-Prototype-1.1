using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowControllerScript : MonoBehaviour
{
    [Header("Collapse Window")]
    [SerializeField] private RectTransform HideOnCollapse = default;
    [SerializeField] private float CollapsedHight = 32;

    private float ExpandedHeight;
    private bool isCollapsed = false;

    private RectTransform RectTransform;
    // Start is called before the first frame update
    void Awake()
    {
        RectTransform = GetComponent<RectTransform>();
   
    }

    // Update is called once per frame
    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void Open()
    {
        gameObject.SetActive(true);
        BringToFront();

    }

    public void Collapse()
    {
        if(!isCollapsed)
        {
            ExpandedHeight = RectTransform.sizeDelta.y;
            RectTransform.sizeDelta = new Vector2(RectTransform.sizeDelta.x, CollapsedHight);
            HideOnCollapse.gameObject.SetActive(false);

            isCollapsed = true;
        }
    }

    public void Expand()
    {
        if(isCollapsed)
        {
            HideOnCollapse.gameObject.SetActive(true);
            RectTransform.sizeDelta = new Vector2(RectTransform.sizeDelta.x, ExpandedHeight);

            isCollapsed = false;
        }

        BringToFront();
    }

    public void BringToFront()
    {
        transform.SetSiblingIndex(transform.parent.childCount - 1);
    }


    public void SendToBack()
    {
        transform.SetSiblingIndex(0);
    }
}
