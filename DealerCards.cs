using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Name: Sner Saha
//Date: 20 January 2023
//Program Name: PlayerCards
//Project: Culminating (Blackjack)
//Purpose: Used to deal with all the dealer card stuff

public class DealerCards : MonoBehaviour
{
    //Used to store all the cards
    public List<GameObject> deck = new List<GameObject>();
    //Used to store all the cards that are currently on the field
    public List<GameObject> cardsPlayed = new List<GameObject>();
    //Used to store the random card
    public GameObject card;
    //Used to find each card value
    public Dictionary<string, int> cardDict = new Dictionary<string, int>();
    //Used to indicate the player's current value
    public int dealerValue = 0;
    //Used to store the hand
    public Transform hand;
    //Used to store the hand position
    private Vector3 handPos = new Vector3(0, 0, 0);
    //Used to store the card position
    private Vector3 cardPos = new Vector3(-1, 2.5f, 0);
    //Used to store the blank card
    public GameObject blankCard;

    //Sets the card dictionary
    public void SetCardDict()
    {
        cardDict.Add("Two", 2);
        cardDict.Add("Three", 3);
        cardDict.Add("Four", 4);
        cardDict.Add("Five", 5);
        cardDict.Add("Six", 6);
        cardDict.Add("Seven", 7);
        cardDict.Add("Eight", 8);
        cardDict.Add("Nine", 9);
        cardDict.Add("Ten", 10);
        cardDict.Add("Jack", 10);
        cardDict.Add("Queen", 10);
        cardDict.Add("King", 10);
        cardDict.Add("Ace", 11);
    }

    //Generates a card
    public void GenerateCard()
    {
        //Picks a random element in list
        int rand = Random.Range(0, deck.Count);
        //Generates the random element
        card = Instantiate(deck[rand]);
        //Sets the card as a child of "hand"
        card.transform.parent = hand.transform;
        //Changes the card to being played
        cardsPlayed.Add(card);
    }

    //Genertate a blank card
    public void GenerateBlankCard()
    {
        //Generates a blank card
        card = Instantiate(blankCard);
        //Sets the blank card as a child of "hand"
        card.transform.parent = hand.transform;
        //Changes the card to being played
        cardsPlayed.Add(card);
    }

    //Finds card value
    public void FindValue()
    {
        //Splits the card file name to be an easier search in the dictionary
        string[] cardName = card.name.Split(" ");

        //Checking if the player drew an "ACE"
        if (card.name == "Ace" && !(dealerValue + 11 <= 21))
        {
            dealerValue += 1;
        }
        else
        {
            //Searches for the value and adds to the playerValue
            dealerValue += cardDict[cardName[0]];
        }
    }

    //Moves the card to its specified position
    public void MoveCard()
    {
        //Seeing if the number of cards is odd (not counting 1 either), moves the hand
        if (cardsPlayed.Count % 2 != 0 && cardsPlayed.Count != 1)
        {
            //Moves the card to the proper position
            card.transform.position = cardPos;
            //Sets the hand pos
            handPos.x -= 1f;
            //Moves the hand to the proper position
            hand.transform.position = new Vector3(handPos.x, 0, 0);
        }
        else
        {
            //Moves the card to the proper position
            card.transform.position = cardPos;
            //Sets the next time card is moved
            cardPos.x += 1f;
        }
    }

    //Destroys the blank card
    public void DestroyBlankCard()
    {
        //Destroys the blank card
        Destroy(cardsPlayed[1]);
        //Removes it from the played cards
        cardsPlayed.Remove(cardsPlayed[1]);
        //Resets it to the proper card pos
        cardPos.x -= 1;
    }

    //Resets all of dealer's stuff
    public void ResetDealer()
    {
        //Destroying and removing all the cards from the cardsPlayed
        while (cardsPlayed.Count > 0)
        {
            //Destroys the card gameobjects
            Destroy(cardsPlayed[0]);
            //Removes it from cardsPlayed
            cardsPlayed.Remove(cardsPlayed[0]);
        }
        
        //Nulls card
        card = null;
        
        //Resets value
        dealerValue = 0;

        //Resets positions
        handPos = new Vector3(0, 0, 0);
        cardPos = new Vector3(-1, 2.5f, 0);

        //Reset hand position
        hand.transform.position = handPos;
    }
}
