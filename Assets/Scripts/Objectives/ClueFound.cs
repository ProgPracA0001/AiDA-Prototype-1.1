using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class ClueFound : MonoBehaviour
{
    public GameController player;

    public string objective;

    public void UpdateObjective()
    {
        if (objective == "mainOneSubOne")
        {
            if (!player.currentPlayer.data.mainObjSubOne_OneComplete)
            {
                player.currentPlayer.data.mainObjSubOne_OneComplete = true;
                player.UpdatePlayer();
            }
        }
        else if (objective == "mainOneSubTwo")
        {
            if (!player.currentPlayer.data.mainObjSubOne_TwoComplete)
            {
                player.currentPlayer.data.mainObjSubOne_TwoComplete = true;
                player.UpdatePlayer();
            }
        }
        else if (objective == "mainOneSubThree")
        {
            if (!player.currentPlayer.data.mainObjSubOne_ThreeComplete)
            {
                player.currentPlayer.data.mainObjSubOne_ThreeComplete = true;
                player.UpdatePlayer();
            }
        }
        else if (objective == "mainTwoSubOne")
        {
            if (!player.currentPlayer.data.mainObjSubTwo_OneComplete)
            {
                player.currentPlayer.data.mainObjSubTwo_OneComplete = true;
                player.UpdatePlayer();
            }
        }
        else if (objective == "mainTwoSubTwo")
        {
            if (!player.currentPlayer.data.mainObjSubTwo_TwoComplete)
            {
                player.currentPlayer.data.mainObjSubTwo_TwoComplete = true;
                player.UpdatePlayer();
            }
        }
        else if (objective == "mainTwoSubThree")
        {
            if (!player.currentPlayer.data.mainObjSubTwo_ThreeComplete)
            {
                player.currentPlayer.data.mainObjSubTwo_ThreeComplete = true;
                player.UpdatePlayer();
            }
        }
        else if (objective == "mainThreeSubOne")
        {
            if (!player.currentPlayer.data.mainObjSubThree_OneComplete)
            {
                player.currentPlayer.data.mainObjSubThree_OneComplete = true;
                player.UpdatePlayer();
            }
        }
        else if (objective == "mainThreeSubTwo")
        {
            if (!player.currentPlayer.data.mainObjSubThree_TwoComplete)
            {
                player.currentPlayer.data.mainObjSubThree_TwoComplete = true;
                player.UpdatePlayer();
            }
        } 
        else if (objective == "mainThreeSubThree")
        {
            if (!player.currentPlayer.data.mainObjSubThree_ThreeComplete)
            {
                player.currentPlayer.data.mainObjSubThree_ThreeComplete = true;
                player.UpdatePlayer();
            }
        }
        else if (objective == "sideOneSubOne")
        {
            if (!player.currentPlayer.data.sideObjSubOne_OneComplete)
            {
                player.currentPlayer.data.sideObjSubOne_OneComplete = true;
                player.UpdatePlayer();
            }
        }
        else if (objective == "sideOneSubTwo")
        {
            if (!player.currentPlayer.data.sideObjSubOne_TwoComplete)
            {
                player.currentPlayer.data.sideObjSubOne_TwoComplete = true;
                player.UpdatePlayer();
            }
        }
        else if(objective == "sideOneSubThree")
        {
            if (!player.currentPlayer.data.sideObjSubOne_ThreeComplete)
            {
                player.currentPlayer.data.sideObjSubOne_ThreeComplete = true;
                player.UpdatePlayer();
            }
        }
        else if (objective == "sideTwoSubOne")
        {
            if (!player.currentPlayer.data.sideObjSubTwo_OneComplete)
            {
                player.currentPlayer.data.sideObjSubTwo_OneComplete = true;
                player.UpdatePlayer();
            }
        }
        else if (objective == "sideTwoSubTwo")
        {
            if (!player.currentPlayer.data.sideObjSubTwo_TwoComplete)
            {
                player.currentPlayer.data.sideObjSubTwo_TwoComplete = true;
                player.UpdatePlayer();
            }
        }
        else if(objective == "sideTwoSubTwo")
        {
            if (!player.currentPlayer.data.sideObjSubTwo_ThreeComplete)
            {
                player.currentPlayer.data.sideObjSubTwo_ThreeComplete = true;
                player.UpdatePlayer();
            }
        }
    }
}
