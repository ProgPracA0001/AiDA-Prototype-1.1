using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public string username {  get; set; }
    public string password { get; set; }
    public string firstname { get; set; }
    public string lastname { get; set; }
    public string currentChapterTitle;
    public int currentChapterNo;



    public Player()
    {
        currentChapterTitle = "Chapter One: An Inherited Legacy";
        currentChapterNo = 1;

    }

}

