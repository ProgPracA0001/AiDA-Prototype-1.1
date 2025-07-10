using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RescueBit : MonoBehaviour
{

    public GameController controller;

    public GameObject rescueBitWelcome;

    public GameObject container;

    public GameObject runRestorationWindow;
    public GameObject alreadyRestoredWindow;

    public bool inContainer;

    public bool detailsStored;

    public GameObject transferButton;

    public Text filenameLabel;
    public Text filesizeLabel;
    public Text fileTypeLabel;

    public Text fileStatusLabel;
    public Text restorationTypeLabel;


    // Start is called before the first frame update
    void Start()
    {
        detailsStored = false;
        transferButton.SetActive(false);
        if (!controller.currentPlayer.data.recuseBitFirstTimeOpeningComplete)
        {
            rescueBitWelcome.GetComponent<WindowControllerScript>().Open();
            controller.currentPlayer.data.recuseBitFirstTimeOpeningComplete = true;
            controller.currentPlayer.Save();
        }

        CheckContainer();
    }

    public void CheckContainer()
    {
        if (container.transform.childCount != 0)
        {
            detailsStored = true;
            GameObject child = container.transform.GetChild(0).gameObject;
            GetFileDetails();

            if (child.GetComponent<FileClass>().isCorrupted == true)
            {
                transferButton.SetActive(false);
            }
            else
            {
                transferButton.SetActive(true);
            }
 
        }
        else
        {
            detailsStored=false;
            transferButton.SetActive(false);
            DefaultDetails();
        }
    }

    public void RestoreComplete()
    {
        DefaultDetails();
        CheckContainer();
    }
    public void GetFileDetails()
    {
        GameObject child = container.transform.GetChild(0).gameObject;

        filenameLabel.text += child.GetComponent<FileClass>().filename;
        filesizeLabel.text += child.GetComponent<FileClass>().fileSize;
        fileTypeLabel.text += child.GetComponent<FileClass>().fileType;

        fileStatusLabel.text += child.GetComponent<FileClass>().status;
        restorationTypeLabel.text += child.GetComponent<FileClass>().restorationType;
    }

    public void DefaultDetails()
    {
        filenameLabel.text = "Filename: ";
        filesizeLabel.text = "File Size: ";
        fileTypeLabel.text = "File Type: ";

        fileStatusLabel.text = "Status:";
        restorationTypeLabel.text = "Restoration Type: ";
    }

    public void Restore()
    {
        if(container.transform.childCount != 0)
        {
            runRestorationWindow.GetComponent<WindowControllerScript>().Open();
        }


    }
}
