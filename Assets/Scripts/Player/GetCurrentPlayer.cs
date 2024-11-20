using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetCurrentPlayer : MonoBehaviour
{
    public Text usernameText;
    public Text firstnameText;
    public Text lastnameText;
    public Text currentChapterTitle;

    // Start is called before the first frame update
    void Start()
    {
        PlayerManager.instance.LoadPlayerData();

        usernameText.text = PlayerManager.instance.player.username;
        firstnameText.text = PlayerManager.instance.player.firstname;
        lastnameText.text = PlayerManager.instance.player.lastname;
        currentChapterTitle.text = PlayerManager.instance.player.currentChapterTitle;
    }

}
