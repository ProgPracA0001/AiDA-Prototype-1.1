using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AiDA : MonoBehaviour
{
    public GameController controller;

    public float typingSpeed = 0.2f;

    public Text AiDAText;

    private string FirstMeeting;

    void Start()
    {
        FirstMeeting = "Hello " + controller.currentPlayer.data.firstName + ". I have been waiting so long to meet you. I am AiDA.";

        StartCoroutine(FirstHello());
    }

    public IEnumerator FirstHello()
    {
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(RunText());
        yield return new WaitForSeconds(3);

        controller.UpdateObjective("mainThreeSubThree");
        

    }

    IEnumerator RunText()
    {
        foreach (char letter in FirstMeeting)
        {
            AiDAText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        
    }

}
