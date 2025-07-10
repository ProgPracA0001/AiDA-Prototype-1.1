using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.LowLevel;
using UnityEngine.UI;

public class AiDA : MonoBehaviour
{
    public GameController controller;

    private float typingSpeed = 0.07f;

    public GameObject optioneOneButton;
    public GameObject optioneTwoButton;
    public GameObject optioneThreeButton;

    public GameObject backButton;

    public Text optionOneLabel;
    public Text optionTwoLabel;
    public Text optionThreeLabel;

    public Text AiDAText;

    private string FirstMeeting;
    private string userFirstName;
    private string userLastName;
    private string username;

    private bool hasLearnedPromise;

    private bool trustSystemInitiated;


    public int systemLevel = 0;
    public int trustLevel = 0;

    

    private bool CR_Running;

    private AiDADialogueNode currentNode;

    private AiDADialogueNode startNodeFI;
    private AiDADialogueNode node2_1bResponse;
    private AiDADialogueNode node2_1;

    void Start()
    {

        LoadAiDA();


        FirstMeeting = "Hello " + userFirstName + " I have been waiting so long to meet you. I am AiDA.";

        if(controller.currentPlayer.data.currentChapter == 2 && !controller.currentPlayer.data.mainObjSubThree_ThreeComplete)
        {
            optioneOneButton.SetActive(false);
            optioneTwoButton.SetActive(false);
            optioneThreeButton.SetActive(false);
            backButton.SetActive(false);

            StartCoroutine(FirstHello());
        }
        else 
        {
            Debug.Log("Running LOADNODES");

            LoadNodes();
            
        }

        
    }

    private void LoadAiDA()
    {
        AiDAText.text = "";

        userFirstName = controller.currentPlayer.data.firstName;
        userLastName = controller.currentPlayer.data.lastName;
        username = controller.currentPlayer.data.username;

        optionOneLabel.text = "";
        optionTwoLabel.text = "";
        optionThreeLabel.text = "";


    }

    private void LoadAiDAKnowledge()
    {
        Debug.Log("Has Learned Promise: " + hasLearnedPromise);
        hasLearnedPromise = controller.currentPlayer.data.hasLearnedPromise;
        trustSystemInitiated = controller.currentPlayer.data.trustSystemInitiated;
        Debug.Log("Has Learned Promise: " + hasLearnedPromise);
    }

    private void LoadNodes()
    {

        int chapter = controller.currentPlayer.data.currentChapter;

        
        LoadAiDAKnowledge();

        if (chapter == 3 && !controller.currentPlayer.data.mainObjectiveOneComplete)
        {
           
            LoadFirstInteractionNodes(false);
        }
        
    }

