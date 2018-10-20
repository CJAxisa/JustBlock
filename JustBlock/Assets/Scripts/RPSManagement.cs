using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class RPSManagement : MonoBehaviour,IPointerDownHandler, ISelectHandler
{
    //Variables for choice
    public bool player1Win;
    public bool player2Win;
    public string player1Choice;
    public string player2Choice;

    //UI that represents the choices
    public Selectable Rock1;
    public Selectable Rock2;
    public Selectable Paper1;
    public Selectable Paper2;
    public Selectable Scissors1;
    public Selectable Scissors2;

    //Variables for the Game Start
    public bool gameStart;
    public bool rpsStart;
    public GameObject ball;


    //Variable to send for reset
    public bool reset;


    //Vector3s for player positions
    public Vector3 player1Pos;
    public Vector3 player2Pos;

    // Use this for initialization
    void Start ()
    {
        player1Choice = "";
        player2Choice = "";
        gameStart = false;
        rpsStart = false;
        reset = false;
        player1Pos = GameObject.FindGameObjectWithTag("Player1").transform.position;
        player2Pos = GameObject.FindGameObjectWithTag("Player2").transform.position;
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        GetSelectables();
        if (rpsStart)
        {
            SelectChoice(player1Choice, player2Choice);
        }
        
        
	}
    
    void SelectChoice(string p1, string p2)
    {
        if(p1==p2)
        {
            Draw();
        }
        else if(p1=="Paper"&&p2=="Rock")
        {
            player1Win = true;
            Win();
        }
        else if (p1=="Rock"&&p2=="Paper")
        {
            player2Win = true;
            Win();
        }
        else if (p1 == "Scissors" && p2 == "Rock")
        {
            player2Win = true;
            Win();
        }
        else if (p1 == "Rock" && p2 == "Scissors")
        {
            player1Win = true;
            Win();
        }
        else if (p1 == "Paper" && p2 == "Scissors")
        {
            player2Win = true;
            Win();
        }
        else if (p1 == "Scissors" && p2 == "Paper")
        {
            player1Win = true;
            Win();
        }

    }
    void Win()
    {
        if(player1Win)
        {
            player1Pos.x += 0.25f;
            ball.transform.position = player1Pos;
            gameStart = true;
            
        }
        else
        {
            player2Pos.x += 0.25f;
            ball.transform.position = player2Pos;
            gameStart = true;
        }
        
    }
    void Draw()
    {
        reset = true;
    }
    public void GetSelectables()
    {
        foreach(Selectable choices in Selectable.allSelectables)
        {
            if(choices.enabled==true)
            {
                rpsStart = true;
            }
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Oogaboog");
        if(eventData.pointerPress==Rock1)
        {
            player1Choice = "Rock"; 
            Debug.Log(player1Choice);
        }
        if (eventData.pointerPress == Rock2)
        {
            player2Choice = "Rock";
        }
        if (eventData.pointerPress == Paper1)
        {
            player1Choice = "Paper";
        }
        if (eventData.pointerPress == Paper2)
        {
            player2Choice = "Paper";
        }
        if (eventData.pointerPress == Scissors1)
        {
            player1Choice = "Scissors";
        }
        if (eventData.pointerPress == Scissors2)
        {
            player2Choice = "Scissors";
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        if (eventData.selectedObject == Rock1)
        {
            
            player1Choice = "Rock";
        }
        if (eventData.selectedObject == Rock2)
        {
            player2Choice = "Rock";
        }
        if (eventData.selectedObject == Paper1)
        {
            player1Choice = "Paper";
        }
        if (eventData.selectedObject == Paper2)
        {
            player2Choice = "Paper";
        }
        if (eventData.selectedObject == Scissors1)
        {
            player1Choice = "Scissors";
        }
        if (eventData.selectedObject == Scissors2)
        {
            player2Choice = "Scissors";
        }
    }
}
