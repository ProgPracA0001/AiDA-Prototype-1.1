using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestrictedIconControl : MonoBehaviour
{
    public GameController player;
    public SecretFile secretFile;

    public GameObject lockedWindow;
    public GameObject unlockedWindow;
    public GameObject ChapterLock;

    public Text AlertLabel;

    public string AlertMessage = "Access to this folder requires:" +
    "Chapter Level: 2";

    public void CheckFirewallStatus()
    {
        if (player.currentPlayer.data.currentChapter == 2 && !player.currentPlayer.data.mainObjSubTwo_ThreeComplete)
        {
            lockedWindow.GetComponent<WindowControllerScript>().Open();

        }
        else if (player.currentPlayer.data.currentChapter < 2)
        {
            AlertLabel.text = AlertMessage;
            ChapterLock.GetComponent<WindowControllerScript>().Open();
        }
        else
        {

            CheckForSubjectZeroRestoration();
            
        }
    }

    public void CheckForSubjectZeroRestoration()
    {
        if (player.currentPlayer.data.subject0Restored)
        {
            secretFile.FileRestored();
            unlockedWindow.GetComponent<WindowControllerScript>().Open();
        }
        else
        {
            unlockedWindow.GetComponent<WindowControllerScript>().Open();
        }
    }

}
