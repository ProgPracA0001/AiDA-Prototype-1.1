using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;


public class MyFilePuzzle : MonoBehaviour
{
    public Text resultTextOne;
    public Text resultTextTwo;
    public Text resultTextThree;
    public Text resultTextFour;

    public Text hintText;

    public InputField answerOne;
    public InputField answerTwo;
    public InputField answerThree;
    public InputField answerFour;

    private bool correctOne;
    private bool correctTwo;
    private bool correctThree;
    private bool correctFour;

    private bool allCorrect;

    public GameObject lockedWindow;
    public GameObject unlockedWindow;

    public GameController player;
    private int attempts;

    public string correctAnswerOne;
    public string correctAnswerTwo;
    public string correctAnswerThree;
    public string correctAnswerFour;

    public string hint;


    // Start is called before the first frame update
    void Start()
    {
        correctOne = false;
        correctTwo = false;
        correctThree = false;
        correctFour = false;
        allCorrect = false;

        attempts = 0;
        
        
    }

    public void checkIfPuzzleSolved()
    {
        if (player.currentPlayer.data.mainObjSubThree_ThreeComplete)
        {
            unlockedWindow.SetActive(true);
        }
        else if (!player.currentPlayer.data.mainObjSubThree_ThreeComplete)
        {
            lockedWindow.SetActive(true);
        }
    }

    public void ValidateInputs()
    {
        CheckFirstQuestion();
        CheckSecondQuestion();
        CheckThirdQuestion();
        CheckFourthQuestion();

        if (correctOne &&  correctTwo && correctThree && correctFour)
        {
            allCorrect = true;
        }

        if (allCorrect)
        {
            player.currentPlayer.data.mainObjSubThree_ThreeComplete = true;
            player.UpdatePlayer();
            lockedWindow.SetActive(false);
            unlockedWindow.SetActive(true);
        }
        else if (attempts == 4)
        {
            hintText.text = hint;
        }
        attempts++;
        
    }

    public void CheckFirstQuestion()
    {
        string userAnswerOne = answerOne.text.ToLower();
        
        if (userAnswerOne == correctAnswerOne)
        {
            correctOne = true;
            resultTextOne.text = "Correct!";
            resultTextOne.color = Color.green;
        }
        else
        {
            resultTextOne.text = "Incorrect Answer";
            resultTextOne.color = Color.red;
        }

    }

    public void CheckSecondQuestion()
    {
        string userAnswerTwo = answerTwo.text.ToLower();

        if (userAnswerTwo == correctAnswerTwo)
        {
            correctTwo = true;
            resultTextTwo.text = "Correct!";
            resultTextTwo.color = Color.green;
        }
        else
        {
            resultTextTwo.text = "Incorrect Answer";
            resultTextTwo.color = Color.red;
        }

    }

    public void CheckThirdQuestion()
    {
        string userAnswerThree = answerThree.text.ToLower();

        if (userAnswerThree == correctAnswerThree)
        {
            correctThree = true;
            resultTextThree.text = "Correct!";
            resultTextThree.color = Color.green;
        }
        else
        {
            resultTextThree.text = "Incorrect Answer";
            resultTextThree.color = Color.red;
        }

    }

    public void CheckFourthQuestion()
    {
        string userAnswerFour = answerFour.text.ToLower();

        if (userAnswerFour == correctAnswerFour)
        {
            correctFour = true;
            resultTextFour.text = "Correct!";
            resultTextFour.color = Color.green;
        }
        else
        {
            resultTextFour.text = "Incorrect Answer";
            resultTextFour.color = Color.red;
        }
    }

}
