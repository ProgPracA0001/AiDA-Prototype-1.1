using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewPlayer : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public TMP_InputField firstnameInput;
    public TMP_InputField lastnameInput;
    public TMP_InputField confirmPasswordInput;
    public Text responseText;

    [NonSerialized] public Player player;


    void Start()
    {
       if (player == null)
        {
            player = new Player();
        }

    }

    public void SaveNewPlayer()
    {
        if (usernameInput.text == "" || passwordInput.text == "" || firstnameInput.text == "" || lastnameInput.text == "" || confirmPasswordInput.text == "")
        {
            responseText.text = "Please Complete All Fields.";
            responseText.color = Color.red;
        }

        else if (passwordInput.text != confirmPasswordInput.text)
        {
            responseText.text = "Passwords do not match.";
            responseText.color = Color.red;

        }
        else
        {
            player.username = usernameInput.text;
            player.password = passwordInput.text;
            player.firstname = firstnameInput.text;
            player.lastname = lastnameInput.text;

            SavePlayerData();

            Debug.Log("Player Data Saved: " + player.username);

            SceneManager.LoadScene("DesktopScene");
        }
    }

    private void SavePlayerData()
    {
        PlayerPrefs.SetString("PlayerUsername", player.username);
        PlayerPrefs.SetString("PlayerPassword", player.password);
        PlayerPrefs.SetString("PlayerFirstname", player.firstname);
        PlayerPrefs.SetString("PlayerLastname", player.lastname);
        PlayerPrefs.SetString("PlayerChapterTitle", player.currentChapterTitle);
        PlayerPrefs.SetInt("PlayerChapterNo", player.currentChapterNo);

        PlayerPrefs.Save();

    }

}
