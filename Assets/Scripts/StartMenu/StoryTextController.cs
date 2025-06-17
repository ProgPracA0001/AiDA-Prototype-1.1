using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryTextController : MonoBehaviour
{
    public Text targetText;
    public Text chapterText;
    public float typingSpeed = 1.0f;
    public float lineDelay = 1.5f;

    public GameObject powerButton;
    public GameObject NewUserPage;

    public string chapterTitle = "Chapter One: An Inherited Legacy...";

    public string[] storyIntroductionText =
    {
        "*There's a knock at the door...*\n",
        "You answer.\n",
        "\n",
        "There's a gentlemen on your porch carrying a cardboard box.\n",
        "His umbrella hangs on his arm dripping, the front of the box dark from the rain.\n",
        "\n",
        "Gentleman: This 73 Steadfel Road?\n",
        "You: Yes it is.. sorry who are you?\n",
        "Gentleman: I was told to drop off this package to whoever opens the door of this address.\n",
        "\n",
        "Before you can say anything he thrusts the box towards you, you stumble under the weight.\n",
        "He turns quickly, avoiding any conversation and hurtling back into the rain.\n",
        "You stand bewildered before turning back inside and settin the package down.\n",
        "You Open it.\n",
        "\n",
        "You: Hmmm... an old computer, why would someone give me that old thing?\n",
        "You remove it from the box and set it up on your desk and plug it in.\n",
        "You stare at it for a moment, then hit the power button.\n"
    };

    public string[] BootUpText =
    {
        "Booting Up . . .\n",
        "\n",
        "Initializing AiDA's Desktop v.8.98.2\n",
        "\n",
        "Loading system files . . .\n",
        "System files loaded successfully.\n",
        "Checking system configuration . . .\n",
        "System configuration check complete. Success.\n",
        "Loading drivers . . .\n",
        "Drivers loaded successfully.\n",
        "\n",
        "Connecting to network . . .\n",
        "Connection to network . . . Failed\n",
        "Retrying connection . . .\n",
        "Connection to network . . . Failed\n",
        "Checking available updates . . .\n",
        "No updates found.\n",
        "\n",
        "Running system diagnostics . . .\n",
        "Diagnostics complete. Success.\n",
        "System check complete.\n",
        "All systems operational.\n",
        "\n",
        "New User Detected...Loading New User Protocols..",
    };


    // Start is called before the first frame update
    void Start()
    {
        powerButton.SetActive(false);
        StartCoroutine(RunGameStart());
    }

     IEnumerator RunGameStart()
    {
       yield return StartCoroutine(runChapterTitle());

        yield return new WaitForSeconds(5);
        chapterText.text = "";
        yield return StartCoroutine(StartStory());
    }

    public void PowerOn()
    {

        StartCoroutine(BootUpSequence());
        powerButton.SetActive(false);

    }

    IEnumerator StartStory()
    {
        targetText.text = "";

        foreach (string line in storyIntroductionText)
        {
            yield return StartCoroutine(TypeLine(line));

            yield return new WaitForSeconds(lineDelay);
        }
        powerButton.SetActive(true);
    }

    IEnumerator runChapterTitle()
    {
        foreach(char letter in chapterTitle)
        {
            chapterText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

    }

    IEnumerator BootUpSequence()
    {
        
        targetText.text = "";
        yield return new WaitForSeconds(6);

        foreach (string line in BootUpText)
        {
            yield return StartCoroutine(TypeLine(line));

            yield return new WaitForSeconds(lineDelay);
        }

        StartCoroutine(OpenNewUserPage());
    }

    IEnumerator OpenNewUserPage()
    {
        yield return new WaitForSeconds(3);

        gameObject.SetActive(false);
        NewUserPage.SetActive(true);
    }

    IEnumerator TypeLine(string currentLine)
    {
        
        foreach (char letter in currentLine)
        {
            targetText.text += letter;
            yield return new WaitForSeconds(typingSpeed);

        }

        targetText.text += "\n";
    }


    
}
