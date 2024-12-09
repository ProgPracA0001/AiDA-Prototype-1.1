using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GetProfiles : MonoBehaviour
{
   
    [SerializeField] public Text profileOneText;
    public Text profileTwoText;
    public Text profileThreeText;

    public GameObject newGameSequence;

    public PlayerManager playerManager;

    private bool profileOneNew;
    private bool profileTwoNew;
    private bool profileThreeNew;

    private void Start()
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
            playerManager.LoadPlayerGame();
            SceneManager.LoadScene("DesktopScene");

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
            playerManager.LoadPlayerGame();
            SceneManager.LoadScene("DesktopScene");
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
            playerManager.LoadPlayerGame();
            SceneManager.LoadScene("DesktopScene");
        }
    }


}
