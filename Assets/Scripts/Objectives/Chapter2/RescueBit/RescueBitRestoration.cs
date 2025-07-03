using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RescueBitRestoration : MonoBehaviour
{
    public GameController player;

    public RescueBit rescueBit;

    public GameObject Container;
    public GameObject File;

    public Text windowLabel;

    public string targetName;

    public GameObject loadingBarContainer;
    public GameObject LoadingScreenBar;

    public int BarChildren;


    public void Restore()
    {
        if (Container.transform.childCount != 0)
        {
            File = Container.transform.GetChild(0).gameObject;

            if (File.GetComponent<FileClass>().isCorrupted)
            {
                loadingBarContainer.SetActive(true);

                targetName = File.GetComponent<FileClass>().name;
                windowLabel.text = "Restoring File...";
                gameObject.GetComponent<WindowControllerScript>().Open();
                RestoreFile();
            }
            else
            {
                loadingBarContainer.SetActive(false);
                gameObject.GetComponent<WindowControllerScript>().Open();
                windowLabel.text = "File Already Restored";
            }
            

        }
        else
        {
            loadingBarContainer.SetActive(false);
            gameObject.GetComponent<WindowControllerScript>().Open();
            windowLabel.text = "No files in rescue bit";
        }
    }

    public void RestoreFile()
    {

        StartCoroutine(LoadBar());

    }

    void Update()
    {
        BarChildren = LoadingScreenBar.transform.childCount;

    }

    public void CheckFileDetailsForCompletion()
    {
        Debug.Log("Checking File: " + targetName);

        File.GetComponent<FileClass>().isCorrupted = false;
        File.GetComponent<FileClass>().fileIcon.sprite = File.GetComponent<FileClass>().restoredIcon;
        File.GetComponent<FileClass>().status = "Restored";

        if (targetName == "Diary05Icon")
        {
            Debug.Log("File is Diary");
            
            player.currentPlayer.data.diary05Corrupted = false;
            player.UpdateObjective("mainThreeSubOne");
            
            
        }
        else if(targetName == "Data_03Icon")
        {
            File.GetComponent<DraggableFile>().draggable = true;
            player.currentPlayer.data.data03Corrupted = false;


        }
        else
        {
            Debug.Log("Not Matching");
        }

        rescueBit.RestoreComplete();
        gameObject.GetComponent<WindowControllerScript>().Close();
    }


    private IEnumerator LoadBar()
    {
        BarChildren = LoadingScreenBar.transform.childCount;

        for (int i = 0; i < BarChildren; i++)
        {
            LoadingScreenBar.transform.GetChild(i).gameObject.SetActive(true);


            if (i == 7 || i == 8 || i == 12 || i == 13 || i == 14 || i == 18)
            {
                yield return new WaitForSeconds(3.0f);
            }
            else
            {
                yield return new WaitForSeconds(0.2f);
            }


        }
        Debug.Log("Loading Complete");
        CheckFileDetailsForCompletion();

        ResetLoad();
        gameObject.SetActive(false);

    }

    public void ResetLoad()
    {
        for (int i = 0; i < BarChildren; i++)
        {
            LoadingScreenBar.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
