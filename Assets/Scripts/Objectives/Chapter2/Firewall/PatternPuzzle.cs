using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PatternPuzzle : MonoBehaviour
{
    //GameController, which gets the current player
    public GameController player;

    public GameObject restrictedSection;

    //Sprite to change to a TICK when each level complete
    public Sprite completeLevel;

    //Level Label to show players what level they are on.
    public Text LevelLabel;

    //Level Test Panels - where the main puzzle is displayed
    public GameObject Level1Test;
    public GameObject Level2Test;
    public GameObject Level3Test;
    public GameObject Level4Test;

    //Level Details panels - run button, scores
    public GameObject Level1Details;
    public GameObject Level2Details;
    public GameObject Level3Details;
    public GameObject Level4Details;

    //Level Answer panels - where the player inputs answers to the corresponding tests
    public GameObject Level1Answers;
    public GameObject Level2Answers;
    public GameObject Level3Answers;
    public GameObject Level4Answers;

    //Booleans to indicate a levels completion
    public bool level1Complete;
    public bool level2Complete;
    public bool level3Complete;
    public bool level4Complete;

    //Image objects where the sprite indicating if a level is complete is diaplyed
    public Image levelOneCheck;
    public Image levelTwoCheck;
    public Image levelThreeCheck;
    public Image levelFourCheck;


    //LEVEL 1 COMPONENTS
    public Image L1Light;

    public Color[] LevelOneColorSequence = new Color[6];
    public Color levelOneAnswer = Color.red;

    public Button L1Button;


    // LEVEL 2 COMPONENTS
    public GameObject LevelTwoObjectContainer;
    public Text L2ScoreText;

    public int LevelTwoChildCount;

    public Button[] LevelTwoButtons = new Button[64];

    public int L2Score;

    public bool[] ButtonCorrect = new bool[64];
    public Color[] LevelTwoColorSequence = new Color[64];


    //LEVEL 3 COMPONENTS
    public Text LevelThreeQuestionText;
    public int QuestionNo;

    public Text L3ScoreText;
    public int L3Score;

    public bool[] answersCorrect = new bool[6];

    public Text buttonOneText;
    public Text buttonTwoText;
    public Text buttonThreeText;
    public Text buttonFourText;

    public string L3AnswerOne;
    public string L3AnswerTwo;
    public string L3AnswerThree;
    public string L3AnswerFour;
    public string L3AnswerFive;
    public string L3AnswerSix;


    //LEVEL 4 COMPONENTS
    public GameObject containerOne;
    public GameObject containerTwo;
    public GameObject containerThree;
    public GameObject containerFour;
    public GameObject containerFive;

    public GameObject ItemOne;
    public GameObject ItemTwo;
    public GameObject ItemThree;
    public GameObject ItemFour;
    public GameObject ItemFive;

    public bool OneCorrect;
    public bool TwoCorrect;
    public bool ThreeCorrect;
    public bool FourCorrect;
    public bool FiveCorrect;

    public bool allObjectsCorrect;

    void Start()
    {
        LevelLabel.text = "Level: 1";
        QuestionNo = 1;
        level1Complete = false;
        level2Complete = false;
        level3Complete = false;

        allObjectsCorrect = false;

        L1Button.onClick.AddListener(delegate { LevelOneTaskOnClick(L1Button); });

        L2Score = 0;

        LevelTwoChildCount = LevelTwoObjectContainer.transform.childCount;



        for (int i = 0; i < LevelTwoChildCount; i++)
        {
            LevelTwoButtons[i] = LevelTwoObjectContainer.transform.GetChild(i).GetComponentInChildren<Button>();

            Button button = LevelTwoButtons[i];

            if (button != null)
            {
                button.onClick.AddListener(delegate { LevelTwoTaskOnClick(button); });
            }
            else
            {
                Debug.Log("Button Is EMPTY");
            }

        }


    }

    void Update()
    {
        if (level1Complete && level2Complete)
        {
            LoadCurrentQuestionLevel3();
        }
    }

    void LevelOneTaskOnClick(Button button)
    {

        if(button.GetComponent<Image>().color == Color.white || button.GetComponent<Image>().color == Color.red)
        {
            button.GetComponent<Image>().color = Color.black;
           
        }
        else 
        {
            button.GetComponent<Image>().color = Color.red;
           
        }
        
    }

    void LevelTwoTaskOnClick(Button button)
    {

        if (button.GetComponent<Image>().color == Color.white)
        {
            button.GetComponent<Image>().color = Color.black;
            
        }
        else
        {
            button.GetComponent<Image>().color = Color.white;
            
        }

    }

    public void NextPage()
    {
        if (QuestionNo < 6)
        {
            QuestionNo++;
        }
    }

    public void BackPage()
    {
        if(QuestionNo > 1)
        {
            QuestionNo--;
        }
    }


    public void LoadCurrentQuestionLevel3()
    {
        if (QuestionNo == 1)
        {
            LevelThreeQuestionText.text = "Q1) What is an AI model??";

            buttonOneText.text = "A) A computer program that follows a fixed set of rules";
            buttonTwoText.text = "B) A system that adjustd and improves based on data";
            buttonThreeText.text = "C) A digital copy of a human brain";
            buttonFourText.text = "D) A type of advanced search engine";
        }
        else if (QuestionNo == 2)
        {
            LevelThreeQuestionText.text = "Q2) What is the main thing an AI need to learn?";

            buttonOneText.text = "A) A powerful computer";
            buttonTwoText.text = "B) Data and examples";
            buttonThreeText.text = "C) A human teacher";
            buttonFourText.text = "D) A special AI learning chip";
        }
        else if (QuestionNo == 3)
        {
            LevelThreeQuestionText.text = "Q3) What happens if AI is trained on bad data?";

            buttonOneText.text = "A) It stops working completely";
            buttonTwoText.text = "B) It ignores the mistakes and improves anyway";
            buttonThreeText.text = "C) It deletes the bad data and retrains itself";
            buttonFourText.text = "D) It starts making incorrect decisions";
        }
        else if (QuestionNo == 4)
        {
            LevelThreeQuestionText.text = "Q4) Why do AI models go through a training process?";

            buttonOneText.text = "A) To improve accuracy overtime";
            buttonTwoText.text = "B) To memorise all possible answers";
            buttonThreeText.text = "C) To ensure AI never makes mistakes";
            buttonFourText.text = "D) To adjust its hardware for better performance";
        }
        else if(QuestionNo == 5)
        {
            LevelThreeQuestionText.text = "Q5) What is the difference between AI and regular computer programs?";

            buttonOneText.text = "A) AI follows strict rules, while regular programs learn from data";
            buttonTwoText.text = "B) AI runs faster than regular programs";
            buttonThreeText.text = "C) AI learns from data and adapts, while regular programs follow fixed rules";
            buttonFourText.text = "D) Regular programs use more complex decision-making than AI";
        }
        else if (QuestionNo== 6)
        {
            LevelThreeQuestionText.text = "Q6) Why does AI need large amounts of data?";

            buttonOneText.text = "A) To memorise every possible outcome";
            buttonTwoText.text = "B) To find patterns and make better predictions";
            buttonThreeText.text = "C) To replace human decision-making entirely";
            buttonFourText.text = "D) To ensure it never makes mistakes";
        }

    }

    public void AddAnswer(string answer)
    {
        if(QuestionNo == 1)
        {
            L3AnswerOne = answer;
        }
        else if(QuestionNo == 2)
        {
            L3AnswerTwo = answer;
        }
        else if( QuestionNo == 3)
        {
            L3AnswerThree = answer;
        }
        else if (QuestionNo == 4)
        {
            L3AnswerFour = answer;
        }
        else if (QuestionNo == 5)
        {
            L3AnswerFive = answer;
        }
        else if (QuestionNo == 6)
        {
            L3AnswerSix = answer;
        }
    }

    public void RunLevelOne()
    {
        StartCoroutine(levelOneSequence());
    }


    private IEnumerator levelOneSequence()
    {

        foreach(var color in LevelOneColorSequence)
        {
            L1Light.color = color;
            yield return new WaitForSeconds(1.0f);
        }
        yield return new WaitForSeconds(1);
    }

    


    public void CheckAnswer()
    {
        if (!level1Complete)
        {
            if (L1Button.GetComponent<Image>().color == Color.red)
            {
                levelOneCheck.sprite = completeLevel;
                level1Complete = true;
                Level1Test.SetActive(false);
                Level1Details.SetActive(false);
                Level1Answers.SetActive(false);
                LevelLabel.text = "Level: 2";
                Level2Test.SetActive(true);
                Level2Details.SetActive(true);
                Level2Answers.SetActive(true);
            }
        }

        else if (!level2Complete)
        {
            
            CheckLevelTwo();

            if (L2Score == 64)
            {
                levelTwoCheck.sprite = completeLevel;
                level2Complete = true;
                Level2Test.SetActive(false);
                Level2Details.SetActive(false);
                Level2Answers.SetActive(false);
                LevelLabel.text = "Level: 3";
                Level3Test.SetActive(true);
                Level3Details.SetActive(true);
                Level3Answers.SetActive(true);

                
            }
        }
        else if (!level3Complete)
        {

            CheckLevelThree();
            L3ScoreText.text = L3Score.ToString() + "/6";

            if (L3Score == 6)
            {
                levelThreeCheck.sprite = completeLevel;
                level3Complete = true;
                Level3Test.SetActive(false);
                Level3Details.SetActive(false);
                Level3Answers.SetActive(false);
                Level4Test.SetActive(true);
                Level4Details.SetActive(true);
                Level4Answers.SetActive(true);

            }
        }
        else if (!level4Complete)
        {
            CheckLevelFour();

            if (allObjectsCorrect)
            {
                player.UpdateObjective("mainOneSubThree");
                restrictedSection.GetComponent<WindowControllerScript>().Open();
                this.gameObject.SetActive(false);
            }

        }
    }

    public void CheckLevelTwo()
    {

        for (int i = 0; i < LevelTwoChildCount; i++)
        {
            if (LevelTwoButtons[i].GetComponent<Image>().color == LevelTwoColorSequence[i] && !ButtonCorrect[i])
            {
                ButtonCorrect[i] = true;
                L2Score++;
                L2ScoreText.text = L2Score.ToString() + "/64";

            }
            else if (LevelTwoButtons[i].GetComponent<Image>().color != LevelTwoColorSequence[i] && ButtonCorrect[i])
            {
                ButtonCorrect[i] = false;
                L2Score--;
                L2ScoreText.text = L2Score.ToString() + "/64";

            }
            

        }
    }

    public void CheckLevelThree()
    {

        if (L3AnswerOne == "B" && !answersCorrect[0])
        {
            answersCorrect[0] = true;
            L3Score++;
        }
        else if (L3AnswerOne != "B" && answersCorrect[0])
        {
            answersCorrect[0] = false;
            L3Score--;
        }

        if (L3AnswerTwo == "B" && !answersCorrect[1])
        {
            answersCorrect[1] = true;
            L3Score++;
        }
        else if (L3AnswerTwo != "B" && answersCorrect[1])
        {
            answersCorrect[1] = false;
            L3Score--;
        }


        if (L3AnswerThree == "D" && !answersCorrect[2])
        {
            answersCorrect[2] = true;
            L3Score++;
        }
        else if (L3AnswerThree != "D" && answersCorrect[2])
        {
            answersCorrect[2] = false;
            L3Score--;

        }
        if (L3AnswerFour == "A" && !answersCorrect[3])
        {
            answersCorrect[3] = true;
            L3Score++;
        }
        else if (L3AnswerFour != "A" && answersCorrect[3])
        {
            answersCorrect[3] = false;
            L3Score--;
        }

        if (L3AnswerFive == "C" && !answersCorrect[4])
        {
            answersCorrect[4] = true;
            L3Score++;
        }
        else if (L3AnswerFive != "C" && answersCorrect[4])
        {
            answersCorrect[4] = false;
            L3Score--;
        }

        if (L3AnswerSix == "B" && !answersCorrect[5])
        {
            answersCorrect[5] = true;
            L3Score++;
        }
        else if (L3AnswerSix != "B" && answersCorrect[5])
        {
            answersCorrect[5] = false;
            L3Score--;

        }
    }


    public void CheckLevelFour()
    {
        CheckContainer(containerOne, "Input", ref OneCorrect);
        CheckContainer(containerTwo, "Arrow", ref TwoCorrect);
        CheckContainer(containerThree, "Model", ref ThreeCorrect);
        CheckContainer(containerFour, "Arrow", ref FourCorrect);
        CheckContainer(containerFive, "Prediction", ref FiveCorrect);

        if (OneCorrect && TwoCorrect && ThreeCorrect && FourCorrect && FiveCorrect)
        {
            allObjectsCorrect = true;
        }

    }

    //Check container method checks if the container has been placed in the correct spot.
    public void CheckContainer(GameObject containerName, string correctTarget, ref bool targetCorrect)
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