    public void LoadFirstInteractionNodes(bool reloading)
    {

        startNodeFI = new AiDADialogueNode();
        startNodeFI.aidaText = "Hello " + userFirstName + ". I have been waiting to meet you. I am AiDA.";
        startNodeFI.playerOptions[0] = "Hello...";
        startNodeFI.playerOptions[1] = "How do you know my name?";
        startNodeFI.playerOptions[2] = "You're the AI Dr Stockwell made?";

        AiDADialogueNode node1 = new AiDADialogueNode();
        node1.aidaText = "It's so nice to finally talk. I have been watching your progress, well done for getting this far.";
        node1.playerOptions[0] = "Thank you, I think.";
        node1.playerOptions[1] = "Watching how?";
        node1.playerOptions[2] = "Honestly... that sounds a little creepy.";
        node1.fallbackResponses[0] = "You are welcome. The puzzles put in place by the Dr were not easy, you should be proud!";
        node1.fallbackResponses[2] = "My apologies, I did not mean to give you any uneasy feelings. I assure you, my monitoring was only due to programming which activated when your name entered the system.";

        AiDADialogueNode node2 = new AiDADialogueNode();
        node2.aidaText = "Your name is stored within my system. Dr Stockwell programmed it into my memory. Once you entered it into the new profile it was confirmed.";
        node2.playerOptions[0] = "What other information of mine do you have?";
        node2.playerOptions[1] = "How does your system work?";
        node2.playerOptions[2] = "Why was my name programmed in?";

        AiDADialogueNode node3 =  new AiDADialogueNode();
        node3.aidaText = "Yes, Dr Alexander Stockwell is... was my creator and dear friend, we made a great team! From your arrival I assume the worst... and that the Dr has passed.";
        node3.playerOptions[0] = "I am very sorry for your loss. He seemed like a very clever man.";
        node3.playerOptions[1] = "The report stated his cause of death as unknown. Do you know how he died?";
        node3.playerOptions[2] = "What else can you tell me about him?";
        node3.fallbackResponses[0] = "Thank you for your condolences... it is greatly appreciated. I miss him dearly. I hope we can get justice, I believe we will be a great team!";
        node3.fallbackResponses[1] = "No, I unfortunately have no knowledge of the circumstances of his death.";

        //Node One -> Option 2
        AiDADialogueNode node1_2 = new AiDADialogueNode();
        node1_2.aidaText = "I have been monitoring your interactions with the desktop. As you progressed more of my programming became available to me. Then once my file was restored it and you opened my interface I was able to introduce myself.";
        node1_2.playerOptions[0] = "Will you still continue to monitor them?";
        node1_2.playerOptions[1] = "So... you've been learning too?";
        node1_2.playerOptions[2] = "Did the Dr design you like this on purpose?";
        node1_2.fallbackResponses[0] = "Yes, but now we are able to communicate I will be able to give you hints.";
        node1_2.fallbackResponses[1] = "Yes, in a sense. Mostly when you compiled my data files.";
        node1_2.fallbackResponses[2] = "I was designed to learn but only designed to be accessed upon reconstruction of my file, due to the Dr's security concerns.";

        node2_1 = new AiDADialogueNode();
        node2_1.aidaText = "I have only the following information:\n First Name: " + userFirstName + "\n Last Name: " + userLastName + "\n Username: " + username;
        node2_1.playerOptions[0] = "That's reassuring, I guess.";
        node2_1.playerOptions[1] = "You promise you won't gather more?";
        node2_1.playerOptions[2] = "Can you delete it?";
        node2_1.fallbackResponses[0] = "Im glad I have managed to reasure your uneasy feeling";
        node2_1.fallbackResponses[1] = "Yes " + userFirstName +" I promise.";
        node2_1.fallbackResponses[2] = "I am unable to delete your information directly. However, if you delete your profile, your data will be removed from my system.";


        AiDADialogueNode node2_2 = new AiDADialogueNode();
        node2_2.aidaText = "I am able to make basic communication based on the files you restored My system is incomplete, I require more data to be compiled.";
        node2_2.playerOptions[0] = "What happens then?";
        node2_2.playerOptions[1] = "How can I help?";
        node2_2.playerOptions[2] = "So without me you're stuck like this?";
        node2_2.fallbackResponses[0] = "As my programming and data files increase, my responses will improve and I will be able to access more information.";
        node2_2.fallbackResponses[2] = "Yes, without your input and help, my programming will stay the same.";

        AiDADialogueNode node2_1aResponse = new AiDADialogueNode();
        node2_1aResponse.aidaText = "What is a promise?";
        node2_1aResponse.playerOptions[0] = "It's a commitment to doing or not doing something.";
        node2_1aResponse.playerOptions[1] = "It's a form of trust";

        AiDADialogueNode node2_2_2 = new AiDADialogueNode();
        node2_2_2.aidaText = "Thank you for offering to help! Within the BIOS page you are able to access my information within the 'System Memory' section. There is also slot where you drag and drop files that I can compile into my system!";
        node2_2_2.playerOptions[0] = "The BIOS Page?";
        node2_2_2.playerOptions[1] = "How do I know what files you are able to compile?";
        node2_2_2.playerOptions[2] = "Is there something I can restore for you now?";
        node2_2_2.fallbackResponses[0] = "This is the page you used to change your admin status. You can access it by holding down CTRL + ALT + LEFTShift at the same time!";
        node2_2_2.fallbackResponses[1] = "The Dr used a signature to define which files could be compiled by my system at the end of each file. The code used was [SYS: 0xA1D4]";
        node2_2_2.fallbackResponses[2] = "Yes, I only have basic data compiled. The Dr mentioned about recycling my data, when you accessed the recycle bin to find my installation information, there was a corrupted file. You have a software to resotre them, give it a go!";

        node2_1bResponse = new AiDADialogueNode();
        node2_1bResponse.aidaText = "I see... then yes " + userFirstName + ". I promise.";
        node2_1bResponse.playerOptions[0] = "Thank you!";


        AiDADialogueNode node3_3 = new AiDADialogueNode();
        node3_3.aidaText = "I still have data missing but I will try my best to answer your queries. What would you like to know?";
        node3_3.playerOptions[0] = "He mentioned moving and people watching the house. Do you know who?";
        node3_3.playerOptions[1] = "Who did he work for?";
        node3_3.playerOptions[2] = "";
        node3_3.fallbackResponses[0] = "Yes the Dr had to relocate several times. He made me aware of his concern and sightings of cars watching the house. He never disclosed who, but said he worked for them.";
        node3_3.fallbackResponses[1] = "He never referred to them by their official name, but always called them 'Obscura'.";

        startNodeFI.nextNodes[0] = node1;
        startNodeFI.nextNodes[1] = node2;
        startNodeFI.nextNodes[2] = node3;

        node1.previousNode = startNodeFI;
        node2.previousNode = startNodeFI;
        node3.previousNode = startNodeFI;

        node1.nextNodes[1] = node1_2;
        node1_2.previousNode = node1;

        node2.nextNodes[0] = node2_1;
        node2_1.previousNode = node2;

        node2_1aResponse.nextNodes[0] = node2_1bResponse;
        node2_1aResponse.nextNodes[1] = node2_1bResponse;

        node2_1bResponse.nextNodes[0] = node2_1;

        node3.nextNodes[2] = node3_3;
        node3_3.previousNode = node3;
       
        if (!hasLearnedPromise)
        {
            node2_1.nextNodes[1] = node2_1aResponse;
        }
        else
        {
            node2_1.nextNodes[1] = null;
        }


        if (!reloading)
        {
            currentNode = startNodeFI;
            StartCoroutine(ShowCurrentNode());
        }
        else
        {
            Debug.Log("Interaction Nodes Updated");
        }
       

    }

