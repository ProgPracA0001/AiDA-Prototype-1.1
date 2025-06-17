using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RescueBitInstall : MonoBehaviour
{
    public GameController player;

    public GameObject LoadingScreenBar;
    public GameObject RescueBitIcon;

    public int BarChildren;

    // Start is called before the first frame update
    void Start()
    {
        InstallLink();
    }

    public void InstallLink()
    {

        StartCoroutine(LoadBar());

    }

    void Update()
    {
        BarChildren = LoadingScreenBar.transform.childCount;

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

        player.currentPlayer.data.RescureBitInstalled = true;
        player.currentPlayer.Save();
        ResetLoad();
        RescueBitIcon.SetActive(true);
        gameObject.SetActive(false);

    }

    public void ResetLoad()
    {
        for (int i = 0; i < BarChildren; i++)
        {
            LoadingScreenBar.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
