using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuController : MonoBehaviour
{

    [SerializeField] private RectTransform StartMenuButonTransform = default;

    private Canvas StartMenuCanvas;
    private RectTransform MenuRectTransform;

    // Start is called before the first frame update
    void Start()
    {
        StartMenuCanvas = GetComponent<Canvas>();
        StartMenuCanvas.enabled = false;
        MenuRectTransform = GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {
        if (StartMenuCanvas.enabled)
        {
            if (Input.GetMouseButtonDown(0) &&
                    RectTransformUtility.RectangleContainsScreenPoint(MenuRectTransform, Input.mousePosition) == false &&
                    RectTransformUtility.RectangleContainsScreenPoint(StartMenuButonTransform, Input.mousePosition) == false
                )
                {
                Hide();
            }
        }
    }

    public void ToggleShowing()
    {
        StartMenuCanvas.enabled = !StartMenuCanvas.enabled;
    }

    public void Hide()
    {
        StartMenuCanvas.enabled = false;
    }

}
