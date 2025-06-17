using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class SecretFile : MonoBehaviour
{
    public GameController controller;

    public GameObject subjectIcon;
    public GameObject ZIcon;
    public GameObject EIcon;
    public GameObject RIcon;
    public GameObject OIcon;

    public GameObject subjectContainer;
    public GameObject ZContainer;
    public GameObject EContainer;
    public GameObject RContainer;
    public GameObject OContainer;

    public bool fileFound;

    public bool allCorrect;
    public bool subjectCorrect;
    public bool ZCorrect;
    public bool ECorrect;
    public bool RCorrect;
    public bool OCorrect;

    public Text subjectIconLabel;

    public GameObject hiddenWindow;
    public GameObject FoundWindow;


    public void checkIfFileFound()
    {
        if(controller.currentPlayer.data.mainObjSubThree_TwoComplete && controller.currentPlayer.data.currentChapter >= 2)
        {
            fileFound = true;
        }
        else
        {
            fileFound = false;
            FileNotFound();
        }
    }

    public void FileNotFound() 
    {
        allCorrect = false;
        subjectCorrect = false;
        ZCorrect = false;
        ECorrect = false;
        RCorrect = false;
        OCorrect = false;
    }

    public void FileFound()
    {

    }

    public void OpenFile()
    {
        if (fileFound)
        {
            FoundWindow.GetComponent<WindowControllerScript>().Open();
        }
        else
        {
            hiddenWindow.GetComponent<WindowControllerScript>().Open();
        }
    }

    public void validateAllPositions()
    {
        CheckFilePosition(subjectContainer, "subject",ref subjectCorrect);
        CheckFilePosition(ZContainer, "Z", ref  ZCorrect);
        CheckFilePosition(EContainer, "E", ref ECorrect);
        CheckFilePosition(RContainer, "R", ref RCorrect);
        CheckFilePosition(OContainer, "O", ref OCorrect);

        if(subjectCorrect && ZCorrect &&  ECorrect && RCorrect && OCorrect)
        {
            allCorrect = true;
        }

        if (allCorrect)
        {
            fileFound = true;
            Destroy(ZIcon);
            Destroy(EIcon);
            Destroy(RIcon);
            Destroy(OIcon);
            
            subjectIconLabel.text = "Subject 0";

        }

    }

    public void CheckFilePosition(GameObject containerName, string correctTarget, ref bool correct)
    {
        if (containerName.transform.childCount != 0)
        {
            GameObject child = containerName.transform.GetChild(0).gameObject;

            if (child.name == correctTarget)
            {
                correct = true;
            }
        } 

    }
}
