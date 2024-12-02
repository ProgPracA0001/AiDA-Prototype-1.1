using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChapterManager : MonoBehaviour
{

    public string[] chapterTitles =
        {
            "Chapter One: An Inherited Legacy",
            "Chapter Two: Secrets Beneath The Surface",
        };

    public string[,] mainObjective1 = new string[,]
    {
        {"Signed Up", ""},
    };

    public string[,] mainObjective2 = new string[,]
    {
        {"", ""},
    };


    public Text objectiveTitle;



    public int currentChapter;

    // Start is called before the first frame update
    void Start()
    {
        PlayerManager.instance.LoadPlayerData();
        currentChapter = PlayerManager.instance.player.currentChapterNo;



    }

    void Update()
    {
        
    }

}
