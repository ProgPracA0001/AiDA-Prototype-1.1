using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewPlayerUI : MonoBehaviour
{
    public PlayerManager playerManager;

    public string currentPlayer;

    public TMP_InputField playerUsername;
    public TMP_InputField playerFirstName;
    public TMP_InputField playerLastName;
    public TMP_InputField playerPassword;
    public TMP_InputField playerConfirmPassword;

    private bool fieldsChecked = false;

    public Text responseText;

    void Awake()
    {
        currentPlayer = playerManager.selectedPlayer;
    }

    public void CreateUsername()
    {
        if(currentPlayer == "playerOne")
        {
            playerManager.playerOneData.username = playerUsername.text;
            
        }
        else if (currentPlayer == "playerTwo")
        {
            playerManager.playerTwoData.username = playerUsername.text;
        }
        else if(currentPlayer == "playerThree")
        {
            playerManager.playerThreeData.username = playerUsername.text;
        }
    }

    public void CreateFirstName()
    {
        if(currentPlayer == "playerOne")
        {
            playerManager.playerOneData.firstName = playerFirstName.text;
        }
        else if (currentPlayer == "playerTwo")
        {
            playerManager.playerTwoData.firstName = playerFirstName.text;
        }
        else if (currentPlayer == "playerThree")
        {
            playerManager.playerThreeData.firstName = playerFirstName.text;
        }
    }

    public void CreateLastName()
    {
        if (currentPlayer == "playerOne")
        {
            playerManager.playerOneData.lastName = playerLastName.text;
        }
        else if (currentPlayer == "playerTwo")
        {
            playerManager.playerTwoData.lastName = playerLastName.text;
        }
        else if (currentPlayer == "playerThree")
        {
            playerManager.playerThreeData.lastName = playerLastName.text;
        }
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
