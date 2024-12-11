using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GetProfiles : MonoBehaviour
{
    public Text profileOneText;
    public Text profileTwoText;
    public Text profileThreeText;
    public Text profileFourText;
    public Text profileFiveText;
    public Text profileSixText;

    public Text playerUsername;
    public Text playerFirstName;
    public Text playerLastName;
    public Text playerCurrentChapter;

    public GameObject profilePage;
    public GameObject newGameSequence;

    public PlayerManager playerManager;

    private bool profileOneNew;
    private bool profileTwoNew;
    private bool profileThreeNew;
    private bool profileFourNew;
    private bool profileFiveNew;
    private bool profileSixNew;

    void Start()
    {
        LoadProfiles();

    }

    public void LoadProfiles()
    {
        playerManager.LoadAll();
        if (playerManager.playerOneEmpty)
        {
            profileOneText.text = "New Game";
            profileOneNew = true;
        }
        else
        {
            profileOneText.text = playerManager.playerOneData.firstName + " " + playerManager.playerOneData.lastName;
        }

        if (playerManager.playerTwoEmpty)
        {
            profileTwoText.text = "New Game";
            profileTwoNew = true;
        }
        else
        {
            profileTwoText.text = playerManager.playerTwoData.firstName + " " + playerManager.playerTwoData.lastName;
        }

        if (playerManager.playerThreeEmpty)
        {
            profileThreeText.text = "New Game";
            profileThreeNew = true;
        }
        else
        {
            profileThreeText.text = playerManager.playerThreeData.firstName + " " + playerManager.playerThreeData.lastName;
        }

        if (playerManager.playerFourEmpty)
        {
            profileFourText.text = "New Game";
            profileFourNew = true;
        }
        else
        {
            profileFourText.text = playerManager.playerFourData.firstName + " " + playerManager.playerFourData.lastName;
        }

        if (playerManager.playerFiveEmpty)
        {
            profileFiveText.text = "New Game";
            profileFiveNew = true;
        }
        else
        {
            profileFiveText.text = playerManager.playerFiveData.firstName + " " + playerManager.playerFiveData.lastName;
        }

        if (playerManager.playerSixEmpty)
        {
            profileSixText.text = "New Game";
            profileSixNew = true;
        }
        else
        {
            profileSixText.text = playerManager.playerSixData.firstName + " " + playerManager.playerSixData.lastName;
        }
    }

    public void BackButton()
    {
        gameObject.SetActive(true);
        profilePage.SetActive(false);
        playerManager.LoadAll();
        playerManager.playerSelected(null);
        Debug.Log(playerManager.selectedPlayer);

    }

    public void ResumeGame()
    {
        playerManager.LoadPlayerGame();
        SceneManager.LoadScene("DesktopScene");
    }

    public void DeleteProfile()
    {
        playerManager.DeletePlayer();
        gameObject.SetActive(true);
        profilePage.SetActive(false);
        LoadProfiles();
    }

    public void DisplayProfile()
    {
        gameObject.SetActive(false);
        profilePage.SetActive(true);
        playerUsername.text = playerManager.data.username;
        playerFirstName.text = playerManager.data.firstName;
        playerLastName.text = playerManager.data.lastName;
        playerCurrentChapter.text = playerManager.data.currentChapterName;
    }

    public void SelectProfileOne()
    {
        if (profileOneNew)
        {
            profileOneNew = false;
            gameObject.SetActive(false);
            newGameSequence.SetActive(true);
            playerManager.playerSelected("playerOne");
            Debug.Log(playerManager.selectedPlayer);


        }
        else
        {
            playerManager.playerSelected("playerOne");
            Debug.Log(playerManager.selectedPlayer);
            DisplayProfile();

        }
    }
    public void SelectProfileTwo()
    {
        if (profileTwoNew)
        {
            profileTwoNew = false;
            gameObject.SetActive(false);
            newGameSequence.SetActive(true);
            playerManager.playerSelected("playerTwo");

        }
        else
        {
            playerManager.playerSelected("playerTwo");
            Debug.Log(playerManager.selectedPlayer);
            
            DisplayProfile();
        }
    }
    public void SelectProfileThree()
    {
        if (profileThreeNew)
        {
            profileThreeNew = false;
            gameObject.SetActive(false);
            newGameSequence.SetActive(true);
            playerManager.playerSelected("playerThree");

        }
        else
        {
            playerManager.playerSelected("playerThree");
            Debug.Log(playerManager.selectedPlayer);

            DisplayProfile();
        }
    }

    public void SelectProfileFour()
    {
        if (profileFourNew)
        {
            profileFourNew = false;
            gameObject.SetActive(false);
            newGameSequence.SetActive(true);
            playerManager.playerSelected("playerFour");

        }
        else
        {
            playerManager.playerSelected("playerFour");
            Debug.Log(playerManager.selectedPlayer);

            DisplayProfile();
        }
    }

    public void SelectProfileFive()
    {
        if (profileFiveNew)
        {
            profileFiveNew = false;
            gameObject.SetActive(false);
            newGameSequence.SetActive(true);
            playerManager.playerSelected("playerFive");

        }
        else
        {
            playerManager.playerSelected("playerFive");
            Debug.Log(playerManager.selectedPlayer);

            DisplayProfile();
        }
    }

    public void SelectProfileSix()
    {
        if (profileSixNew)
        {
            profileSixNew = false;
            gameObject.SetActive(false);
            newGameSequence.SetActive(true);
            playerManager.playerSelected("playerSix");

        }
        else
        {
            playerManager.playerSelected("playerSix");
            Debug.Log(playerManager.selectedPlayer);

            DisplayProfile();
        }
    }


}
