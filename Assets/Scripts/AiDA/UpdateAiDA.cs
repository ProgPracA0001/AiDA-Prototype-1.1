using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpdateAiDA : MonoBehaviour
{
    //Main Components
    public GameController controller;


    //AiDA Components
    public GameObject AiDAWindow;
    public GameObject subjectZeroFileWindow;
    public GameObject[] subjectZeroSlots = new GameObject[6];

    public bool subjectZeroSlotFound = false;
    

    //BIOS Components
    public GameObject BIOSGridslot;
    public Text FileDetectionLabel;


    //Install Window Components
    public GameObject updateWindow;
    public GameObject LoadingScreenBarContainer;
    public GameObject LoadingScreenBar;

    public int BarChildren;

    //Trust System Components
    public bool trustSlotFound;
    public GameObject TrustFileIcon;
    public GameObject[] TrustFileSlots = new GameObject[7];

    void Update()
    {
        BarChildren = LoadingScreenBar.transform.childCount;

    }

    public void CheckBIOSContainer()
    {
      

        if (BIOSGridslot.transform.childCount != 0)
        {
            GameObject File = BIOSGridslot.transform.GetChild(0).gameObject;
            AiDAKnowledgeFile systemFile = File.GetComponent<AiDAKnowledgeFile>();
            FileDetectionLabel.text = "File Detected: " + systemFile.filename ;

        }
        else
        {
            FileDetectionLabel.text = "File Detected: Empty";
        }
    }


    public void moveToAiDAFileSlot(GameObject targetIcon)
    {
        foreach(GameObject slot in subjectZeroSlots)
        {
            if (slot.transform.childCount == 0)
            {
                subjectZeroSlotFound = true;
                targetIcon.transform.SetParent(slot.transform);
                break;
            }
        }

        if(subjectZeroSlotFound)
        {
            Debug.Log("Empty Slot Found!");
        }
        else
        {
            Debug.Log("There are no Empty Slots");
        }
    }

    public void NextTrustGridSlot()
    {
        foreach(GameObject trustSlot in TrustFileSlots)
        {
            if(trustSlot.transform.childCount == 0)
            {
                trustSlotFound = true;
                TrustFileIcon.transform.SetParent(trustSlot.transform);
                break;
            }

        }

        if (trustSlotFound)
        {
            Debug.Log("Empty Slot Found!");
        }
        else
        {
            Debug.Log("There are no Empty Slots");
        }
    }

    public void Compile()
    {
        if (BIOSGridslot.transform.childCount != 0)
        {
            GameObject File = BIOSGridslot.transform.GetChild(0).gameObject;
            AiDAKnowledgeFile systemFile = File.GetComponent<AiDAKnowledgeFile>();

            if (systemFile.filename == "Trust_Data.sys")
            {
                InstallTrustSystem();
            }
            else
            {
                Debug.Log("Can Compile");
            }
            
        }
        else
        {
            Debug.Log("No file to compile");
        }
    }


    public void InstallTrustSystem()
    {
        if (AiDAWindow.GetComponent<WindowControllerScript>().isOpen)
        {
            AiDAWindow.GetComponent<WindowControllerScript>().Close();
        }

        RunUpdate();

        updateWindow.GetComponent<WindowControllerScript>().Close();
        controller.currentPlayer.data.trustSystemInstalled = true;
        controller.currentPlayer.Save();
        TrustFileIcon.SetActive(true);
        GameObject File = BIOSGridslot.transform.GetChild(0).gameObject;
        Destroy(File);
        AiDAWindow.GetComponent<WindowControllerScript>().Open();
        AiDAWindow.GetComponent<AiDA>().ActivateTrustSystem();
        

    }

  
    public void RunUpdate()
    {
        updateWindow.GetComponent<WindowControllerScript>().Open();
        StartCoroutine(LoadBar());
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
        yield return new WaitForSeconds(2);

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
