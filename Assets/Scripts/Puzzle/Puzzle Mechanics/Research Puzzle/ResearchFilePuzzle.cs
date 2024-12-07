using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class ResearchFilePuzzle : MonoBehaviour
{
    public GameObject containerT;
    public GameObject containerR;
    public GameObject containerA;
    public GameObject containerN;
    public GameObject containerS;
    public GameObject containerP;
    public GameObject containerA2;
    public GameObject containerR2;
    public GameObject containerE;
    public GameObject containerN2;
    public GameObject containerT2;

    public Text hintText;
    public string hint;

    private bool correctT;
    private bool correctR;
    private bool correctA;
    private bool correctN;
    private bool correctS;
    private bool correctP;
    private bool correctA2;
    private bool correctR2;
    private bool correctE;
    private bool correctN2;
    private bool correctT2;

    private bool allCorrect;

    public GameObject lockedWindow;
    public GameObject unlockedWindow;

    public Puzzle puzzle;
    private int attempts;


    // Start is called before the first frame update
    void Start()
    {
        correctT = false;
        correctR = false;
        correctA = false;
        correctN = false;
        correctS = false;
        correctP = false;
        correctA2 = false;
        correctR2 = false;
        correctE = false;
        correctN2 = false;
        correctT2 = false;
        allCorrect = false;

        attempts = 0;

        if(puzzle == null)
        {
            puzzle = new Puzzle();
        }

    }

    public void checkIfPuzzleSolved()
    {
        if (puzzle.solved)
        {
            unlockedWindow.SetActive(true);
        }
        else if (!puzzle.solved) 
        {
            lockedWindow.SetActive(true);
        }
    }


    public void ValidateInputs()
    {
        CheckContainer(containerT, "ItemT",ref correctT);
        CheckContainer(containerR, "ItemR",ref correctR);
        CheckContainer(containerA, "ItemA",ref correctA);
        CheckContainer(containerN, "ItemN",ref correctN);
        CheckContainer(containerS, "ItemS",ref correctS);
        CheckContainer(containerP, "ItemP",ref correctP);
        CheckContainer(containerA2, "ItemA",ref correctA2);
        CheckContainer(containerR2, "ItemR",ref correctR2);
        CheckContainer(containerE, "ItemE",ref correctE);
        CheckContainer(containerN2, "ItemN",ref correctN2);
        CheckContainer(containerT2, "ItemT",ref correctT2);

        if (correctT && correctR &&  correctA && correctN && correctS && correctP && correctA2 && correctR2 && correctE && correctN2 && correctT2)
        {
            allCorrect = true;
        }

        if (allCorrect)
        {
            puzzle.solved = true;
            lockedWindow.SetActive(false);
            unlockedWindow.SetActive(true);

        }
        else if (attempts == 4)
        {
            hintText.text = hint;
        }
        attempts++;
    }

    public void CheckContainer(GameObject containerName, string correctTarget,ref bool targetCorrect)
    {
       if (containerName.transform.childCount != 0)
        {
            GameObject child = containerName.transform.GetChild(0).gameObject;

            if (child.name == correctTarget)
            {
                targetCorrect = true;
                containerName.GetComponent<Image>().color = Color.green;
                

            }
            else
            {
                containerName.GetComponent<Image>().color = Color.red;
            }
        }
       else
        {
            containerName.GetComponent<Image>().color = Color.red;
        }
        
       

        
    }


}
