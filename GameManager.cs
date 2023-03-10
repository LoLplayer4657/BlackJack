using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Name: Sner Saha
//Date: 20 January 2023
//Program Name: PlayerCards
//Project: Culminating (Blackjack)
//Purpose: Used to deal with all the game conditions and all the starting and reseting of the game

public class GameManager : MonoBehaviour
{
    //Used to pull all other scripts for reference
    public PlayerCards playerCards;
    public DealerCards dealerCards;
    public Betting betting;
    //Used to store the gamescreen
    public GameObject gameScreen;
    //Used to set the max value
    public int maxValue = 21;
    //Used to store the player score
    public TextMeshProUGUI playerScore;
    //Used to store the dealer score
    public TextMeshProUGUI dealerScore;
    public bool underReview = false;
    
    //Start is called at the beggining of the script
    private void Start()
    {
        //Sets the card dicts
        playerCards.SetCardDict();
        dealerCards.SetCardDict();
    }


    // Update is called once per frame
    void Update()
    {
        //Sees if the player has won from hiting
        HitWin();
    }
    
    //Ends the betting round
    public void EndBetting()
    {
        //Sees if the player has reached or went over the minimum (minimum = redAmount)
        if (betting.betting >= betting.redAmount)
        {
            //Turns on the gamescreen
            gameScreen.SetActive(true);
            //Knocks all the betting UI
            betting.KnockUI();
            //Starts the game
            StartRound();
        }
    }
   
    //Start the round
    public void StartRound()
    {
        //Sets the minimum amount of cards
        int minCards = 2;
        
        //Generates the starting player cards
        while (playerCards.cardsPlayed.Count != minCards)
        {
            Hit();
        }

        //Generates one card
        DealerHit();

        //Generates one blank card
        dealerCards.GenerateBlankCard();

        //Moves the blank card to it's assigned spot
        dealerCards.MoveCard();
    }

    //When the player hits the "HIT" button
    public void Hit()
    {
        //Sees if the player score is less than 21
        if (playerCards.playerValue < maxValue && underReview == false)
        {
            //Generates a card
            playerCards.GenerateCard();

            //Finds it's score and updates it
            playerCards.FindValue();
            playerScore.text = playerCards.playerValue + "/" + maxValue;

            //Move the card to it's assigned spot
            playerCards.MoveCard();
        }
    }

    //Dealer's version of "HIT"
    public void DealerHit()
    {
        //Generates a dealer card
        dealerCards.GenerateCard();
        
        //Finds it's score and updates it
        dealerCards.FindValue();
        dealerScore.text = dealerCards.dealerValue + "/" + maxValue;

        //Move the card to it's assigned spot
        dealerCards.MoveCard();
    }

    //When the player hits the "STAND" button
    public void Stand()
    {
        //Makes sure the player can't press STAND again
        if (underReview == false && !(playerCards.playerValue >= maxValue))
        {
            //Destroys the blank card from the begining
            dealerCards.DestroyBlankCard();
            
            //Making sure the dealer doesn't go over 21
            while (dealerCards.dealerValue <= playerCards.playerValue)
            {
                //Generates a card and stuff
                DealerHit();
            }
            
            //Sees who won after the dealer drawed? drew? his cards
            StandWin();

            //The round is under review.
            underReview = true;
        }
    }

    //Checks if the player won from hitting; Hit Conditions
    public void HitWin()
    {
        //If playerscore is greater than 21
        if (playerCards.playerValue > maxValue)
        {
            Conditions("loss");
        }
        //If playerscore is equal to 21
        else if (playerCards.playerValue == maxValue)
        {
            Conditions("win");
        }
    }

    //Checks Stand Conditions
    public void StandWin()
    {
        if (dealerCards.dealerValue > playerCards.playerValue && !(dealerCards.dealerValue >= maxValue))
        {
            Conditions("loss");
        }
        else if (dealerCards.dealerValue < playerCards.playerValue)
        {
            Conditions("win");
        }
        else if (dealerCards.dealerValue > maxValue)
        {
            Conditions("win");
        }
        else if (dealerCards.dealerValue == maxValue)
        {
            Conditions("loss");
        }
        else if (dealerCards.dealerValue == playerCards.playerValue)
        {
            Conditions("draw");
        }
    }
    
    //Checks if the player won, lost, or drawed
    public void Conditions(string condition)
    {
        //If the player won
        if (condition == "win")
        {
            betting.Add();
        }
        //If the player lost
        else if (condition == "loss")
        {
            betting.Lose();
        }
        //If the player drawed
        else if (condition == "draw")
        {
            betting.Draw();
        }

        //Invokes (calls to 3 (in-game) seconds later.)
        Invoke("ResetGame", 2.5f);
    }

    //Resets the game and goes back to betting
    public void ResetGame()
    {
        //Resets the player's and dealer's cards, score, and hand positions
        playerCards.ResetPlayer();
        dealerCards.ResetDealer();

        //Updates the player and dealer score texts
        playerScore.text = playerCards.playerValue + "/" + maxValue;
        dealerScore.text = dealerCards.dealerValue + "/" + maxValue;

        //Turns off the gamescreen
        gameScreen.SetActive(false);
        
        //Starts betting
        betting.StartBetting();

        //Review is done (if it was called); no more review
        underReview = false;
    }
}
