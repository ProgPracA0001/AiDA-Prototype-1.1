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
    public GameObject loadingScreenBarContainer;
    public GameObject loadingScreenBar;

    public int barChildren;

    //Trust System Components
    public bool trustSlotFound;
    public GameObject TrustFileIcon;
    public GameObject[] TrustFileSlots = new GameObject[7];


    
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
            FileDetectionLabel.text = "File Detected: ";
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
                Debug.Log("Install Trust System");
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



}
