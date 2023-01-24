using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using TMPro;

//Name: Sner Saha
//Date: 20 January 2023
//Program Name: PlayerCards
//Project: Culminating (Blackjack)
//Purpose: Used to set up and print the scoreboard

public class Scoreboard : MonoBehaviour
{
    //Used to hold the maximum of scoreboard entries
    private int scoreboardEntries = 5;
    //Used to hold the rank text
    public TextMeshProUGUI rankText = null; 
    //Used to hold the name text
    public TextMeshProUGUI nameText = null;
    //Used to hold the score text
    public TextMeshProUGUI scoreText = null;
    //Used to hold all the scores
    public int[] scoreList;
    //Used to hold all the names
    public string[] nameList;
    //Used to match the scores to the names
    public Dictionary<int, string> sortSheet = new Dictionary<int, string>();


    //Start is called at the begining of the script
    public void Start()
    {
        //Set the name list
        SetNameList();
        //Set the score list
        SetScoreList();
        //Set the dict
        SetDict();
        //Prints the scoreboard
        PrintScoreboard();
    }
    //Sets the dict
    public void SetDict()
    {
       //For every score in scorelist
        for (int i = 0; i < scoreList.Length; i++)
        {
            //If the score already exists
            if (sortSheet.ContainsKey(scoreList[i]))
            {
                //Removes the old score
                sortSheet.Remove(scoreList[i]);
                //Adds the new score
                sortSheet.Add(scoreList[i], nameList[i]);
            }
            //If it doesn't,
            else
            {
                //Adds it to the dict
                sortSheet.Add(scoreList[i], nameList[i]);
            }
        }
       
       //Sorts the scorelist from low to high
       Array.Sort(scoreList);
       //Reverse the scorelist from high to low
       Array.Reverse(scoreList);
    }
    //Prints the scoreboard
    public void PrintScoreboard()
    {
        //Will print until scoreboardEntries
        for (int i = 0; i < scoreboardEntries; i++)
        {
            //Prints rank text
            rankText.text += (i + 1) + "\n";
            //Prints the name text
            nameText.text += sortSheet[scoreList[i]] + "\n";
            //Prints the score text
            scoreText.text += "$" + scoreList[i] + "\n";
        }
    }
    //Reads from the text file
    public void SetNameList()
    {
        //Path to name text file
        string path = "Assets/names.txt";

        //Sets the stream reader
        StreamReader reader = new StreamReader(path, true);

        //used to hold all the text from the file
        string names = reader.ReadToEnd();

        //Splits the text then returns it into an string[]
        nameList = names.Split(",");
    }
    //Reads from the score file
    public void SetScoreList()
    {
        //Path to score text file
        string path = "Assets/scores.txt";

        //Sets the stream reader
        StreamReader reader = new StreamReader(path, true);

        //Used to hold all the text from the file
        string scores = reader.ReadToEnd();
        
        //Splits the text, parses the text for integers, then returns it into an int[]
        scoreList = Array.ConvertAll(scores.Split(","), int.Parse);
    }
}

