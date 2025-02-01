using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject playerManagerObject;
    public PlayerManager currentPlayer;

    [SerializeField] public Sprite objectiveComplete;
    public Sprite objectiveDefault;

    public GameObject objectivesWindow;
    public GameObject welcomeWindow;
    public GameObject objectiveCompleteWindow;
    public GameObject ChapterUpdateWindow;

    public Text objectiveCompleteText;
    public Text newChapterText;
    public float typingSpeed = 0.2f;

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

    private int parentChildren;

    //Before the Start the playermanager and current player will be assigned
    void Awake()
    {
        playerManagerObject = GameObject.Find("PlayerManager");
        currentPlayer = playerManagerObject.GetComponent<PlayerManager>();

    }

    //On Start the current player selected will be loaded with the chapter titles.
    void Start()
    {
        currentPlayer.LoadPlayer();

        currentChapterTitle.text = currentPlayer.data.currentChapterName;

        //Detecting if the player is a new user will check the first time log in variable of the player and open the welcome window!
        if (!currentPlayer.data.firstTimeLoginComplete)
        {
            objectivesWindow.SetActive(true);
            welcomeWindow.SetActive(true);
            currentPlayer.data.firstTimeLoginComplete = true;
            currentPlayer.data.mainObjSubOne_OneComplete = true;
            currentPlayer.Save();

        }

        //If returning player then main objective one is loaded.
        LoadMainObjectiveOne();
       
    }

    void Update()
    {
        parentChildren = objectiveCompleteWindow.transform.parent.childCount;
        
    }

    //Saves the player and loads the updated variables
    public void UpdatePlayer()
    {
        currentPlayer.Save();
        currentPlayer.LoadPlayer();
    }

    //When player is exiting out of the game to the main menu the player will be saved and the start menu loaded.
    public void LogOff()
    {
        currentPlayer.Save();
        Destroy(this.playerManagerObject);
        SceneManager.LoadScene("StartMenu");
    }

   
    //Loads Main objective One - checks the players current chapter and loads the corresponding objectives into the objective windows text.
    public void LoadMainObjectiveOne()
    {
        if (currentPlayer.data.currentChapter == 1)
        {
            mainObjectiveTitle.text = "New User Detected: Create a New Profile and First Time Login:";

            mainObjSubOneTitle.text = "Signed Up: Create User Profile and Login";
            mainObjSubOneDesc.text = "Set up a profile with a username, password and first name, then log in!";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubOne_OneComplete, mainObjSubOneIcon);

            mainObjSubTwoTitle.text = "Dr Who?: Find the Inheritance Message";
            mainObjSubTwoDesc.text = "Go through the Welcome File on the Desktop and read the Inheritance Report";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubOne_TwoComplete, mainObjSubTwoIcon);

            mainObjSubThreeTitle.text = "The Last Message: Find the Dr's Last Message";
            mainObjSubThreeDesc.text = "It looks like the Dr left something behind for you...";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubOne_ThreeComplete, mainObjSubThreeIcon);
        }
        else if (currentPlayer.data.currentChapter == 2)
        {
            mainObjectiveTitle.text = "The Restricted Section: Access Restricted Folders";

            mainObjSubOneTitle.text = "";
            mainObjSubOneDesc.text = "A firewall security software is blocking your access to the Restricted Section! Figure our how to disable it! There's a manual folder in MyFiles, maybe something there can help!";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubOne_OneComplete, mainObjSubOneIcon);

            mainObjSubTwoTitle.text = "";
            mainObjSubTwoDesc.text = "";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubOne_TwoComplete, mainObjSubTwoIcon);

            mainObjSubThreeTitle.text = "Call the Fireman: Bypass the Security Software:";
            mainObjSubThreeDesc.text = "Disable the Firewall and gain access to the restricted section!";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubOne_ThreeComplete, mainObjSubThreeIcon);
        }
        else if (currentPlayer.data.currentChapter == 3)
        {
            mainObjectiveTitle.text = "";

            mainObjSubOneTitle.text = "";
            mainObjSubOneDesc.text = "";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubOne_OneComplete, mainObjSubOneIcon);

            mainObjSubTwoTitle.text = "";
            mainObjSubTwoDesc.text = "";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubOne_TwoComplete, mainObjSubTwoIcon);

            mainObjSubThreeTitle.text = "";
            mainObjSubThreeDesc.text = "";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubOne_ThreeComplete, mainObjSubThreeIcon);
        }
    }

    public void LoadMainObjectiveTwo()
    {
        if(currentPlayer.data.currentChapter == 1)
        {    
            mainObjectiveTitle.text = "The File Explorer: Explore the Desktop's Main Folders";

            mainObjSubOneTitle.text = "Byte-Sized Expedition: Find the Dr's Diaries";
            mainObjSubOneDesc.text = "Scattered around the desktop are the Dr's personal files, explore them, some may contain vital information";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubTwo_OneComplete, mainObjSubOneIcon);

            mainObjSubTwoTitle.text = "First Questions: Access to the Research File is Protected";
            mainObjSubTwoDesc.text = "Enter the correct word to unlock the Research folder, certain phrases may be found in other documents.";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubTwo_TwoComplete, mainObjSubTwoIcon);

            mainObjSubThreeTitle.text = "Note To Self: Note Down Your Clues and Findings";
            mainObjSubThreeDesc.text = "Not everything can be kept in your mind! Start noting your findings and save them in the notepad";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubTwo_ThreeComplete, mainObjSubThreeIcon);
        }
        else if (currentPlayer.data.currentChapter == 2)
        {
            mainObjectiveTitle.text = "Unfinished Business: Investigate the Dr's Last Experiment";

            mainObjSubOneTitle.text = "";
            mainObjSubOneDesc.text = "";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubTwo_OneComplete, mainObjSubOneIcon);

            mainObjSubTwoTitle.text = "";
            mainObjSubTwoDesc.text = "";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubTwo_TwoComplete, mainObjSubTwoIcon);

            mainObjSubThreeTitle.text = "Test Subject Zero: Discover the True Nature Of The Experiment:";
            mainObjSubThreeDesc.text = "";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubTwo_ThreeComplete, mainObjSubThreeIcon);
        }
        else if (currentPlayer.data.currentChapter == 3)
        {
            mainObjectiveTitle.text = "";

            mainObjSubOneTitle.text = "";
            mainObjSubOneDesc.text = "";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubTwo_OneComplete, mainObjSubOneIcon);

            mainObjSubTwoTitle.text = "";
            mainObjSubTwoDesc.text = "";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubTwo_TwoComplete, mainObjSubTwoIcon);

            mainObjSubThreeTitle.text = "";
            mainObjSubThreeDesc.text = "";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubTwo_ThreeComplete, mainObjSubThreeIcon);
        }
    }

    public void LoadMainObjectiveThree()
    {
        if(currentPlayer.data.currentChapter == 1)
        {    
            mainObjectiveTitle.text = "Access Denied: Unlock the MyFile Folder:";

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
            mainObjectiveTitle.text = "The Restoration Project: Restore the files needed for the 'O' File";

            mainObjSubOneTitle.text = "Broken Up: Restore The Damaged Files";
            mainObjSubOneDesc.text = "";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubThree_OneComplete, mainObjSubOneIcon);

            mainObjSubTwoTitle.text = "";
            mainObjSubTwoDesc.text = "";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubThree_TwoComplete, mainObjSubTwoIcon);

            mainObjSubThreeTitle.text = "";
            mainObjSubThreeDesc.text = "";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubThree_ThreeComplete, mainObjSubThreeIcon);
        }
    }

    public void LoadSideObjectiveOne()
    {
        if (currentPlayer.data.currentChapter == 1)
        {
            mainObjectiveTitle.text = "The Old Post: Enter the Correct Password and Access the Mystery Newspaper ";

            mainObjSubOneTitle.text = "Find The First Clue";
            mainObjSubOneDesc.text = "The Dr liked to take a lot of notes, maybe something can help!";
            LoadObjectiveStatus(currentPlayer.data.sideObjSubOne_OneComplete, mainObjSubOneIcon);

            mainObjSubTwoTitle.text = "Clue Number Two";
            mainObjSubTwoDesc.text = "Clue Number Two is similar to the first, I think the Dr was hungry when he came up with this!";
            LoadObjectiveStatus(currentPlayer.data.sideObjSubOne_TwoComplete, mainObjSubTwoIcon);

            mainObjSubThreeTitle.text = "Decryption";
            mainObjSubThreeDesc.text = "Using both clues solve the password to gain access to the Newspaper";
            LoadObjectiveStatus(currentPlayer.data.sideObjSubOne_ThreeComplete, mainObjSubThreeIcon);

        }
        else if (currentPlayer.data.currentChapter == 2)
        {
            mainObjectiveTitle.text = "Dial Up Dilemma: Using t";

            mainObjSubOneTitle.text = "";
            mainObjSubOneDesc.text = "";
            LoadObjectiveStatus(currentPlayer.data.sideObjSubOne_OneComplete, mainObjSubOneIcon);

            mainObjSubTwoTitle.text = "";
            mainObjSubTwoDesc.text = "";
            LoadObjectiveStatus(currentPlayer.data.sideObjSubOne_TwoComplete, mainObjSubTwoIcon);

            mainObjSubThreeTitle.text = "";
            mainObjSubThreeDesc.text = "";
            LoadObjectiveStatus(currentPlayer.data.sideObjSubOne_ThreeComplete, mainObjSubThreeIcon);
        }
    }

    public void LoadSideObjectiveTwo()
    {
        if(currentPlayer.data.currentChapter == 1)
        {
            mainObjectiveTitle.text = "Voice From the Void: Unlock Mystery Audio File";

            mainObjSubOneTitle.text = "Find the First Combination Clue";
            mainObjSubOneDesc.text = "This clue contains half the information you need for the combination!";
            LoadObjectiveStatus(currentPlayer.data.sideObjSubTwo_OneComplete, mainObjSubOneIcon);

            mainObjSubTwoTitle.text = "Find The Second Clue";
            mainObjSubTwoDesc.text = "This clue might require another file to be unlocked!";      
            LoadObjectiveStatus(currentPlayer.data.sideObjSubTwo_TwoComplete, mainObjSubTwoIcon);

            mainObjSubThreeTitle.text = "A Good Combination";
            mainObjSubThreeDesc.text = "The clues together will allow for you work out the correct combination, you might want to keep notes!";
            LoadObjectiveStatus(currentPlayer.data.sideObjSubTwo_ThreeComplete, mainObjSubThreeIcon);

        }
        else if (currentPlayer.data.currentChapter == 2)
        {
            mainObjectiveTitle.text = "";

            mainObjSubOneTitle.text = "";
            mainObjSubOneDesc.text = "";
            LoadObjectiveStatus(currentPlayer.data.sideObjSubTwo_OneComplete, mainObjSubOneIcon);

            mainObjSubTwoTitle.text = "";
            mainObjSubTwoDesc.text = "";
            LoadObjectiveStatus(currentPlayer.data.sideObjSubTwo_TwoComplete, mainObjSubTwoIcon);

            mainObjSubThreeTitle.text = "";
            mainObjSubThreeDesc.text = "";
            LoadObjectiveStatus(currentPlayer.data.sideObjSubTwo_ThreeComplete, mainObjSubThreeIcon);
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

    public void checkProgression(string objective)
    {
         if (objective == "mainOne")
        {    if (currentPlayer.data.mainObjSubOne_OneComplete && currentPlayer.data.mainObjSubOne_TwoComplete && currentPlayer.data.mainObjSubOne_ThreeComplete)
            {
                currentPlayer.data.mainObjectiveOneComplete = true;
                UpdatePlayer();
                CheckChapterProgression();
            }
        }
        else if (objective == "mainTwo")
        {
            if (currentPlayer.data.mainObjSubTwo_OneComplete && currentPlayer.data.mainObjSubTwo_TwoComplete && currentPlayer.data.mainObjSubTwo_ThreeComplete)
            {
                currentPlayer.data.mainObjectiveTwoComplete = true;
                UpdatePlayer();
                CheckChapterProgression();
            }
        }
        else if (objective == "mainThree")
        {
            if (currentPlayer.data.mainObjSubThree_OneComplete && currentPlayer.data.mainObjSubThree_TwoComplete && currentPlayer.data.mainObjSubThree_ThreeComplete)
            {
                currentPlayer.data.mainObjectiveThreeComplete = true;
                UpdatePlayer();
                CheckChapterProgression();
            }
        }
        else if (objective == "sideOne")
        {
            if (currentPlayer.data.sideObjSubOne_OneComplete && currentPlayer.data.sideObjSubOne_TwoComplete && currentPlayer.data.sideObjSubOne_ThreeComplete)
            {
                currentPlayer.data.sideObjectiveOneComplete = true;
                UpdatePlayer();
                CheckChapterProgression();
            }
        }
        else if (objective == "sideTwo")
        {
            if (currentPlayer.data.sideObjSubTwo_OneComplete && currentPlayer.data.sideObjSubTwo_TwoComplete && currentPlayer.data.sideObjSubTwo_ThreeComplete)
            {
                currentPlayer.data.sideObjectiveTwoComplete = true;
                UpdatePlayer();
                CheckChapterProgression();
            }
        }

    }

    public void CheckChapterProgression()
    {
        if (currentPlayer.data.mainObjectiveOneComplete && currentPlayer.data.mainObjectiveTwoComplete && currentPlayer.data.mainObjectiveThreeComplete && currentPlayer.data.sideObjectiveOneComplete && currentPlayer.data.sideObjectiveTwoComplete)
        {
            currentPlayer.data.currentChapter++;

            if (currentPlayer.data.currentChapter == 2)
            {
                currentPlayer.data.currentChapterName = "Chapter Two: Secrets Beneath The Surface";
                currentChapterTitle.text = "Thank you for playing! Chapter Two: Secrets Beneath The Surface currently in development!";
                UpdatePlayer();
                currentPlayer.LoadPlayer();
                StartCoroutine(NewChapterStarted());
                ResetObjectives();
            }
            else if (currentPlayer.data.currentChapter == 3)
            {
                currentPlayer.data.currentChapterName = "Chapter Three: Booting Up The Past...";
                ResetObjectives();
            }
            else if (currentPlayer.data.currentChapter == 4)
            {
                currentPlayer.data.currentChapterName = "Chapter Four: Echoes In The Code";
                ResetObjectives();
            }
            else if (currentPlayer.data.currentChapter == 5)
            {
                currentPlayer.data.currentChapterName = "Chapter Five: Shadows Of Influence";
                ResetObjectives();
            }
            else if (currentPlayer.data.currentChapter == 6)
            {
                currentPlayer.data.currentChapterName = "Chapter Six: Ghosts In The Machine";
                ResetObjectives();
            }

        }
    }

    public void UpdateObjective(string objective)
    {
        if (objective == "mainOneSubOne")
        {
            if (!currentPlayer.data.mainObjSubOne_OneComplete)
            {
                currentPlayer.data.mainObjSubOne_OneComplete = true;
                checkProgression("mainOne");
                UpdatePlayer();
                LoadMainObjectiveOne();
                ObjectivePopUp(mainObjSubOneTitle.text);
            }
        }
        else if (objective == "mainOneSubTwo")
        {
            if (!currentPlayer.data.mainObjSubOne_TwoComplete)
            {
                currentPlayer.data.mainObjSubOne_TwoComplete = true;
                checkProgression("mainOne");
                UpdatePlayer();
                LoadMainObjectiveOne();
                ObjectivePopUp(mainObjSubTwoTitle.text);
            }
        }
        else if (objective == "mainOneSubThree")
        {
            if (!currentPlayer.data.mainObjSubOne_ThreeComplete)
            {
                currentPlayer.data.mainObjSubOne_ThreeComplete = true;
                checkProgression("mainOne");
                UpdatePlayer();
                LoadMainObjectiveOne();
                ObjectivePopUp(mainObjSubThreeTitle.text);
            }
        }
        else if (objective == "mainTwoSubOne")
        {
            if (!currentPlayer.data.mainObjSubTwo_OneComplete)
            {
                currentPlayer.data.mainObjSubTwo_OneComplete = true;
                checkProgression("mainTwo");
                UpdatePlayer();
                LoadMainObjectiveTwo();
                ObjectivePopUp(mainObjSubOneTitle.text);
            }
        }
        else if (objective == "mainTwoSubTwo")
        {
            if (!currentPlayer.data.mainObjSubTwo_TwoComplete)
            {
                currentPlayer.data.mainObjSubTwo_TwoComplete = true;
                checkProgression("mainTwo");
                UpdatePlayer();
                LoadMainObjectiveTwo();
                ObjectivePopUp(mainObjSubTwoTitle.text);
            }
        }
        else if (objective == "mainTwoSubThree")
        {
            if (!currentPlayer.data.mainObjSubTwo_ThreeComplete)
            {
                currentPlayer.data.mainObjSubTwo_ThreeComplete = true;
                checkProgression("mainTwo");
                UpdatePlayer();
                LoadMainObjectiveTwo();
                ObjectivePopUp(mainObjSubThreeTitle.text);
            }
        }
        else if (objective == "mainThreeSubOne")
        {
            if (!currentPlayer.data.mainObjSubThree_OneComplete)
            {
                currentPlayer.data.mainObjSubThree_OneComplete = true;
                checkProgression("mainThree");
                UpdatePlayer();
                LoadMainObjectiveThree();
                ObjectivePopUp(mainObjSubOneTitle.text);
            }
        }
        else if (objective == "mainThreeSubTwo")
        {
            if (!currentPlayer.data.mainObjSubThree_TwoComplete)
            {
                currentPlayer.data.mainObjSubThree_TwoComplete = true;
                checkProgression("mainThree");
                UpdatePlayer();
                LoadMainObjectiveThree();
                ObjectivePopUp(mainObjSubTwoTitle.text);
            }
        }
        else if (objective == "mainThreeSubThree")
        {
            if (!currentPlayer.data.mainObjSubThree_ThreeComplete)
            {
                currentPlayer.data.mainObjSubThree_ThreeComplete = true;
                checkProgression("mainThree");
                UpdatePlayer();
                LoadMainObjectiveThree();
                ObjectivePopUp(mainObjSubThreeTitle.text);
            }
        }
        else if (objective == "sideOneSubOne")
        {
            if (!currentPlayer.data.sideObjSubOne_OneComplete)
            {
                currentPlayer.data.sideObjSubOne_OneComplete = true;
                checkProgression("sideOne");
                UpdatePlayer();
                LoadSideObjectiveOne();
                ObjectivePopUp(mainObjSubOneTitle.text);
            }
        }
        else if (objective == "sideOneSubTwo")
        {
            if (!currentPlayer.data.sideObjSubOne_TwoComplete)
            {
                currentPlayer.data.sideObjSubOne_TwoComplete = true;
                checkProgression("sideOne");
                UpdatePlayer();
                LoadSideObjectiveOne();
                ObjectivePopUp(mainObjSubTwoTitle.text);
            }
        }
        else if (objective == "sideOneSubThree")
        {
            if (!currentPlayer.data.sideObjSubOne_ThreeComplete)
            {
                currentPlayer.data.sideObjSubOne_ThreeComplete = true;
                checkProgression("sideOne");
                UpdatePlayer();
                LoadSideObjectiveOne();
                ObjectivePopUp(mainObjSubThreeTitle.text);
            }
        }
        else if (objective == "sideTwoSubOne")
        {
            if (!currentPlayer.data.sideObjSubTwo_OneComplete)
            {
                currentPlayer.data.sideObjSubTwo_OneComplete = true;
                checkProgression("sideTwo");
                UpdatePlayer();
                LoadSideObjectiveTwo();
                ObjectivePopUp(mainObjSubOneTitle.text);
            }
        }
        else if (objective == "sideTwoSubTwo")
        {
            if (!currentPlayer.data.sideObjSubTwo_TwoComplete)
            {
                currentPlayer.data.sideObjSubTwo_TwoComplete = true;
                checkProgression("sideTwo");
                UpdatePlayer();
                LoadSideObjectiveTwo();
                ObjectivePopUp(mainObjSubTwoTitle.text);
            }
        }
        else if (objective == "sideTwoSubThree")
        {
            if (!currentPlayer.data.sideObjSubTwo_ThreeComplete)
            {
                currentPlayer.data.sideObjSubTwo_ThreeComplete = true;
                checkProgression("sideTwo");
                UpdatePlayer();
                LoadSideObjectiveTwo();
                ObjectivePopUp(mainObjSubThreeTitle.text);
            }
        }
    }

   
    public IEnumerator NewChapterStarted()
    {
        ChapterUpdateWindow.SetActive(true);
        yield return StartCoroutine(RunChapterTitle());
        yield return new WaitForSeconds(6);
        LogOff();
        ChapterUpdateWindow.SetActive(false);

    }

    IEnumerator RunChapterTitle()
    {
        foreach(char letter in currentChapterTitle.text)
        {
            newChapterText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void ObjectivePopUp(string objective)
    {
        objectiveCompleteText.text = objective;
        objectiveCompleteWindow.SetActive(true);
        objectiveCompleteWindow.transform.SetSiblingIndex(parentChildren - 1);
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

        UpdatePlayer();

        LoadMainObjectiveOne();

    }


}
