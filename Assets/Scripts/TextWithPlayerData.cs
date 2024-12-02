using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class TextWithPlayerData : MonoBehaviour
{
    public string detailNeeded;
    public Text targetText;

    // Start is called before the first frame update
    void Start()
    {
        PlayerManager.instance.LoadPlayerData();

        if(detailNeeded.ToLower() == null )
        {
            Debug.Log("Error: state detail name you need, first, last, both");
        }
        else if(detailNeeded.ToLower() == "both")
        {
            targetText.text = PlayerManager.instance.player.firstname + " " + PlayerManager.instance.player.lastname;
        }
        else if(detailNeeded.ToLower() == "first")
        {
            targetText.text = PlayerManager.instance.player.firstname;

        }
        else if (detailNeeded.ToLower() == "last")
        {
            targetText.text = PlayerManager.instance.player.lastname;

        }
        else if(detailNeeded.ToLower() == "chapter")
        {
            targetText.text = PlayerManager.instance.player.currentChapterTitle;
        }
        else
        {
            Debug.Log("Error: state which name you need, first, last, both");
        }



    }

 

}