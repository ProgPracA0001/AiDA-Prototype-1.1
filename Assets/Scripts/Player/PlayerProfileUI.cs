using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProfileUI : MonoBehaviour
{
    public GameController player;

    public Text username;
    public Text firstname;
    public Text lastname;
    public Text currentChapter;

   
    void Start()
    {
        username.text = player.currentPlayer.data.username;
        firstname.text = player.currentPlayer.data.firstName;
        lastname.text = player.currentPlayer.data.lastName;
        currentChapter.text = player.currentPlayer.data.currentChapterName;

    }
}