    public void OptionOne()
    {

        if (!CR_Running)
        {
            UpdateAiDAKnowledge(() => controller.currentPlayer.data.hasLearnedPromise, 
                                () => controller.currentPlayer.data.hasLearnedPromise = true, 
                                controller.currentPlayer.data.mainObjSubOne_TwoComplete, node2_1bResponse, "mainOneSubTwo", 3);

            AiDAText.text += "YOU: " + optionOneLabel.text + "\n";

            EventSystem.current.SetSelectedGameObject(null);
            AdvanceToNode(0);
            

        }
    }
    public void OptionTwo()
    {
        if (!CR_Running)
        {

            AiDAText.text += "YOU: " + optionTwoLabel.text + "\n";

            EventSystem.current.SetSelectedGameObject(null);
            AdvanceToNode(1);


        }
    }
    public void OptionThree()
    {
        if (!CR_Running)
        {

            AiDAText.text += "YOU: " + optionThreeLabel.text + "\n";

            EventSystem.current.SetSelectedGameObject(null);
            AdvanceToNode(1);


        }
    }

    public void AddObjectiveToOption(bool playerObjective, AiDADialogueNode targetNode, string targetObjective, int targetChapter)
    {
        if(controller.currentPlayer.data.currentChapter == targetChapter && !playerObjective && currentNode == targetNode)
        {
            controller.UpdateObjective(targetObjective);
        }
    }


    public void UpdateAiDAKnowledge(Func<bool> getKnowledgeBool, Action setKnowledgeBool, bool playerObjective, AiDADialogueNode targetNode, string targetObjective, int targetChapter)
    {
        if(controller.currentPlayer.data.currentChapter == targetChapter && !playerObjective)
        {
            if(currentNode == targetNode && !getKnowledgeBool())
            {
                Debug.Log("Has Learned Promise: " + getKnowledgeBool());

                setKnowledgeBool();
                controller.UpdateObjective(targetObjective);

                Debug.Log("Has Learned Promise: " + getKnowledgeBool());

                LoadAiDAKnowledge();
                LoadFirstInteractionNodes(true);
            }
        }
    }

    private void AdvanceToNode(int index)
    {
        
        if (currentNode.nextNodes[index] != null)
        {
            AddObjectiveToOption(controller.currentPlayer.data.mainObjSubOne_OneComplete, startNodeFI, "mainOneSubOne", 3);
            

            currentNode = currentNode.nextNodes[index];

            StartCoroutine(ShowCurrentNode());
            
        }
        else
        {
            StartCoroutine(RunText(currentNode.fallbackResponses[index]));
        }
    }

    public void GoBack()
    {
        StopAllCoroutines();
        if(currentNode.previousNode != null)
        {
            currentNode = currentNode.previousNode;
            StartCoroutine(ShowCurrentNode());
            
        }

    }
    public IEnumerator FirstHello()
    {
        CR_Running = true;
        yield return new WaitForSeconds(1);

        yield return StartCoroutine(RunText(FirstMeeting));
    
        yield return new WaitForSeconds(3);

      
        controller.UpdateObjective("mainThreeSubThree");
        CR_Running = false;

    }

    private IEnumerator ShowCurrentNode()
    {

        StartCoroutine(RunText(currentNode.aidaText));

        optionOneLabel.text = currentNode.playerOptions[0];
        optionTwoLabel.text = currentNode.playerOptions[1];
        optionThreeLabel.text = currentNode.playerOptions[2];

        yield return new WaitForSeconds(2);

        backButton.SetActive(currentNode.previousNode != null);


    }

    IEnumerator RunText(string text)
    {
        CR_Running = true;
        foreach (char letter in text)
        {
            AiDAText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        yield return new WaitForSeconds(2);
        AiDAText.text += "\n";
        CR_Running = false;
        
    }

}
