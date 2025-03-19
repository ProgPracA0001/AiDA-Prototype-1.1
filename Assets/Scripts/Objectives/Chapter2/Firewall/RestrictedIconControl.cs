using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestrictedIconControl : MonoBehaviour
{
    public GameController player;

    public GameObject lockedWindow;
    public GameObject unlockedWindow;
    public GameObject ChapterLock;

    public Text AlertLabel;

    public string AlertMessage = "Access to this folder requires:" +
    "Chapter Level: 2";

    public void CheckFirewallStatus()
    {
        if (player.currentPlayer.data.mainObjSubOne_ThreeComplete && player.currentPlayer.data.currentChapter == 2)
        {
            unlockedWindow.GetComponent<WindowControllerScript>().Open();

        }
        else if (player.currentPlayer.data.currentChapter < 2)
        {
            AlertLabel.text = AlertMessage;
            ChapterLock.GetComponent<WindowControllerScript>().Open();
        }
        else
        {
            lockedWindow.GetComponent<WindowControllerScript>().Open();
        }
    }

}
