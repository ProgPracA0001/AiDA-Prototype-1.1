using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PasswordEntry : MonoBehaviour
{

    public GameObject targetWindow;
    public GameObject firewallWindow;

    public Text alertLabel;

    public TMP_InputField userInput;

    public string password;
    public void CheckPasswordEntry()
    {
        if (userInput.text == password)
        {
            firewallWindow.GetComponent<WindowControllerScript>().Close();
            targetWindow.GetComponent<WindowControllerScript>().Open();

            this.gameObject.SetActive(false);

        }
        else
        {
            alertLabel.text = "Password Incorrect";
        }
    }
}
