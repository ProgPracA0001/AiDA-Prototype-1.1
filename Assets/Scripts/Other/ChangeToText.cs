using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeToText : MonoBehaviour
{

    public GameObject NotesPage;
    public GameObject TextConversion;

    public Text ButtonText;

    public bool isText;

    // Start is called before the first frame update
    void Start()
    {
        isText = false;

        ButtonText.text = "Change To Text";

        NotesPage.SetActive(true);
        TextConversion.SetActive(false);

    }


    public void ConvertBetweenMedia()
    {
        if (!isText)
        {
            isText = true;

            ButtonText.text = "Change To Image";

            NotesPage.SetActive(false);
            TextConversion.SetActive(true);

        }
        else
        {
            isText = false;

            ButtonText.text = "Change To Text";

            NotesPage.SetActive(true);
            TextConversion.SetActive(false);
        }
    }

}

