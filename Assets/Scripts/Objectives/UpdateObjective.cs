using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateObjective : MonoBehaviour
{
    public GameController controller;

    public int chapterNo;

    public string objective;

    public void UpdatedObjective()
    {
        if (controller.currentPlayer.data.currentChapter <= chapterNo)
        {
            controller.UpdateObjective(objective);
        }
            
    }
}
