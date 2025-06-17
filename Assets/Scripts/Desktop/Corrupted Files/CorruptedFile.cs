using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Pool;

public class CorruptedFile : MonoBehaviour
{
    public FileClass targetFile;

    public GameObject corruptedWindow;
    public GameObject restoredWindow;

    public bool corrupted;

    void Start()
    {
        corrupted = targetFile.isCorrupted;
    }

    public void checkCorruptionStatus()
    {
        if (corrupted)
        {
            corruptedWindow.GetComponent<WindowControllerScript>().Open();

        }
        else
        {
            restoredWindow.GetComponent<WindowControllerScript>().Open();
        }

    }


}
