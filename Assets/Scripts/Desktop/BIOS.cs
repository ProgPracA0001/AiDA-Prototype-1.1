using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BIOS : MonoBehaviour
{
    //Main Objects for BIOS
    public GameController controller;

    public GameObject BIOSAssignAdmin;

    public GameObject MenuPage;
    public GameObject UserPrivilegePage;
    public GameObject BootConfigPage;
    public GameObject SystemMemoryPage;

    public InputField userPasswordInput;
    private string adminPassword = "EmotionTimeGreetings";

    public GameObject ErrorWindow;
    public Text errorLabel;


    //User Privileges Page

    public Text usernameLabel;
    public bool userIsAdmin;
    public Text adminStatusLabel;

    public Toggle adminToggle;


    void Start()
    {
        MenuPage.SetActive(true);
        UserPrivilegePage.SetActive(false);
        BootConfigPage.SetActive(false);
        SystemMemoryPage.SetActive(false);
    }

    public void OnToggleChange()
    {
        if (controller.currentPlayer.data.playerIsAdmin)
        {
            adminToggle.isOn = true;
            LoadError("Admin Status already assigned. Cannot undo this change.");
        }
        else
        {
            BIOSAssignAdmin.GetComponent<WindowControllerScript>().Open();
        }
    }

    public void ChangeToAdmin()
    {
        if (userPasswordInput.text == adminPassword)
        {
            controller.currentPlayer.data.playerIsAdmin = true;
            controller.UpdateObjective("sideTwoSubTwo");
            BIOSAssignAdmin.GetComponent<WindowControllerScript>().Close();
        }
    }
    public void LoadUserPrivileges()
    {
        userIsAdmin = controller.currentPlayer.data.playerIsAdmin;

        usernameLabel.text = controller.currentPlayer.data.username;

        if(userIsAdmin)
        {
            
            adminStatusLabel.text = "Admin";
            adminToggle.isOn = true;
        }
        else
        {
            adminStatusLabel.text = "Guest";
            adminToggle.isOn = false;
        }


        MenuPage.SetActive(false);
        UserPrivilegePage.SetActive(true);
        BootConfigPage.SetActive(false);
        SystemMemoryPage.SetActive(false);


    }


    public void LoadBootConfiguration()
    {
        MenuPage.SetActive(false);
        UserPrivilegePage.SetActive(false);
        BootConfigPage.SetActive(true);
        SystemMemoryPage.SetActive(false);
    }

    public void CheckSubjectZero()
    {
        if (controller.currentPlayer.data.AiDAInstalled)
        {
            LoadSystemMemoryChecks();
        }
        else
        {
            LoadError("Unable to load System Memory Checks. Install Subject 0 to access.");
        }
    }

    public void LoadSystemMemoryChecks()
    {

        MenuPage.SetActive(false);
        UserPrivilegePage.SetActive(false);
        BootConfigPage.SetActive(false);
        SystemMemoryPage.SetActive(true);
    }

    public void Back()
    {
        MenuPage.SetActive(true);
        UserPrivilegePage.SetActive(false);
        BootConfigPage.SetActive(false);
        SystemMemoryPage.SetActive(false);
    }

    public void LoadError(string error)
    {
        ErrorWindow.GetComponent<WindowControllerScript>().Open();
        errorLabel.text = error;
    }


}
