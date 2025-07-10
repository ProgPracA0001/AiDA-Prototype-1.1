using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class SecretFile : MonoBehaviour
{
    public GameController controller;

    public GameObject testWindow;
    public GameObject hiddenWindow;

    public GameObject RestrictedSectionWindow;

    public GameObject errorWindow;

    public GameObject newSubjectParent;
    public GameObject subjectIcon;
    public Text subjectLabel;

    public GameObject dataIcon01;
    public GameObject dataIcon02;
    public GameObject dataIcon03;
    public GameObject dataIcon04;
    public GameObject dataIcon05;
    public GameObject dataIcon06;
    public GameObject dataIcon07;
    public GameObject dataIcon08;
    public GameObject dataIcon09;
    public GameObject dataIcon10;
    public GameObject dataIcon11;
    public GameObject dataIcon12;
    public GameObject dataIcon13;
    public GameObject dataIcon14;

    public GameObject additionalDataIcon;
    public GameObject additionalDataWindow;

    public GameObject dataFile01;
    public GameObject dataFile02;
    public GameObject dataFile03;
    public GameObject dataFile04;
    public GameObject dataFile05;
    public GameObject dataFile06;
    public GameObject dataFile07;
    public GameObject dataFile08;
    public GameObject dataFile09;
    public GameObject dataFile10;
    public GameObject dataFile11;
    public GameObject dataFile12;
    public GameObject dataFile13;
    public GameObject dataFile14;

    public Text errorLabel;

    public GameObject[] slots = new GameObject[12];

    public Text FullStatusLabel;
    public Text FileSizeLabel;
    public Text FileContents;
    public Text TimeStatusLabel;
    public Text EmotionStatusLabel;
    public Text GreetingsStatusLabel;

    public float total = 100.00f;
    public float totalRestoration = 000.00f;

    public int FileSize = 0;
    public int NoOfFiles = 0;

    public bool timeRestoration = false;
    public bool emotionRestoration = false;
    public bool greetingRestoration = false;

    public int totalTimeFiles = 4;
    public int totalEmotionFiles = 4;
    public int totalGreetingsFiles = 3;

    public GameObject RestorationFileWindow;



    void Start()
    {
        LoadSubjectFileDetails();
    }

    public void LoadSubjectFileDetails()
    {
        FullStatusLabel.text = "Restored: " + totalRestoration + "%";
        FileSizeLabel.text = "File Size: " + FileSize + "GB";
        FileContents.text = "Contents: " + FileContents.ToString();
        TimeStatusLabel.text = "Time: " + timeRestoration.ToString();
        EmotionStatusLabel.text = "Emotion: " + emotionRestoration.ToString();
        GreetingsStatusLabel.text = "Greeting: " + greetingRestoration.ToString();
    }
    public void OpenFile()
    {
        if (!controller.currentPlayer.data.subject0Restored)
        {
            testWindow.GetComponent<WindowControllerScript>().Open();
        }
        else
        {
            hiddenWindow.GetComponent<WindowControllerScript>().Open();
        }
    }

    public void CheckRestorationStatus()
    {
        if (timeRestoration && emotionRestoration && greetingRestoration)
        {
            Destroy(additionalDataWindow);
            Destroy(additionalDataIcon);
            RestoreFile();
        }
    }

    public void CompileGroup(string group)
    {
        if (group == "Emotion")
        {
            emotionRestoration = true;
            controller.currentPlayer.data.emotionRestored = true;

            NoOfFiles += 1;
            FileSize += 28;

            Destroy(dataIcon02);
            Destroy(dataIcon01);
            Destroy(dataIcon05);
            Destroy(dataIcon09);
            Destroy(dataIcon14);

        }
        else if (group == "Time")
        {
            timeRestoration = true;
            controller.currentPlayer.data.timeRestored = true;

            NoOfFiles += 1;
            FileSize += 36;

            Destroy(dataIcon06);
            Destroy(dataIcon04);
            Destroy(dataIcon08);
            Destroy(dataIcon10);
            Destroy(dataIcon12);

        }
        else if (group == "Greetings")
        {
            greetingRestoration = true;
            controller.currentPlayer.data.greetingsRestored = true;

            NoOfFiles += 1;
            FileSize += 48;

            Destroy(dataIcon11);
            Destroy(dataIcon03);
            Destroy(dataIcon07);
            Destroy(dataIcon13);
        }

        LoadSubjectFileDetails();
        CheckRestorationStatus();
    }

    public void RestoreFile()
    {
        RestorationFileWindow.GetComponent<WindowControllerScript>().Open();

        testWindow.GetComponent<WindowControllerScript>().Close();
        
        RestrictedSectionWindow.GetComponent<WindowControllerScript>().Open();

    }

    public void FileRestored()
    {

        subjectIcon.transform.SetParent(newSubjectParent.transform);
        subjectLabel.text = "Subject ZERO";

        Destroy(dataIcon02);
        Destroy(dataIcon01);
        Destroy(dataIcon05);
        Destroy(dataIcon09);
        Destroy(dataIcon14);
        Destroy(dataIcon06);
        Destroy(dataIcon04);
        Destroy(dataIcon08);
        Destroy(dataIcon10);
        Destroy(dataIcon12);
        Destroy(dataIcon11);
        Destroy(dataIcon03);
        Destroy(dataIcon07);
        Destroy(dataIcon13);

        Destroy(additionalDataIcon);
        Destroy(additionalDataWindow);
    }

    public int AssignTotalFileCount(string group)
    {
        if (group == "Time")
        {
            return totalTimeFiles;
        }
        else if (group == "Emotion")
        {
            return totalEmotionFiles;
        }
        else if (group == "Greetings")
        {
            return totalGreetingsFiles;
        }
        return 0;
    }
    public void CheckFiles(string group)
    {
        int matchingFiles = 0;
        int nonMatchingFiles = 0;

        int fileCount = AssignTotalFileCount(group);

        for (int i = 1; i < slots.Length; i++)
        {
            if (slots[i].transform.childCount != 0)
            {
                
                DataFile data = slots[i].transform.GetChild(0).gameObject.GetComponent<DataFile>();

                if(data.dataGroup == group)
                {
                    matchingFiles++;
                }
                else
                {
                    nonMatchingFiles++;
                }
                
            }

        }

        Debug.Log("Group: " + group);
        Debug.Log("Total Files Needed: " + fileCount);

        Debug.Log("Matching Files: " + matchingFiles);
        Debug.Log("NON-Matching Files: " + nonMatchingFiles);

        if (matchingFiles == fileCount && nonMatchingFiles == 0)
        {
            Debug.Log("SUCCESS: COMPILING: " + group);
            CompileGroup(group);
        }
        else if(matchingFiles == fileCount && nonMatchingFiles > 0)
        {
            CompileError("All files for: " + group + " have been found. Remove all unrelated files for compiling to be successful.");
        }
        else if(matchingFiles < fileCount && nonMatchingFiles > 0)
        {
            CompileError("Documents for " + group + " are still missing. Unrelated files also detected.");
        }
        else if(matchingFiles > 0 && nonMatchingFiles == 0)
        {
            CompileError("Matching documents for " + group + " are still missing. No unrelated documents are detected.");
        }
        else if(matchingFiles == 0 && nonMatchingFiles > 0)
        {
            CompileError("All documents detected are unrelated to " + group);
        }
        else
        {
            CompileError("Slots are empty. Drag files into the slots for successful compiling.");
        }
    }


    public void CompileDocuments()
    {
        if (errorWindow.GetComponent<WindowControllerScript>().isOpen)
        {
            errorWindow.GetComponent<WindowControllerScript>().Close();
        }

        if (slots[0].transform.childCount != 0)
        {
            DataFile data = slots[0].transform.GetChild(0).gameObject.GetComponent<DataFile>();

            if (data.fileType == "Head")
            {
                CheckFiles(data.dataGroup);
            }
            else
            {
                CompileError("The document contained within the HEAD slot is of type: DATA. Make sure the document placed in the first slot is of type: HEAD.");

            }
        }
        else
        {
            CompileError("No HEAD document assigned in the first slot.");
        }


    }
    
    public void CompileError(string error)
    {
        errorWindow.GetComponent<WindowControllerScript>().Open();
        errorLabel.text = "COMPILE ERROR: " + error;
    }

}
