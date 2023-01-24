using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

//Name: Sner Saha
//Date: 20 January 2023
//Program Name: PlayerCards
//Project: Culminating (Blackjack)
//Purpose: Used to get the player's name

public class Information : MonoBehaviour
{
    //Used to store the player input
    public TMP_InputField firstNameInput;
    //Used to stor the player error text
    public TextMeshProUGUI firstNameError;

    //When the player presses "LOGIN"
    public void Login()
    {
        //If the player input is 3 characters
        if (firstNameInput.text.Length == 3)
        {
            //Adds the input to the name.txt file
            File.AppendAllText("Assets/names.txt", "," + firstNameInput.text);
            //Loads up the title screen
            SceneManager.LoadScene(sceneBuildIndex: 0);
        }
        //If not,
        else
        {
            //Clears player input
            firstNameInput.text = "";
            //Writes the player error text
            firstNameError.text = "Name must be 3 characters";
        }   
    }
}
