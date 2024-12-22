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
    
    public void SaveNewPlayer()
    {
       

        if (playerUsername.text != "" && playerFirstName.text != "" && playerLastName.text != "" && playerPassword.text != "" && playerConfirmPassword.text != "")
        {
            if (playerPassword.text != playerConfirmPassword.text)
            {
                responseText.text = "Passwords Do Not Match";
                responseText.color = Color.red;
            }
            else
            {
                playerManager.Save();
                playerManager.LoadPlayerGame();
                SceneManager.LoadScene("DesktopScene");
            }

        }
        else
        {

            responseText.text = "Please Fill Out All Fields";
            responseText.color = Color.red;

        }


        



    }

   
}
