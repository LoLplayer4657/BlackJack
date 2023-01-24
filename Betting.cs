using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

//Name: Sner Saha
//Date: 20 January 2023
//Program Name: PlayerCards
//Project: Culminating (Blackjack)
//Purpose: Used to deal with all things betting (money handling, button handeling, and UI handeling)

public class Betting : MonoBehaviour
{
    //Used to store all the buttons
    public Button red, yellow, blue, green, black;
    //Used to store all the button texts
    public TextMeshProUGUI redText, yellowText, blueText, greenText, blackText;
    //Used to store the bank and betting text
    public TextMeshProUGUI bankText, bettingText;
    //Used to store the different chip amounts
    public int redAmount, yellowAmount, blueAmount, greenAmount, blackAmount;
    //Used to store the starting amount
    private int startingAmount = 200;
    //Used to store the bank amount
    public int bank;
    //Used to store the betting amount
    public int betting;
    //Used to hold all the buttons
    public GameObject buttonHolder;
    //Used to hold the startbutton
    public GameObject startButton;
    //Used to hold the leave button
    public GameObject leaveButton;
    //Used to hold the dealer's text
    public TextMeshProUGUI dealerText;

    //Start is called at the beggining of the script
    void Start()
    {
        //Set all the poker chip amounts
        SetAmounts();
        
        //Lets the player start betting
        StartBetting();
    }
    // Update is called once per frame
    void Update()
    {
        //Checks if the player has subceeded their respective amounts
        Inept();
    }
    //Starts betting
    public void StartBetting()
    {
        //Update the text for betting and the bank
        UpdateText();
        //Brings all the UI
        BringUI();
    }
    //Sets all the amounts for the game
    public void SetAmounts()
    {
        //Sets the betting a bank amount
        betting = 0;
        bank = startingAmount;

        //Sets each chip amount
        redAmount = 5;
        yellowAmount = 10;
        blueAmount = 20;
        greenAmount = 50;
        blackAmount = 100;

        //Sets each chip text as it's chip amount
        redText.text = redAmount.ToString();
        yellowText.text = yellowAmount.ToString();
        blueText.text = blueAmount.ToString();
        greenText.text = greenAmount.ToString();
        blackText.text = blackAmount.ToString();
    }
   
