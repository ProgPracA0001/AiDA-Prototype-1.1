using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FileClass: MonoBehaviour
{
    public GameController controller;

    public GameObject corruptedWindow;
    public GameObject restoredWindow;

    public string filename;

    public string status;
    public string restorationType;

    public string fileSize;

    public string fileType;

    public string fileName;

    public Image fileIcon;

    public Sprite corruptedIcon;
    public Sprite restoredIcon;


    public bool isCorrupted;
    public bool inRescueBit = false;

    void Start()
    {
        CheckIfRestored();
    }
    public void CheckIfRestored()
    {
        Debug.Log("Running: CheckIfFRestored");

        Debug.Log("Filename: " + filename);

        if(filename == "diary05")
        {
            
            isCorrupted = controller.currentPlayer.data.diary05Corrupted;
            

        }
        else if(filename == "XFile")
        {
            isCorrupted = controller.currentPlayer.data.XFileCorrupted;
        }

        if (isCorrupted)
        {
            fileIcon.sprite = corruptedIcon;

            status = "Corrupted";

        }
        else
        {
            fileIcon.sprite = restoredIcon;

            status = "Restored";
        }


    }

    public void OpenWindow()
    {
        if (!inRescueBit)
        {
            if (isCorrupted)
            {
                corruptedWindow.GetComponent<WindowControllerScript>().Open();

            }
            else
            {
                restoredWindow.GetComponent<WindowControllerScript>().Open();
            }
        }
        
    }

}
