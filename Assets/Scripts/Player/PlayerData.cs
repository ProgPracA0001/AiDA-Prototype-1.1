using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerData
{
    //Player details
    public string username = "";
    public string firstName = "";
    public string lastName = "";

    //Player notepad
    public string notes = "";

    //PLAYER AiDA DATA
    public bool AiDAInstalled = false;
    public string AiDALog = "";
    public int AiDATrustLevel = 0;
    public bool hasLearnedPromise = false;
    public bool trustSystemInstalled = false;
    public bool trustSystemActive = false;

    //Chapter Details
    public int currentChapter = 1;
    public string currentChapterName = "Chapter One: An inherited Legacy...";
    
    //Installations and firstInteractions;
    public bool firstTimeLoginComplete = false;
    public bool recuseBitFirstTimeOpeningComplete = false;

    public bool internetLinkInstalled = false;
    public bool internetConnected = false;
    public bool RescueBitInstalled = false;

    public bool ghostSiteUnlocked = false;

    public bool recycleUnlocked = false;

    public bool playerIsAdmin = false;

    //Subject Zero Restoration Progress
    public bool emotionRestored = false;
    public bool timeRestored = false;
    public bool greetingsRestored = false;

    public bool subject0Restored = false;

    //Corrupted File Status
    public bool diary05Corrupted = true;
    public bool XFileCorrupted = true;

    //Chapter trackers
    public bool chapterOneComplete = false;
    public bool chapterTwoComplete = false;
    public bool chapterThreeComplete = false;
    public bool chapterFourComplete = false;
    public bool chapterFiveComplete = false;
    public bool chapterSixComplete = false;
    public bool chapterSevenComplete = false;

    //Main Objective Trackers
    public bool mainObjectiveOneComplete = false;
    public bool mainObjectiveTwoComplete = false;
    public bool mainObjectiveThreeComplete = false;

    //Main Objective One Tracker
    public bool mainObjSubOne_OneComplete = false;
    public bool mainObjSubOne_TwoComplete = false;
    public bool mainObjSubOne_ThreeComplete = false;

    //Main Objective Two Tracker
    public bool mainObjSubTwo_OneComplete = false;
    public bool mainObjSubTwo_TwoComplete = false;
    public bool mainObjSubTwo_ThreeComplete = false;

    //Main Objective Three Tracker
    public bool mainObjSubThree_OneComplete = false;
    public bool mainObjSubThree_TwoComplete = false;
    public bool mainObjSubThree_ThreeComplete = false;

    //Side Objective Trackers
    public bool sideObjectiveOneComplete = false;
    public bool sideObjectiveTwoComplete = false;

    //Side Objective One Tracker
    public bool sideObjSubOne_OneComplete = false;
    public bool sideObjSubOne_TwoComplete = false;
    public bool sideObjSubOne_ThreeComplete = false;

    //Side Objective Two Tracker
    public bool sideObjSubTwo_OneComplete = false;
    public bool sideObjSubTwo_TwoComplete = false;
    public bool sideObjSubTwo_ThreeComplete = false;

}
