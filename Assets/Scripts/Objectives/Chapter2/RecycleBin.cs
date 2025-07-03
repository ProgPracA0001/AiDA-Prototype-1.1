using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RecycleBin : MonoBehaviour
{
    public GameController controller;

    public GameObject RecycleWindow;
    public GameObject AdminPasswordWindow;

    public TMP_InputField adminPasswordInput;
    public Text passwordWindowLabel;

    private string password = "EmotionTimeGreetings";

    public void OpenRecycle()
    {
        if (controller.currentPlayer.data.recycleUnlocked)
        {
            RecycleWindow.GetComponent<WindowControllerScript>().Open();

        }
        else
        {
            AdminPasswordWindow.GetComponent<WindowControllerScript>().Open();
        }
    }

    public void CheckUserAdmin()
    {
        if (controller.currentPlayer.data.playerIsAdmin && adminPasswordInput.text == password)
        {
            controller.currentPlayer.data.recycleUnlocked = true;
            controller.UpdateObjective("sideTwoSubThree");

            AdminPasswordWindow.GetComponent<WindowControllerScript>().Close();
            RecycleWindow.GetComponent<WindowControllerScript>().Open();

        }
        else if(controller.currentPlayer.data.playerIsAdmin && adminPasswordInput.text != password)
        {
            passwordWindowLabel.text = "Password is incorrect";
        }
        else if (!controller.currentPlayer.data.playerIsAdmin && adminPasswordInput.text == password)
        {
            passwordWindowLabel.text = "User privileges: Guest\n Admin status required.";
        }
        else
        {
            passwordWindowLabel.text = "Password Incorrect\n User privileges: Guest\n Admin status required.";
        }
    }



}
