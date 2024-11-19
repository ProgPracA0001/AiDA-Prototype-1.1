using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PasswordInput : MonoBehaviour
{
    public Text resultText;
    public TMP_InputField inputText = null;
    public GameObject lockedWindow;
    public GameObject unlockedWindow;

    public Puzzle puzzle;

    public string correctPassword;


    private void Start()
    {
        if (puzzle==null)
        {
            puzzle = new Puzzle();
        }
    }

    public void checkIfPuzzleSolved()
    {
        if (puzzle.solved)
        {
                unlockedWindow.SetActive(true);
        }
        else if (!puzzle.solved)
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
            }
            else
            {
                puzzle.solved = true;
                lockedWindow.SetActive(false);
                unlockedWindow.SetActive(true);
            }
    }
}
