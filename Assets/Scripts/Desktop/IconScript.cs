using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Security.Cryptography.X509Certificates;


public class IconScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IPointerClickHandler
{
    [SerializeField] private Graphic target = default;
    [SerializeField] private Color defaultColour = new Color(0f, 0f, 0f, 0f);
    [SerializeField] private Color singleClickColour = Color.blue;

    [SerializeField] private bool Draggable = true;

    [SerializeField] private bool requiresDoubleClick = true;
    [SerializeField] private UnityEvent OnDoubleClick = default;

    private bool isSelected = false;
    private RectTransform RectTransform;
    private Vector3 mouseOffset;

    void Start()
    {
        RectTransform = GetComponent<RectTransform>();
        if(RectTransform == null )
        {
            Debug.LogException(new MissingComponentException("Icon reuires a RectTransform"), this);
        }

    }

    void Update()
    {
        if (isSelected)
        {
            if(Input.GetMouseButtonDown(0) && RectTransformUtility.RectangleContainsScreenPoint(RectTransform, Input.mousePosition) == false)
            {
                Unselect();
            }
        }
    }

    public void OnPointerClick (PointerEventData eventData)
    {
        if (isSelected || !requiresDoubleClick)
        {
            OnDoubleClick.Invoke();
            Unselect();
        } 
        else
        {
            Select();
        }
    }

    private void Select()
    {
        isSelected = true;
        if(target != null )
        {
            target.color = singleClickColour;
        }
    }

    private void Unselect()
    {
        isSelected = false;
        if(target != null )
        {
            target.color = defaultColour;
        }

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        mouseOffset = RectTransform.position - Input.mousePosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(Draggable)
        {
            Unselect();
            RectTransform.position = Input.mousePosition + mouseOffset;
        }
    }
 
}
