using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiDADialogueNode 
{
    public string aidaText;
    public string[] playerOptions = new string[3];
    public AiDADialogueNode[] nextNodes = new AiDADialogueNode[3];
    public AiDADialogueNode previousNode;

    public string[] fallbackResponses = new string[3]; //If there is no next node

    // Trust effects for player options
    public int[] trustEffects =  new int[3]; // +1, -1, 0 etc

    public Action[] onOptionSelected = new Action[3];
   
}
