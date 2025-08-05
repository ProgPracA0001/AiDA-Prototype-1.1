using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkHandshake : MonoBehaviour
{

    public GameController player;

    public GameObject webCrawlerIcon;

    public Text statusText;


    public string processString;
    public string loadText = "...";

    public int processStep;

    // Start is called before the first frame update
    void Start()
    {

        if (player.currentPlayer.data.internetConnected != true)
        {
            statusText.text = "Offline";
            StartCoroutine(startHandshake());
            
        }
        else
        {
            statusText.text = "Connected";
        }

    }

 
    IEnumerator startHandshake()
    {
        
        processStep = 0;

        Debug.Log(processStep);

        Debug.Log(player.currentPlayer.data.internetConnected.ToString());
      
        while(player.currentPlayer.data.internetConnected == false)
        {
            Debug.Log("This Code is Running");
            Debug.Log(processStep);

            if (processStep <= 2)
            {
                processString = "Dialing";
                loadStage(processString);
                processStep ++;
                yield return new WaitForSeconds(3.0f);

            }
            else if (processStep < 6)
            {
                processString = "Performing Handshake"; 
                loadStage(processString);
                processStep ++;
                yield return new WaitForSeconds(4.0f);
            }
            else if (processStep == 6)
            {
                processString = "Connecting";
                loadStage(processString);
                player.currentPlayer.data.internetConnected = true;
                yield return new WaitForSeconds(4.0f);
            }
           
        }
        statusText.text = "Connected";
        player.UpdateObjective("mainOneSubThree");
        webCrawlerIcon.SetActive(true);
        


    }

    public void loadStage(string processStage)
    {
        StartCoroutine(HandshakeSequence(processStage));
    }



    IEnumerator HandshakeSequence(string procesString)
    {

        statusText.text = procesString;

        foreach (char letter in loadText)
        {
            statusText.text += letter;
            yield return new WaitForSeconds(1.0f);
        }

        yield return new WaitForSeconds(1.5f);
        

    }
}
