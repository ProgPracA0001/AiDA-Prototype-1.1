using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class NewPlayerUI : MonoBehaviour
{
    public PlayerManager playerManager;

    public InputField playerUsername;
    public InputField playerFirstName;
    public InputField playerLastName;
    public InputField playerPassword;
    public InputField playerConfirmPassword;

    private bool fieldsChecked = false;

    public Text responseText;

    private void Start()
    {
        Debug.Log(playerManager.selectedPlayer);
    }
    public void CreateUsername()
    {
        
            playerManager.data.username = playerUsername.text;
        
    }

    public void CreateFirstName()
    {
            playerManager.data.firstName = playerFirstName.text;
       
    }

    public void CreateLastName()
    {
            playerManager.data.lastName = playerLastName.text;
        
    }
    
    public void CheckFields()
    {
        if(playerPassword.text != playerConfirmPassword.text)
        {
            responseText.text = "Passwords Do Not Match";
            responseText.color = Color.red;
        }
        else if (playerUsername.text == null || playerFirstName.text == null || playerLastName.text == null || playerPassword.text == null || playerConfirmPassword.text == null)
        {
            responseText.text = "Please Fill Out All Fields";
            responseText.color = Color.red;
        }
        else
        {
            fieldsChecked = true;
        }
    }
    public void SaveNewPlayer()
    {
        CheckFields();
        if (fieldsChecked)
        {
            playerManager.Save();
            playerManager.LoadPlayerGame();
            SceneManager.LoadScene("DesktopScene");
        }
        

    }

   
}
