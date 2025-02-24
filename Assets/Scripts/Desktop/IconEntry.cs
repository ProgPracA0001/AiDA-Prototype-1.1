using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Android.Types;
using UnityEngine;
using UnityEngine.UI;

public class IconEntry : MonoBehaviour
{
    public GameController player;
    public WindowControllerScript TargetWindowControl;
    public WindowControllerScript AlertWindowControl;

    public GameObject AlertWindow;
    public Text AlertLabel;

    public GameObject TargetWindow;

    public int requiredChapter;

    public string AlertMessage = "Access to this folder requires:" +
        "Chapter Level: ";

    void Awake()
    {
        TargetWindowControl = TargetWindow.GetComponent<WindowControllerScript>();
        AlertWindowControl = AlertWindow.GetComponent<WindowControllerScript>();
    }
    public void CheckPlayerChapter()
    {
        if (player.currentPlayer.data.currentChapter >= requiredChapter)
        {
            TargetWindowControl.Open();
        }
        else
        {
            AlertLabel.text = AlertMessage + requiredChapter.ToString();
            AlertWindowControl.Open();
        }
    }
}
