using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerData
{


    public string username = "";
    public string firstName = "";
    public string lastName = "";

    public string notes = "";

    public int currentChapter = 1;
    public string currentChapterName = "Chapter One: An inherited Legacy...";
    
    public bool firstTimeLoginComplete = false;
    public bool recuseBitFirstTimeOpeningComplete = false;

    public bool internetLinkInstalled = false;
    public bool internetConnected = false;
    public bool RescureBitInstalled = false;

    public bool diary02Corrupted = true;

    public bool chapterOneComplete = false;
    public bool chapterTwoComplete = false;
    public bool chapterThreeComplete = false;
    public bool chapterFourComplete = false;
    public bool chapterFiveComplete = false;
    public bool chapterSixComplete = false;
    public bool chapterSevenComplete = false;

    public bool mainObjectiveOneComplete = false;
    public bool mainObjectiveTwoComplete = false;
    public bool mainObjectiveThreeComplete = false;

    public bool mainObjSubOne_OneComplete = false;
    public bool mainObjSubOne_TwoComplete = false;
    public bool mainObjSubOne_ThreeComplete = false;

    public bool mainObjSubTwo_OneComplete = false;
    public bool mainObjSubTwo_TwoComplete = false;
    public bool mainObjSubTwo_ThreeComplete = false;

    public bool mainObjSubThree_OneComplete = false;
    public bool mainObjSubThree_TwoComplete = false;
    public bool mainObjSubThree_ThreeComplete = false;

    public bool sideObjectiveOneComplete = false;
    public bool sideObjectiveTwoComplete = false;

    public bool sideObjSubOne_OneComplete = false;
    public bool sideObjSubOne_TwoComplete = false;
    public bool sideObjSubOne_ThreeComplete = false;

    public bool sideObjSubTwo_OneComplete = false;
    public bool sideObjSubTwo_TwoComplete = false;
    public bool sideObjSubTwo_ThreeComplete = false;

}
