using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScanTransfer : MonoBehaviour
{
    public Text descriptionLabel;
    public Image windowIcon;

    public string targetName;

    public GameObject LoadingScreenBar;
    public int BarChildren;

    public Sprite rescueBitImage;
    public Sprite corruptedDocumentImage;
    public Sprite restoredDocumentImage;

    public GameObject loadingContainer;
    public GameObject acceptContainer;
    public GameObject noFileFound;
    public GameObject transferBackContainer;

    public RescueBit RBScript;

    public GameObject rescueBitContainer;
   
    public GameObject diaryWindow;
    public GameObject diaryOriginalParent;
    public GameObject diary02Icon;



    // Start is called before the first frame update
    void Update()
    {
        BarChildren = LoadingScreenBar.transform.childCount;

    }

    public void Scan()
    {
        InitializeWindow();

        if (RBScript.detailsStored)
        {
            loadingContainer.SetActive(false);
            descriptionLabel.text = "File already in RescueBit";
            gameObject.GetComponent<WindowControllerScript>().Open();
        }
        else
        {
            gameObject.GetComponent<WindowControllerScript>().Open();

            ScanTransferLoad();
        }
            

    }

    public void Transfer()
    {
        GameObject transferIcon = rescueBitContainer.transform.GetChild(0).gameObject;
        InitializeWindow();
        loadingContainer.SetActive(false);
        transferBackContainer.SetActive(true);

        gameObject.GetComponent<WindowControllerScript>().Open();

        windowIcon.sprite = restoredDocumentImage;

        if(transferIcon.GetComponent<FileClass>().name == "Diary02Icon")
        {
            targetName = "diary02";
            descriptionLabel.text = "Diary02.txt ready for transfer";
        }

    }
    public void InitializeWindow()
    {
        targetName = null;

        windowIcon.sprite = rescueBitImage;
        descriptionLabel.text = "Scanning Files in Open Folders...";

        loadingContainer.SetActive(true);
        acceptContainer.SetActive(false);
        noFileFound.SetActive(false);
        transferBackContainer.SetActive(false);

    }

    public void ScanTransferLoad()
    {

        StartCoroutine(LoadBar());

    }
    
    public void ScanComplete()
    {
        loadingContainer.SetActive(false);
        

        if (diaryWindow.GetComponent<WindowControllerScript>().isOpen && diary02Icon.GetComponent<FileClass>().isCorrupted)
        {
            acceptContainer.SetActive(true);
            windowIcon.sprite = corruptedDocumentImage;
            descriptionLabel.text = "Corrupted File Found: Diary02.txt";
            targetName = "diary02";

        }
        else
        {
            noFileFound.SetActive(true);
            descriptionLabel.text = "No Files Found";
        }
    }

    public void ScanAgain()
    {
        descriptionLabel.text = "Scanning...";
        loadingContainer.SetActive(true);
        acceptContainer.SetActive(false);
        noFileFound.SetActive(false);
        ScanTransferLoad();
    }
    public void TransferToRB()
    {
        if(targetName == "diary02")
        {
            diary02Icon.GetComponent<FileClass>().inRescueBit = true;
            diary02Icon.transform.SetParent(rescueBitContainer.transform);

        }

        RBScript.CheckContainer();
        gameObject.GetComponent<WindowControllerScript>().Close();
    }

    public void TransferBack()
    {
        if(targetName == "diary02")
        {
            diary02Icon.GetComponent<FileClass>().inRescueBit = false;
            diary02Icon.transform.SetParent(diaryOriginalParent.transform);
        }

        RBScript.CheckContainer();

        gameObject.GetComponent<WindowControllerScript>().Close();

    }

    private IEnumerator LoadBar()
    {
        BarChildren = LoadingScreenBar.transform.childCount;

        for (int i = 0; i < BarChildren; i++)
        {
            LoadingScreenBar.transform.GetChild(i).gameObject.SetActive(true);


            if (i == 7 || i == 8 || i == 12 || i == 13 || i == 18)
            {
                yield return new WaitForSeconds(3.0f);
            }
            else
            {
                yield return new WaitForSeconds(0.2f);
            }


        }

        ScanComplete();
        ResetLoad();

    }

    public void ResetLoad()
    {
        for (int i = 0; i < BarChildren; i++)
        {
            LoadingScreenBar.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
