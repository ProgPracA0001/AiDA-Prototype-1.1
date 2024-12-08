using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerData data, playerOneData, playerTwoData, playerThreeData;


    private string playerOneFile = "player1.txt";
    private string playerTwoFile = "player2.txt";
    private string playerThreeFile = "player3.txt";

    public string selectedPlayer;

    public bool playerOneEmpty;
    public bool playerTwoEmpty;
    public bool playerThreeEmpty;

    public void Save()
    {
        if (selectedPlayer == "playerOne")
        {
            string json = JsonUtility.ToJson(data);
            WriteToFile(playerOneFile, json);

        }
        else if (selectedPlayer == "playerTwo")
        {
            string json = JsonUtility.ToJson(data);
            WriteToFile(playerTwoFile, json);

        }
        else if (selectedPlayer == "playerThree")
        {
            string json = JsonUtility.ToJson(data);
            WriteToFile(playerThreeFile, json);

        }
    }

    public void LoadAll()
    {
        playerOneData = new PlayerData();
        string playerOneJson = ReadFromFile(playerOneFile, ref playerOneEmpty);
        JsonUtility.FromJsonOverwrite(playerOneJson, playerOneData);

        playerTwoData = new PlayerData();
        string playerTwoJson = ReadFromFile(playerTwoFile, ref playerTwoEmpty);
        JsonUtility.FromJsonOverwrite(playerTwoJson, playerTwoData);

        playerThreeData = new PlayerData();
        string playerThreeJson = ReadFromFile(playerThreeFile, ref playerThreeEmpty);
        JsonUtility.FromJsonOverwrite(playerThreeJson, playerThreeData);
    }

    public void LoadPlayer()
    {
        if (selectedPlayer == "playerOne")
        {
            data = new PlayerData();
            string json = ReadFromFile(playerOneFile, ref playerOneEmpty);
            JsonUtility.FromJsonOverwrite(json, data);
        }
        else if (selectedPlayer == "playerTwo")
        {
            data = new PlayerData();
            string json = ReadFromFile(playerTwoFile, ref playerTwoEmpty);
            JsonUtility.FromJsonOverwrite(json, data);
        }
        else if (selectedPlayer == "playerThree")
        {
            data = new PlayerData();
            string json = ReadFromFile(playerThreeFile, ref playerThreeEmpty);
            JsonUtility.FromJsonOverwrite(json, data);

        }

    }

    private void WriteToFile(string fileName, string json)
    {
        string path = GetFilePath(fileName);
        FileStream fileStream = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(json);
        }
    }

    private string ReadFromFile(string fileName, ref bool playerEmpty)
    {
        string path = GetFilePath(fileName);
        Debug.Log(path);
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                return json;
            }
        }
        else
        {
            playerEmpty = true;
        }
        return "";
    }

    private string GetFilePath(string fileName)
    {
        return Application.persistentDataPath + "/" + fileName;
    }

    public void playerSelected(string currentPlayer)
    {
        selectedPlayer = currentPlayer;
    }

    public void LoadPlayerGame()
    {
        DontDestroyOnLoad(gameObject);
    }
}
