using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotePad : MonoBehaviour
{
    public GameController player;

    public InputField notePadInput;

    private void Start()
    {
       if (player.currentPlayer.data.notes != null)
        {
            notePadInput.text = player.currentPlayer.data.notes;
        }
    }

    void Update()
    {
        player.currentPlayer.data.notes = notePadInput.text;
    }

    public void SaveNotes()
    {
        if (player.currentPlayer.data.currentChapter == 1 && !player.currentPlayer.data.mainObjSubTwo_ThreeComplete && notePadInput != null)
        {
            player.currentPlayer.data.notes = notePadInput.text;
            player.UpdateObjective("mainTwoSubThree");
        }
        else
        {
            player.currentPlayer.data.notes = notePadInput.text;
            player.UpdatePlayer();
        }

    }
}
