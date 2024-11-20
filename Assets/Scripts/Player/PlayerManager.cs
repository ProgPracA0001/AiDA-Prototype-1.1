using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance { get; private set; }

    public Player player;
    // Start is called before the first frame update

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        if (player == null)
        {
            player = new Player();
        }
    }
    // Update is called once per frame
    public void LoadPlayerData()
    {
        if (PlayerPrefs.HasKey("PlayerUsername"))
        {
            player.username = PlayerPrefs.GetString("PlayerUsername");
            player.password = PlayerPrefs.GetString("PlayerPassword"); // You might want to validate this securely
            player.firstname = PlayerPrefs.GetString("PlayerFirstname");
            player.lastname = PlayerPrefs.GetString("PlayerLastname");
            player.currentChapterTitle = PlayerPrefs.GetString("PlayerChapterTitle");
            player.currentChapterNo = PlayerPrefs.GetInt("PlayerChapterNo");

            Debug.Log("Player Data Loaded: " + player.username);
        }
        else
        {
            Debug.LogWarning("No saved player data found.");
        }

    }
}
