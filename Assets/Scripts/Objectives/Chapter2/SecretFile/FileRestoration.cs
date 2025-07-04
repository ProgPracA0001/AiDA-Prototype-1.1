using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FileRestoration : MonoBehaviour
{
    public GameController controller;
    public GameObject LoadingScreenBar;

    public GameObject subjectFileNewParent;
    public GameObject subjectFileIcon;
    public Text subjectFileLabel;

    public int BarChildren;


    private void Start()
    {
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
        subjectFileIcon.transform.SetParent(subjectFileNewParent.transform);
        subjectFileLabel.text = "Subject ZERO";
        controller.currentPlayer.data.subject0Restored = true;
        gameObject.GetComponent<WindowControllerScript>().Close();
        controller.UpdateObjective("mainThreeSubTwo");
        controller.currentPlayer.Save();
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