    //Makes the button grey and enabled = false
    public void Inept()
    {
        //Finds the image for each chip
        Image redColor = red.GetComponent<Image>();
        Image yellowColor = yellow.GetComponent<Image>();
        Image blueColor = blue.GetComponent<Image>();
        Image greenColor = green.GetComponent<Image>();
        Image blackColor = black.GetComponent<Image>();

        //Either turns them on or off depending on the bank
        if (bank < redAmount)
        {
            red.enabled = false;
            
            redColor.color = new Color32(255, 255, 255, 140);
        }
        if (bank >= redAmount)
        {
            red.enabled = true;

            redColor.color = new Color32(255, 255, 255, 255);
        }
        if (bank < yellowAmount)
        {
            yellow.enabled = false;

            yellowColor.color = new Color32(255, 255, 255, 140);
        }
        if (bank >= yellowAmount)
        {
            yellow.enabled = true;

            yellowColor.color = new Color32(255, 255, 255, 255);
        }
        if (bank < blueAmount)
        {
            blue.enabled = false;

            blueColor.color = new Color32(255, 255, 255, 140);
        }
        if (bank >= blueAmount)
        {
            blue.enabled = true;

            blueColor.color = new Color32(255, 255, 255, 255);
        }
        if (bank < greenAmount)
        {
            green.enabled = false;

            greenColor.color = new Color32(255, 255, 255, 140);
        }
        if (bank >= greenAmount)
        {
            green.enabled = true;

            greenColor.color = new Color32(255, 255, 255, 255);
        }
        if (bank < blackAmount)
        {
            black.enabled = false;
            
            blackColor.color = new Color32(255, 255, 255, 140);
        }
        if (bank >= blackAmount)
        {
            black.enabled = true;

            blackColor.color = new Color32(255, 255, 255, 255);
        }
    }
    //Knock alls the betting UI
    public void KnockUI()
    {
        //Turns off all the buttons
        buttonHolder.SetActive(false);
        //Turns off the dealer text
        dealerText.text = "";
        //Turns off the start button
        startButton.SetActive(false);
        //Turns off the leave button
        leaveButton.SetActive(false);
    }
    //Brings back all the UI
    public void BringUI()
    {
        //Show all the chips
        buttonHolder.SetActive(true);
        //Shows the start button
        startButton.SetActive(true);
        //Shows the leave button
        leaveButton.SetActive(true);
        //Turns on the dealer text and introduces
        dealerText.enabled = true;
        //If the player still has money
        if (bank > 0)
        {
            dealerText.text = "Welcome !\nMinimum is $ " + redAmount.ToString() + " to play";
        }
        //If the player doesn't have money
        else
        {
            dealerText.text = "Jeez !\nYOU'RE BROKE";
        }
    }
    //If the player bets red
    public void BetRed()
    {
        //Sees if they have enough
        if (bank >= redAmount)
        {
            //Adds and subtracts value
            betting += redAmount;
            bank -= redAmount;

            //Updates all the text
            UpdateText();
        }
    }
    //If the player bets yellow
    public void BetYellow()
    {
        //Sees if they have enough
        if (bank >= yellowAmount)
        {
            //Adds and subtracts value
            betting += yellowAmount;
            bank -= yellowAmount;

            //Updates all the text
            UpdateText();
        }
    }
    //If the player bets blue
    public void BetBlue()
    {
        //Sees if they have enough
        if (bank >= blueAmount)
        {
            //Adds and subtracts value
            betting += blueAmount;
            bank -= blueAmount;

            //Updates all the text
            UpdateText();
        }
    }
    //If the player bets green
    public void BetGreen()
    {
        //Sees if they have enough
        if (bank >= greenAmount)
        {
            //Adds and subtracts value
            betting += greenAmount;
            bank -= greenAmount;

            //Updates all the text
            UpdateText();
        }
    }
    //If the player bets black
    public void BetBlack()
    {
        //Sees if they have enough
        if (bank >= blackAmount)
        {
            //Adds and subtracts value
            betting += blackAmount;
            bank -= blackAmount;

            //Updates all the text
            UpdateText();
        }
    }
    //Update the text
    public void UpdateText()
    {
        //Changes the betting text        
        bettingText.text = "Betting: $" + betting.ToString();
        //Changes the bank text
        bankText.text = "Bank: $" + bank.ToString();
    }
    //Adds when the player wins
    public void Add()
    {
        //Adds
        betting *= 2;
        bank += betting;
        betting = 0;
        UpdateText();

        //Dealer congrats
        dealerText.text = "Congrats!\nYou won!";
    }
    //Does nothing when the player loses
    public void Lose()
    {
        //Changes betting
        betting = 0;
        UpdateText();

        //Dealer trash talks
        dealerText.text = "Next time,\nBOZO!";
    }
    //Gives money back when player draws
    public void Draw()
    {
        //Gives everyone money back
        bank += betting;
        betting = 0;
        UpdateText();

        //Dealer from 1900's
        dealerText.text = "Shucks,\nIt was a tie!";
    }
    //Used to leave the game
    public void Leave()
    {
        //Checks if the player has at least made 300 dollars to make the leaderboard
        if (bank > startingAmount + 100)
        {
            File.AppendAllText("Assets/score.txt", "," + bank);
            SceneManager.LoadScene(sceneBuildIndex: 2);
        }
        //If not goes back to the title screen
        else
        {
            SceneManager.LoadScene(sceneBuildIndex: 0);
        }
        
    }
}
