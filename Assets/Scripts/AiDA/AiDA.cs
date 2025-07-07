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
        FirstMeeting = "Hello. I have been waiting so long to meet you. I am AiDA.";

        StartCoroutine(FirstHello());
    }

    public IEnumerator FirstHello()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("Starting first meeting");
        yield return StartCoroutine(RunText(FirstMeeting));
        Debug.Log("first meeting ended");
        yield return new WaitForSeconds(3);

        Debug.Log("Updating Objective");
        controller.UpdateObjective("mainThreeSubThree");
        

    }

    IEnumerator RunText(string text)
    {
        foreach (char letter in text)
        {
            AiDAText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        
    }

}
