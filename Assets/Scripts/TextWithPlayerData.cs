using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class TextWithPlayerData : MonoBehaviour
{
    public string nameNeeded;
    public Text targetText;

    // Start is called before the first frame update
    void Start()
    {
        PlayerManager.instance.LoadPlayerData();

        if(nameNeeded.ToLower() == null )
        {
            Debug.Log("Error: state which name you need, first, last, both");
        }
        else if(nameNeeded.ToLower() == "both")
        {
            targetText.text = PlayerManager.instance.player.firstname + " " + PlayerManager.instance.player.lastname;
        }
        else if(nameNeeded.ToLower() == "first")
        {
            targetText.text = PlayerManager.instance.player.firstname;

        }
        else if (nameNeeded.ToLower() == "last")
        {
            targetText.text = PlayerManager.instance.player.lastname;

        }
        else
        {
            Debug.Log("Error: state which name you need, first, last, both");
        }



    }

 

}