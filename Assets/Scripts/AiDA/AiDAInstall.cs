using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AiDAInstall : MonoBehaviour
{
    public GameController controller;

    public GameObject AiDAInstallation;

    public GameObject alreadyInstalledWindow;

    public Text responseText;

    public InputField filenameInput;
    private string filename = "AiDA";

    public InputField ConfigInput;
    private string configString = "Z0.MODEL.SET:EXTYPE_03/INLAY_ACTIVE/WATCHDOG_TRUE";

    public Toggle greetingToggle;
    public Toggle trustToggle;
    public Toggle emotionToggle;

    public Toggle dataAndExamples;

    public Text epochSelected;

    public void RunAiDAInstall()
    {
        if (!controller.currentPlayer.data.AiDAInstalled)
        {
            gameObject.GetComponent<WindowControllerScript>().Open();
        }
        else
        {
            alreadyInstalledWindow.GetComponent<WindowControllerScript>().Open();
        }
    }
    public void CheckInstallSettings()
    {
        
            if (filenameInput.text == filename && greetingToggle.isOn == false && trustToggle.isOn == true && emotionToggle.isOn == false && dataAndExamples.isOn == true && epochSelected.text == "20" && ConfigInput.text == configString)
            {
                gameObject.GetComponent<WindowControllerScript>().Close();
                AiDAInstallation.GetComponent<WindowControllerScript>().Open();
            }
            else
            {
                responseText.text = "Incorrect Installation Settings";
            }
      
       
        
    }
}
