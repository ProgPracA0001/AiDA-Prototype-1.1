using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewspaperObjective : MonoBehaviour
{
    public Text resultText;
    public Text hintText;
    public TMP_InputField inputText = null;
    public GameObject lockedWindow;
    public GameObject unlockedWindow;

    public GameController player;
    private int attempts;

    public string correctPassword;
    public string hint;


    void Start()
    {
        attempts = 0;

    }

    public void checkIfPuzzleSolved()
    {
        if (player.currentPlayer.data.sideObjSubOne_ThreeComplete)
        {
            unlockedWindow.SetActive(true);
        }
        else if (!player.currentPlayer.data.sideObjSubOne_ThreeComplete)
        {
            lockedWindow.SetActive(true);
        }

    }

    public void ValidateInput()
    {
        string userInput = inputText.text;

        if (userInput != correctPassword)
        {

            resultText.text = "Incorrect Password";
            resultText.color = Color.red;
            if (attempts == 2)
            {
                hintText.text = hint;
            }
            attempts++;

        }
        else
        {
            player.currentPlayer.data.sideObjSubOne_ThreeComplete = true;
            player.UpdatePlayer();
            player.LoadSideObjectiveOne();
            lockedWindow.SetActive(false);
            unlockedWindow.SetActive(true);
        }
    }
}
