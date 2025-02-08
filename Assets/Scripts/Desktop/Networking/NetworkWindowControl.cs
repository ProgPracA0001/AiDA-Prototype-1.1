using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Android.Gradle;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class NetworkWindowControl : MonoBehaviour
{

    public GameController player;

    public GameObject pageOne;

    public GameObject pageTwo;
    public Text computerNameInput;
    public string correctComputerName;
    public Text modemNameSelected;
    public string correctModemName;
    public Text errorTextPage2;


    public GameObject pageThree;
    public Text AreaCodeSelected;
    public string correctAreaCode;
    public Text TelephoneNoInput;
    public string correctTelephoneNo;
    public Text CountryCodeSelected;
    public string correctCountryCode;
    public Text errorTextPage3;


    public GameObject InstallWindow;

    public Text currentConnectionText;


    // Start is called before the first frame update
    void Start()
    {

        setFirstPage();
        currentConnectionText.text = "";
        Debug.Log(player.currentPlayer.data.internetLinkInstalled);

        if (player.currentPlayer.data.internetLinkInstalled == true)
        {
            
            currentConnectionText.text = "Link Installed: Test";
        }
        else
        {
           
            currentConnectionText.text = "No Connections";
        }

        
    }


    public void setFirstPage()
    {
        pageOne.SetActive(true);
        pageTwo.SetActive(false);
        pageThree.SetActive(false);
    }


    public void CheckPageTwo()
    {
        if (computerNameInput.text == correctComputerName && modemNameSelected.text == correctModemName)
        {
            pageTwo.SetActive(false);
            pageThree.SetActive(true);
        }
        else if (computerNameInput.text != correctComputerName && modemNameSelected.text == correctModemName)
        {
            errorTextPage2.text = "Computer name Unknown";
        }
        else if (computerNameInput.text == correctComputerName && modemNameSelected.text != correctModemName)
        {
            errorTextPage2.text = "This Modem Has no Connections";
        }
        else
        {
            errorTextPage2.text = "Computer name Unknown";
        }
    }

    public void CheckPageThree()
    {
        if (player.currentPlayer.data.internetLinkInstalled != true)
        {
            if (AreaCodeSelected.text == correctAreaCode && TelephoneNoInput.text == correctTelephoneNo && CountryCodeSelected.text == correctCountryCode)
            {
                gameObject.SetActive(false);
                setFirstPage();
                InstallWindow.SetActive(true);
            }
            else if (AreaCodeSelected.text != correctAreaCode && TelephoneNoInput.text == correctTelephoneNo && CountryCodeSelected.text == correctCountryCode)
            {
                errorTextPage3.text = "Area Code incorrect try again";

            }
            else if (AreaCodeSelected.text == correctAreaCode && TelephoneNoInput.text != correctTelephoneNo && CountryCodeSelected.text == correctCountryCode)
            {
                errorTextPage3.text = "Telephone Number incorrect try again";
            }
            else if (AreaCodeSelected.text == correctAreaCode && TelephoneNoInput.text == correctTelephoneNo && CountryCodeSelected.text != correctCountryCode)
            {
                errorTextPage3.text = "Country Code incorrect try again";
            }
        }
        else
        {
            errorTextPage3.text = "This Link has already been installed";
        }
    }

}
