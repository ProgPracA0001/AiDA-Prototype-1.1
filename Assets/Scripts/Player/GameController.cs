using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject playerManagerObject;
    public PlayerManager currentPlayer;

    [SerializeField] public Sprite objectiveComplete;
    public Sprite objectiveDefault;

    public GameObject objectivesWindow;
    public GameObject welcomeWindow;

    public Text currentChapterTitle;

    public Text mainObjectiveTitle;

    public Text mainObjSubOneTitle;
    public Text mainObjSubTwoTitle;
    public Text mainObjSubThreeTitle;

    public Image mainObjSubOneIcon;
    public Image mainObjSubTwoIcon;
    public Image mainObjSubThreeIcon;

    public Text mainObjSubOneDesc;
    public Text mainObjSubTwoDesc;
    public Text mainObjSubThreeDesc;


    void Awake()
    {
        playerManagerObject = GameObject.Find("PlayerManager");
        currentPlayer = playerManagerObject.GetComponent<PlayerManager>();

    }
    void Start()
    {
        currentPlayer.LoadPlayer();

        currentChapterTitle.text = currentPlayer.data.currentChapterName;

        if (!currentPlayer.data.firstTimeLoginComplete)
        {
            objectivesWindow.SetActive(true);
            welcomeWindow.SetActive(true);
            currentPlayer.data.firstTimeLoginComplete = true;
            currentPlayer.data.mainObjSubOne_OneComplete = true;
            currentPlayer.Save();

        }

        LoadMainObjectiveOne();
       
    }

    public void UpdatePlayer()
    {
        currentPlayer.Save();
        currentPlayer.LoadPlayer();
    }


    public void LoadMainObjectiveOne()
    {
        if (currentPlayer.data.currentChapter == 1)
        {
            mainObjectiveTitle.text = "New User Detected: Create a New Profile and First Time Login:";

            mainObjSubOneTitle.text = "Signed Up: Create User Profile and Login";
            mainObjSubOneDesc.text = "Set up a profile with a username, password and first name";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubOne_OneComplete, mainObjSubOneIcon);

            mainObjSubTwoTitle.text = "Dr Who?: Find the Inheritance Message";
            mainObjSubTwoDesc.text = "Go through the Welcome File and read the Inheritance Report";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubOne_TwoComplete, mainObjSubTwoIcon);

            mainObjSubThreeTitle.text = "The Last Message: Find the Dr's Last Message";
            mainObjSubThreeDesc.text = "It looks like the Dr left something behind for you...";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubOne_ThreeComplete, mainObjSubThreeIcon);
        }
        else if (currentPlayer.data.currentChapter == 2)
        {
            
        }
    }

    public void LoadMainObjectiveTwo()
    {
        if(currentPlayer.data.currentChapter == 1)
        {    mainObjectiveTitle.text = "The File Explorer: Explore the Desktop's Main Folders";

            mainObjSubOneTitle.text = "Byte-Sized Expedition: Find the Dr's Diaries";
            mainObjSubOneDesc.text = "Scattered around the desktop are the Dr's personal files, explore them, some may contain vital information";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubTwo_OneComplete, mainObjSubOneIcon);

            mainObjSubTwoTitle.text = "First Questions: Access to the Research File is Protected";
            mainObjSubTwoDesc.text = "Enter the correct word to unlock the Research folder";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubTwo_TwoComplete, mainObjSubTwoIcon);

            mainObjSubThreeTitle.text = "Note To Self: Note Down Your Clues and Findings";
            mainObjSubThreeDesc.text = "Not everything can be kept in your mind! Start noting your findings and save them in the notepad";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubTwo_ThreeComplete, mainObjSubThreeIcon);
        }
        else if (currentPlayer.data.currentChapter == 2)
        {

        }
    }

    public void LoadMainObjectiveThree()
    {
        if(currentPlayer.data.currentChapter == 1)
        {    mainObjectiveTitle.text = "Access Denied: Unlock the MyFile Folder:";

            mainObjSubOneTitle.text = "Time To Hit The Books: The First Clue";
            mainObjSubOneDesc.text = "Somewhere on the desktop is the first clue, time to track it down!";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubThree_OneComplete, mainObjSubOneIcon);

            mainObjSubTwoTitle.text = "Piecing It Together: Second Clue In The Queue:";
            mainObjSubTwoDesc.text = "The second piece of information we need is around here somewhere...";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubThree_TwoComplete, mainObjSubTwoIcon);

            mainObjSubThreeTitle.text = "Quiz Time: Enter The Correct Answers and Unlock the Folder:";
            mainObjSubThreeDesc.text = "You have all the information you need, it's time to unlock the file!";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubThree_ThreeComplete, mainObjSubThreeIcon);
        }
        else if (currentPlayer.data.currentChapter == 2)
        {

        }
    }

    public void LoadSideObjectiveOne()
    {
        if (currentPlayer.data.currentChapter == 1)
        {
            mainObjectiveTitle.text = "The Old Post: Enter the Correct Password and Access the Mystery Newspaper ";

            mainObjSubOneTitle.text = "Find Clue 1";
            mainObjSubOneDesc.text = "The Dr liked to take a lot of notes, maybe something can help";
            LoadObjectiveStatus(currentPlayer.data.sideObjSubOne_OneComplete, mainObjSubOneIcon);

            mainObjSubTwoTitle.text = "Find Clue 2";
            mainObjSubTwoDesc.text = "";
            LoadObjectiveStatus(currentPlayer.data.sideObjSubOne_TwoComplete, mainObjSubTwoIcon);

            mainObjSubThreeTitle.text = "Decryption";
            mainObjSubThreeDesc.text = "Using the clues solve the password to gain access to the Newspaper";
            LoadObjectiveStatus(currentPlayer.data.sideObjSubOne_ThreeComplete, mainObjSubThreeIcon);

        }
        else if (currentPlayer.data.currentChapter == 2)
        {

        }
    }

    public void LoadSideObjectiveTwo()
    {
        if(currentPlayer.data.currentChapter == 1)
        {
            mainObjectiveTitle.text = "Voice From the Void: Unlock Mystery Audio File";

            mainObjSubOneTitle.text = "Find Clue 1";
            mainObjSubOneDesc.text = "";
            LoadObjectiveStatus(currentPlayer.data.sideObjSubTwo_OneComplete, mainObjSubOneIcon);

            mainObjSubTwoTitle.text = "Find Clue 2";
            mainObjSubTwoDesc.text = "";      
            LoadObjectiveStatus(currentPlayer.data.sideObjSubTwo_OneComplete, mainObjSubTwoIcon);

            mainObjSubThreeTitle.text = "A Good Combination";
            mainObjSubThreeDesc.text = "";
            LoadObjectiveStatus(currentPlayer.data.sideObjSubTwo_ThreeComplete, mainObjSubThreeIcon);

        }
        else if (currentPlayer.data.currentChapter == 2)
        {

        }
    }

    public void LoadObjectiveStatus(bool objective, Image objectiveIcon)
    {
        if (objective)
        {
            objectiveIcon.sprite = objectiveComplete;
        }
        else
        {
            objectiveIcon.sprite = objectiveDefault;
        }
    }


    public void ResetObjectives()
    {
        currentPlayer.data.mainObjectiveOneComplete = false;
        currentPlayer.data.mainObjectiveTwoComplete = false;
        currentPlayer.data.mainObjectiveThreeComplete = false;

        currentPlayer.data.mainObjSubOne_OneComplete = false;
        currentPlayer.data.mainObjSubOne_TwoComplete = false;
        currentPlayer.data.mainObjSubOne_ThreeComplete = false;

        currentPlayer.data.mainObjSubTwo_OneComplete = false;
        currentPlayer.data.mainObjSubTwo_TwoComplete = false;
        currentPlayer.data.mainObjSubTwo_ThreeComplete = false;

        currentPlayer.data.mainObjSubThree_OneComplete = false;
        currentPlayer.data.mainObjSubThree_TwoComplete = false;
        currentPlayer.data.mainObjSubThree_ThreeComplete = false;

        currentPlayer.data.sideObjectiveOneComplete = false;
        currentPlayer.data.sideObjectiveTwoComplete = false;

        currentPlayer.data.sideObjSubOne_OneComplete = false;
        currentPlayer.data.sideObjSubOne_TwoComplete = false;
        currentPlayer.data.sideObjSubOne_ThreeComplete = false;

        currentPlayer.data.sideObjSubTwo_OneComplete = false;
        currentPlayer.data.sideObjSubTwo_TwoComplete = false;
        currentPlayer.data.sideObjSubTwo_ThreeComplete = false;

        currentPlayer.Save();
    }


}
