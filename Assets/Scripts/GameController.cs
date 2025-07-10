using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //Player Manager from the first scene
    public GameObject playerManagerObject;
    public PlayerManager currentPlayer;
    public AiDA AiDAManager;

    [SerializeField] public Sprite objectiveComplete;
    public Sprite objectiveDefault;

    public GameObject objectivesWindow;
    public GameObject welcomeWindow;
    public GameObject objectiveCompleteWindow;
    public GameObject ChapterUpdateWindow;

    public Text welcomeWindowText;

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

    public GameObject internetIcon;
    public GameObject webCrawlerIcon;
    public GameObject rescueBitIcon;
    public GameObject AiDAIcon;

    public bool controlPressed = false;
    public bool shiftPressed = false;
    public bool altPressed = false;

    public GameObject BIOSWindow;

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
            UpdateObjective("mainOneSubOne");

        }

        LoadIcons();

        if(currentPlayer.data.currentChapter >= 3)
        {
            LoadAiDA();
            welcomeWindow.SetActive(true);
            welcomeWindowText.text = "Thank you for playing AiDA! You have completed all current chapters! Feel free to look around the desktop however things will not work properly as this Chapter is still in development.s Thank you again for your participation in our Early Access build, and watch out for new updates!";

        }
        //If returning player then main objective one is loaded.
        LoadMainObjectiveOne();
       
    }

    void Update()
    {
        parentChildren = objectiveCompleteWindow.transform.parent.childCount;

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            controlPressed = true;
        }
        else if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            controlPressed = false;
        }
        
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            shiftPressed = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            shiftPressed = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            altPressed = true;
        }
        else if(Input.GetKeyUp(KeyCode.LeftAlt))
        {
            altPressed = false;
        }


        if (controlPressed && shiftPressed && altPressed)
        {
            CheckToOpenBios();
        }
    }

    public void CheckToOpenBios()
    {
        if (currentPlayer.data.currentChapter >= 2)
        {
            BIOSWindow.GetComponent<WindowControllerScript>().Open();
        }
    }

    public void LoadAiDA()
    {
        AiDAManager.trustLevel = currentPlayer.data.AiDATrustLevel;

    }

    public void LoadIcons()
    {
        if (currentPlayer.data.internetLinkInstalled != true)
        {
            internetIcon.SetActive(false);
        }

        if (currentPlayer.data.internetConnected != true)
        {
            webCrawlerIcon.SetActive(false);
        }

        if (currentPlayer.data.RescureBitInstalled != true)
        {
            rescueBitIcon.SetActive(false);
        }

        if (currentPlayer.data.AiDAInstalled != true)
        {
            AiDAIcon.SetActive(false);
        }
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

    public void QuitGame()
    {
        currentPlayer.Save();
        Application.Quit();
    }
   
    //Loads Main objective One - checks the players current chapter and loads the corresponding objectives into the objective windows text.
    public void LoadMainObjectiveOne()
    {
        if (currentPlayer.data.currentChapter == 1)
        {
            mainObjectiveTitle.text = "1: New User Detected: Create a New Profile and First Time Login:";

            mainObjSubOneTitle.text = "1.1: Signed Up: Create User Profile and Login";
            mainObjSubOneDesc.text = "Set up a profile with a username, password and first name, then log in!";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubOne_OneComplete, mainObjSubOneIcon);

            mainObjSubTwoTitle.text = "1.2: Dr Who?: Find the Inheritance Message";
            mainObjSubTwoDesc.text = "Go through the Welcome File on the Desktop and read the Inheritance Report";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubOne_TwoComplete, mainObjSubTwoIcon);

            mainObjSubThreeTitle.text = "1.3: The Last Message: Find the Dr's Last Message";
            mainObjSubThreeDesc.text = "It looks like the Dr left something behind for you...";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubOne_ThreeComplete, mainObjSubThreeIcon);
        }
        else if (currentPlayer.data.currentChapter == 2)
        {
            mainObjectiveTitle.text = "1: Dial Up Dilemma: Connect To The Internet and Start Searching!";

            mainObjSubOneTitle.text = "1.1: Who You Gonna Call? Dial-Up Network!:";
            mainObjSubOneDesc.text = "How does Dial-Up work again? Maybe theres an information booklet we can use? Makes you miss the beauty of modern Wifi!";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubOne_OneComplete, mainObjSubOneIcon);

            mainObjSubTwoTitle.text = "1.2: Who Will You Actually Call Though?:";
            mainObjSubTwoDesc.text = "Seriously, these Dial-Up Networks actually require a legitimate line to link to... maybe the Dr left contact details?";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubOne_TwoComplete, mainObjSubTwoIcon);

            mainObjSubThreeTitle.text = "1.3: The World Wide Web: Get Connected!";
            mainObjSubThreeDesc.text = "Once you have the details you need, complete the Dial-Up Network Install and you're online!";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubOne_ThreeComplete, mainObjSubThreeIcon);
        }
        else if (currentPlayer.data.currentChapter == 3)
        {
            mainObjectiveTitle.text = "1: Ask AiDA: Go Through The Interactions to Learn More About AiDA";

            mainObjSubOneTitle.text = "1.1: The First Interaction: Say Something";
            mainObjSubOneDesc.text = "Well... you can't tell me you're NOT going to say hello... go on, say something!";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubOne_OneComplete, mainObjSubOneIcon);

            mainObjSubTwoTitle.text = "1.2: A Curious Mind: Teach AiDA Something New";
            mainObjSubTwoDesc.text = "AiDA knows a lot, but not everything. Explore the responses and see if there's something you can explain to her. She might surprise you.";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubOne_TwoComplete, mainObjSubTwoIcon);

            mainObjSubThreeTitle.text = "1.3: System Check: AiDA's Full Potential";
            mainObjSubThreeDesc.text = "There's more to AiDA than what is currently seen. Find out more about how her system works, if its limited and if you can help restore any more of her system.";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubOne_ThreeComplete, mainObjSubThreeIcon);
        }
    }
    //Loads Main objective Two - checks the players current chapter and loads the corresponding objectives into the objective windows text.
    public void LoadMainObjectiveTwo()
    {
        if(currentPlayer.data.currentChapter == 1)
        {    
            mainObjectiveTitle.text = "2: The File Explorer: Explore the Desktop's Main Folders";

            mainObjSubOneTitle.text = "2.1: Byte-Sized Expedition: Find the Dr's Diaries";
            mainObjSubOneDesc.text = "Scattered around the desktop are the Dr's personal files, explore them, some may contain vital information";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubTwo_OneComplete, mainObjSubOneIcon);

            mainObjSubTwoTitle.text = "2.2: First Questions: Access to the Research File is Protected";
            mainObjSubTwoDesc.text = "Enter the correct word to unlock the Research folder, certain phrases may be found in other documents.";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubTwo_TwoComplete, mainObjSubTwoIcon);

            mainObjSubThreeTitle.text = "2.3: Note To Self: Note Down Your Clues and Findings";
            mainObjSubThreeDesc.text = "Not everything can be kept in your mind! Start noting your findings and save them in the notepad";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubTwo_ThreeComplete, mainObjSubThreeIcon);
        }
        else if (currentPlayer.data.currentChapter == 2)
        {
            mainObjectiveTitle.text = "2: The Restricted Section: Access Restricted Folders";
         
            mainObjSubOneTitle.text = "2.1: Notes from The Dr's Hand Himself:";
            mainObjSubOneDesc.text = "Further into the files you notice that there's more of the Dr's research. Look for some notes that he has digitised!";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubTwo_OneComplete, mainObjSubOneIcon);

            mainObjSubTwoTitle.text = "2.2: A Guide Through the Fire:";
            mainObjSubTwoDesc.text = "A Firewall App Blocker security software is blocking your access to the Restricted Section! Figure out how to disable it, maybe some files or documents can help!";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubTwo_TwoComplete, mainObjSubTwoIcon);

            mainObjSubThreeTitle.text = "2.3: Call the Fireman: Bypass the Security Software:";
            mainObjSubThreeDesc.text = "Disable the Firewall and gain access to the restricted section!";
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

    //Loads Main objective Three - checks the players current chapter and loads the corresponding objectives into the objective windows text.
    public void LoadMainObjectiveThree()
    {
        if(currentPlayer.data.currentChapter == 1)
        {    
            mainObjectiveTitle.text = "3: Access Denied: Unlock the MyFile Folder";

            mainObjSubOneTitle.text = "3.1: Hidden in The Binary: The First Clue";
            mainObjSubOneDesc.text = "Somewhere on the desktop is the first clue, time to track it down! The MyFile questions look like some of the Dr's documents.";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubThree_OneComplete, mainObjSubOneIcon);

            mainObjSubTwoTitle.text = "3.2: Piecing It Together: Second Clue In The Queue:";
            mainObjSubTwoDesc.text = "The second piece of information we need is around here somewhere...";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubThree_TwoComplete, mainObjSubTwoIcon);

            mainObjSubThreeTitle.text = "3.3: Quiz Time: Enter The Correct Answers and Unlock the Folder:";
            mainObjSubThreeDesc.text = "You have all the information you need, it's time to unlock the file!";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubThree_ThreeComplete, mainObjSubThreeIcon);
        }
        else if (currentPlayer.data.currentChapter == 2)
        {
            mainObjectiveTitle.text = "3: The Restoration Project: Restore The Corrupted Files";

            mainObjSubOneTitle.text = "3.1: Software Will Sort It: Install The File Restoration Software";
            mainObjSubOneDesc.text = "A software that restores corrupted files is mentioned... If you have access to the internet maybe you can search for a download? Then test it by restoring the Diary05 file!";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubThree_OneComplete, mainObjSubOneIcon);

            mainObjSubTwoTitle.text = "3.2: Hidden In Plain Sight: A Secret File?";
            mainObjSubTwoDesc.text = "Restore all corrupted files and using the documents in the Restricted Section correctly compile them into their categories to reveal the secret file.";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubThree_TwoComplete, mainObjSubTwoIcon);

            mainObjSubThreeTitle.text = "3.3: Restoration Complete: Install The Project";
            mainObjSubThreeDesc.text = "Install the project by using the correct values for training the model. Some files may be elsewhere within the system, have you checked the recycle bin?";
            LoadObjectiveStatus(currentPlayer.data.mainObjSubThree_ThreeComplete, mainObjSubThreeIcon);
        }
        else if (currentPlayer.data.currentChapter == 3)
        {
            mainObjectiveTitle.text = "";
            mainObjSubOneTitle.text = "";
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

    //Loads Side objective One - checks the players current chapter and loads the corresponding objectives into the objective windows text.
    public void LoadSideObjectiveOne()
    {
        if (currentPlayer.data.currentChapter == 1)
        {
            mainObjectiveTitle.text = "S1: The Old Post: Enter the Correct Password and Access the Mystery Newspaper ";

            mainObjSubOneTitle.text = "S1.1: Find The First Clue: Contact List";
            mainObjSubOneDesc.text = "The Dr liked to take a lot of notes, maybe something can help!";
            LoadObjectiveStatus(currentPlayer.data.sideObjSubOne_OneComplete, mainObjSubOneIcon);

            mainObjSubTwoTitle.text = "S1.2: Clue Number Two: Food Supplies";
            mainObjSubTwoDesc.text = "Clue Number Two is similar to the first, I think the Dr was hungry when he came up with this!";
            LoadObjectiveStatus(currentPlayer.data.sideObjSubOne_TwoComplete, mainObjSubTwoIcon);

            mainObjSubThreeTitle.text = "S1.3: The Clue Slueth:";
            mainObjSubThreeDesc.text = "Using both clues solve the password to gain access to the Newspaper";
            LoadObjectiveStatus(currentPlayer.data.sideObjSubOne_ThreeComplete, mainObjSubThreeIcon);

        }
        else if (currentPlayer.data.currentChapter == 2)
        {
            mainObjectiveTitle.text = "S1: Deep Dive: Find out more about the Dr's job";

            mainObjSubOneTitle.text = "S1.1: Old Headliners: From Paper to Digital";
            mainObjSubOneDesc.text = "Remember that old newspaper you found? Maybe a search online will give us some updates? Use the journalists name or the newspaper title!";
            LoadObjectiveStatus(currentPlayer.data.sideObjSubOne_OneComplete, mainObjSubOneIcon);

            mainObjSubTwoTitle.text = "S1.2: Pattern Pending: A Strange Recurrence?";
            mainObjSubTwoDesc.text = "While reading through articles, two words keep appearing. Why would the same source use the samelanguage or phrasing? It might be worth a search. ";
            LoadObjectiveStatus(currentPlayer.data.sideObjSubOne_TwoComplete, mainObjSubTwoIcon);

            mainObjSubThreeTitle.text = "S1.3: Uncover the Unseen: Joiners Secret Site";
            mainObjSubThreeDesc.text = "Something about the wording lingers... Familiar steps, repeated in the right order, might open more than just a door.";
            LoadObjectiveStatus(currentPlayer.data.sideObjSubOne_ThreeComplete, mainObjSubThreeIcon);
        }
        else if (currentPlayer.data.currentChapter == 3)
        {

        }
    }

    //Loads Side objective Two - checks the players current chapter and loads the corresponding objectives into the objective windows text.
    public void LoadSideObjectiveTwo()
    {
        if(currentPlayer.data.currentChapter == 1)
        {
            mainObjectiveTitle.text = "S2: Voice From the Void: Unlock Mystery Audio File";

            mainObjSubOneTitle.text = "S2.1: Combo Clue One: Find the First Clue To The Combination";
            mainObjSubOneDesc.text = "This clue contains half the information you need for the combination!";
            LoadObjectiveStatus(currentPlayer.data.sideObjSubTwo_OneComplete, mainObjSubOneIcon);

            mainObjSubTwoTitle.text = "S2.2: Make It Make Sense: Find The Second Clue";
            mainObjSubTwoDesc.text = "This clue might require another file to be unlocked! But together, they should make sense!";      
            LoadObjectiveStatus(currentPlayer.data.sideObjSubTwo_TwoComplete, mainObjSubTwoIcon);

            mainObjSubThreeTitle.text = "S2.3: A Good Combination";
            mainObjSubThreeDesc.text = "The clues together will allow for you work out the correct combination, you might want to keep notes!";
            LoadObjectiveStatus(currentPlayer.data.sideObjSubTwo_ThreeComplete, mainObjSubThreeIcon);

        }
        else if (currentPlayer.data.currentChapter == 2)
        {
            mainObjectiveTitle.text = "S2: Recycle Deciple: Unlock The Recycle Bin";

            mainObjSubOneTitle.text = "S2.1: Making A Start: A Move In The Right Direction";
            mainObjSubOneDesc.text = "Try searching on the internet for information about admin passwords, maybe something can help.";
            LoadObjectiveStatus(currentPlayer.data.sideObjSubTwo_OneComplete, mainObjSubOneIcon);

            mainObjSubTwoTitle.text = "S2.2: Instructions: Taking Control";
            mainObjSubTwoDesc.text = "Using what you have found online, change your user privilege to ADMIN.";
            LoadObjectiveStatus(currentPlayer.data.sideObjSubTwo_TwoComplete, mainObjSubTwoIcon);

            mainObjSubThreeTitle.text = "S2.3: Sifting Through The Trash: Gain Access To The Recycle Bin";
            mainObjSubThreeDesc.text = "Once you have obtained an Admin Password give it a go! Unlock the Recycle Bin and look for that file the Dr mentioned for installing the software!";
            LoadObjectiveStatus(currentPlayer.data.sideObjSubTwo_ThreeComplete, mainObjSubThreeIcon);
        }
        else if (currentPlayer.data.currentChapter == 3)
        {
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

    //Loads and updates current objective completion status and displays the corresponding image
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

    //Checks Progression of a single objective and then checks chapter progression
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

    //Checks for completion of all objectives and updates the player, resets objectives and loads the new titles
    public void CheckChapterProgression()
    {
        if (currentPlayer.data.mainObjectiveOneComplete && currentPlayer.data.mainObjectiveTwoComplete && currentPlayer.data.mainObjectiveThreeComplete && currentPlayer.data.sideObjectiveOneComplete && currentPlayer.data.sideObjectiveTwoComplete)
        {
            currentPlayer.data.currentChapter++;

            if (currentPlayer.data.currentChapter == 2)
            {
                currentPlayer.data.currentChapterName = "Chapter Two: Secrets Beneath The Surface";
                
                currentChapterTitle.text = "Chapter Two: Secrets Beneath The Surface";
                UpdatePlayer();
                currentPlayer.LoadPlayer();
                StartCoroutine(NewChapterStarted());
                ResetObjectives();
                
            }
            else if (currentPlayer.data.currentChapter == 3)
            {
                currentPlayer.data.currentChapterName = "Chapter Three: Booting Up The Past...";

                currentChapterTitle.text = "Chapter Three: Booting Up The Past\n Coming soon....\n Thank you so much for playing!";
                UpdatePlayer();
                currentPlayer.LoadPlayer();
                StartCoroutine(NewChapterStarted());
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
        ChapterUpdateWindow.SetActive(false);
        newChapterText.text = "";
        if(currentPlayer.data.currentChapter == 3)
        {
            LogOff();
        }

    }

    IEnumerator RunChapterTitle()
    {
        foreach(char letter in currentChapterTitle.text)
        {
            newChapterText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        Debug.Log("Objective Window closing");
        objectiveCompleteWindow.GetComponent<WindowControllerScript>().Close();
    }

    public void ObjectivePopUp(string objective)
    {
        StopCoroutine(WaitToCloseObjective());
        if (objectiveCompleteWindow.GetComponent<WindowControllerScript>().isOpen)
        {
            objectiveCompleteWindow.GetComponent<WindowControllerScript>().Close();
            
        }

        objectiveCompleteText.text = objective;
        objectiveCompleteWindow.GetComponent<WindowControllerScript>().Open();
        objectiveCompleteWindow.transform.SetSiblingIndex(parentChildren - 1);
        StartCoroutine(WaitToCloseObjective());
        

    }

    IEnumerator WaitToCloseObjective()
    {

        yield return new WaitForSeconds(8);
        objectiveCompleteWindow.GetComponent<WindowControllerScript>().Close();


    }


    //Once the player has progressed to the next chapter the objectives are then set to false
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
        objectivesWindow.GetComponent<WindowControllerScript>().Open();

    }


}
