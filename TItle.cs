using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Name: Sner Saha
//Date: 20 January 2023
//Program Name: PlayerCards
//Project: Culminating (Blackjack)
//Purpose: Used for the title screen (hover stuff and loading different scenes)

public class TItle : MonoBehaviour
{
    //Used to hold the hover image
    public Image hoverImage;
    //Used to hold the player's mouse current position
    private Vector3 playerPos;
    //Used to hold a raycast;
    private RaycastHit2D hit;

    // Update is called once per frame
    void Update()
    {
        CheckHover();
    }

    //This void checks if the player is hovering over anything; if so then takes that objects postion
    public void CheckHover()
    {
        hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        //It will then take that gameobjects image and put it as a selected item
        if (hit.collider != null)
        {
            playerPos = hit.collider.transform.position;
            ButtonHover();
        }
        //Will make the image disappear
        else
        {
            ButtonExit();
        }
    }
    //What happens if the player hovers over an object
    public void ButtonHover()
    {
        hoverImage.transform.position = new Vector2(playerPos.x - 2.5f, playerPos.y + .15f);
        hoverImage.enabled = true;
    }

    //What happens if the player exits over an object
    public void ButtonExit()
    {
        hoverImage.enabled = false;
    }
    //If the player presses "PLAY"
    public void Play()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
    //If the player presses "DISPLAY"
    public void Display()
    {
        SceneManager.LoadScene(sceneBuildIndex: 3);
    }
    //If the player presses "QUIT"
    public void Quit()
    {
        Application.Quit();
    }
}
