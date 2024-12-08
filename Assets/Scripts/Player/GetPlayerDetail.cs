using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetPlayerDetail : MonoBehaviour
{
    public GameController player;

    public string targetData;
    public Text targetText;

    void Start()
    {
        targetText.text = "";

        if (targetData == "username")
        {
            targetText.text = player.currentPlayer.data.username;
        }
        else if (targetData == "first")
        {
            targetText.text = player.currentPlayer.data.firstName;
        }
        else if (targetData == "last")
        {
            targetText.text = player.currentPlayer.data.lastName;
        }
        else if (targetData == "both")
        {
            targetText.text = player.currentPlayer.data.firstName + " " + player.currentPlayer.data.lastName;
        }
        else if(targetData == "chapter")
        {
            targetText.text = player.currentPlayer.data.currentChapterName;
        }

    }
}
