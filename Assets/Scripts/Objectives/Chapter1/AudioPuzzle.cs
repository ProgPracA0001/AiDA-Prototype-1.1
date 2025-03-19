using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AudioPuzzle : MonoBehaviour
{
    public Text pinInput;
    public Text resultText;
    public Text hintText;
    public GameObject lockedWindow;
    public GameObject unlockedWindow;

    public GameController player;
    private int attempts;

    private int parentChildrenUnlocked;
    private int grandParentChildrenUnlocked;
    private int parentChildrenLocked;
    private int grandParentChildrenLocked;

    public string correctPassword;
    public string hint;


    void Start()
    {
        attempts = 0;

    }

    void Update()
    {
        parentChildrenUnlocked = unlockedWindow.transform.parent.childCount;
        grandParentChildrenUnlocked = unlockedWindow.transform.parent.parent.childCount;

        parentChildrenLocked = lockedWindow.transform.parent.childCount;
        grandParentChildrenLocked = lockedWindow.transform.parent.parent.childCount;
    }

    public void checkIfPuzzleSolved()
    {
        if (player.currentPlayer.data.sideObjSubTwo_ThreeComplete || player.currentPlayer.data.currentChapter >= 2)
        {
            unlockedWindow.SetActive(true);
            unlockedWindow.transform.SetSiblingIndex(parentChildrenUnlocked - 1);
            unlockedWindow.transform.parent.SetSiblingIndex(grandParentChildrenUnlocked - 1);
        }
        else if (!player.currentPlayer.data.sideObjSubTwo_ThreeComplete)
        {

            lockedWindow.SetActive(true);
            lockedWindow.transform.SetSiblingIndex(parentChildrenLocked - 1);
            lockedWindow.transform.parent.SetSiblingIndex(grandParentChildrenLocked - 1);
        }

    }

    public void ButtonInput(string value)
    {
        pinInput.text += value;
    }

    public void RemoveLastInput()
    {
        pinInput.text = pinInput.text.Substring(0, pinInput.text.Length - 1);
    }

    public void ClearInput()
    {
        pinInput.text = "";
    }

    public void ValidateInput()
    {
        string userInput = pinInput.text;

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
            player.UpdateObjective("sideTwoSubThree");
            lockedWindow.SetActive(false);
            unlockedWindow.SetActive(true);
            unlockedWindow.transform.SetSiblingIndex(parentChildrenUnlocked - 1);
            unlockedWindow.transform.parent.SetSiblingIndex(grandParentChildrenUnlocked - 1);

        }
    }
}
