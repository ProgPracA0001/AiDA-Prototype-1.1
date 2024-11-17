using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonController : MonoBehaviour
{

    public GameObject menuPage;
    public GameObject startMenu;


    public void Open()
    {
        startMenu.SetActive(false);
        menuPage.SetActive(true);
    }

    public void Back()
    {
        menuPage.SetActive(false);
        startMenu.SetActive(true);
    }
}
