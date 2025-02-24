using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class ResearchFilePuzzle : MonoBehaviour
{
    //All containers for the entering the puzzle pieces
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

    //Hint text and content
    public Text hintText;
    public string hint;


    //Booleans to check if objects are in the correct position
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

    //If all are correct
    private bool allCorrect;

    //Windows for before and after the puzzle is completed
    public GameObject lockedWindow;
    public GameObject unlockedWindow;

    public GameController player;
    private int attempts;

    //Keep track of children (GameObjects) in the window
    private int parentChildrenUnlocked;
    private int grandParentChildrenUnlocked;
    private int parentChildrenLocked;
    private int grandParentChildrenLocked;


    // Start is called before the first frame update
    void Start()
    {
        //Initiate all to false
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

    }

    void Update()
    {
        //Keep track of which objects are being moved and total gameobjects in puzzle
        parentChildrenUnlocked = unlockedWindow.transform.parent.childCount;
        grandParentChildrenUnlocked = unlockedWindow.transform.parent.parent.childCount;

        parentChildrenLocked = lockedWindow.transform.parent.childCount;
        grandParentChildrenLocked = lockedWindow.transform.parent.parent.childCount;
    }

    //Checks if the player has completed the puzzle already and shows corresponding window
    public void checkIfPuzzleSolved()
    {
        if (player.currentPlayer.data.mainObjSubTwo_TwoComplete)
        {
            unlockedWindow.SetActive(true);
            unlockedWindow.transform.SetSiblingIndex(parentChildrenUnlocked - 1);
            unlockedWindow.transform.parent.SetSiblingIndex(grandParentChildrenUnlocked - 1);
        }
        else if (!player.currentPlayer.data.mainObjSubTwo_TwoComplete) 
        {
            lockedWindow.SetActive(true);
            lockedWindow.transform.SetSiblingIndex(parentChildrenLocked - 1);
            lockedWindow.transform.parent.SetSiblingIndex(grandParentChildrenLocked - 1);
        }
    }


    public void ValidateInputs()
    {
        //Checks if all containers are in the correct position.
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

        //Once all are correct the puzzle and player information updates and the unlocked window appears.
        if (allCorrect)
        {
            player.UpdateObjective("mainTwoSubTwo");
            lockedWindow.SetActive(false);
            unlockedWindow.SetActive(true);
            unlockedWindow.transform.SetSiblingIndex(parentChildrenUnlocked - 1);
            unlockedWindow.transform.parent.SetSiblingIndex(grandParentChildrenUnlocked - 1);

        }
        //if player attempts to many times then a hint is shown to direct them
        else if (attempts == 4)
        {
            hintText.text = hint;
        }
        attempts++;
    }

   
    //Check container method checks if the container has been placed in the correct spot.
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
