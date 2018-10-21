using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagement : MonoBehaviour
{
    private bool menuActive;
    public GameObject playerOne;
    public GameObject playerTwo;
    public GameObject pauseMenu;
    public GameObject controlsMenu;
    public GameObject timer;

    private Vector2 accelerationOne;
    private Vector2 velocityOne;
    private Vector2 positionOne;
    private Vector2 raycastPosOne;
    private Vector2 raycastPosTopLeftOne;
    private Vector2 raycastPosTopRightOne;
    private int jumpsLeft;
    private int jumpFrames;
    private bool isJump;
    private bool isGrounded;
    private bool facingLeft;


    // Use this for initialization
    void Start ()
    { 
        pauseMenu.SetActive(menuActive);
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown("escape") || Input.GetKeyDown("backspace"))
        {
            menuActive = !menuActive;
            pauseMenu.SetActive(menuActive);


            if (menuActive)
            {
                FreezePlayerOne();
            }
            if (!menuActive && playerOne.GetComponent<InputManager>() == null)
            {
                UnFreezePlayerOne();
            }
        }
    }

    public void FreezePlayerOne()
    {
        accelerationOne = playerOne.GetComponent<InputManager>().acceleration;
        velocityOne = playerOne.GetComponent<InputManager>().velocity;
        positionOne = playerOne.GetComponent<InputManager>().position;
        raycastPosOne = playerOne.GetComponent<InputManager>().raycastPos;
        raycastPosTopLeftOne = playerOne.GetComponent<InputManager>().raycastPosTopLeft;
        raycastPosTopRightOne = playerOne.GetComponent<InputManager>().raycastPosTopRight;
        jumpsLeft = playerOne.GetComponent<InputManager>().jumpsLeft;
        jumpFrames = playerOne.GetComponent<InputManager>().jumpFrames;
        isJump = playerOne.GetComponent<InputManager>().isJump;
        facingLeft = playerOne.GetComponent<InputManager>().facingLeft;
        isGrounded = playerOne.GetComponent<InputManager>().isGrounded;
        timer.GetComponent<Timer>().PauseTimer();
        timer.GetComponent<Timer>().timerOn = false;
        //playerOne.GetComponent<InputManager>().enabled = false;
        Destroy(playerOne.GetComponent<InputManager>());
    }

    public void UnFreezePlayerOne()
    {
        playerOne.AddComponent<InputManager>();
        /*playerOne.GetComponent<InputManager>().up = "w";
        playerOne.GetComponent<InputManager>().down = "s";
        playerOne.GetComponent<InputManager>().left = "a";
        playerOne.GetComponent<InputManager>().right = "d";*/
        playerOne.GetComponent<InputManager>().playerOne = true;
        playerOne.GetComponent<InputManager>().maxSpeed = .12f;
        playerOne.GetComponent<InputManager>().maxAccel = .009f;
        playerOne.GetComponent<InputManager>().maxJumpSpeed = .15f;
        playerOne.GetComponent<InputManager>().maxJumpAccel = .012f;
        playerOne.GetComponent<InputManager>().gravity = 1.5f;
        playerOne.GetComponent<InputManager>().numJumps = 2;
        playerOne.GetComponent<InputManager>().velocity = velocityOne;
        playerOne.GetComponent<InputManager>().position = positionOne;
        playerOne.GetComponent<InputManager>().raycastPos = raycastPosOne;
        playerOne.GetComponent<InputManager>().raycastPosTopLeft = raycastPosTopLeftOne;
        playerOne.GetComponent<InputManager>().raycastPosTopRight = raycastPosTopLeftOne;
        playerOne.GetComponent<InputManager>().isGrounded = isGrounded;
        playerOne.GetComponent<InputManager>().isJump = isJump;
        playerOne.GetComponent<InputManager>().facingLeft = facingLeft;

        if (!playerOne.GetComponent<InputManager>().isGrounded)
        {
            playerOne.GetComponent<InputManager>().jumpFrames = jumpFrames;
            playerOne.GetComponent<InputManager>().jumpsLeft = jumpsLeft;
        }
        else
        {
            playerOne.GetComponent<InputManager>().jumpFrames = 24;
            playerOne.GetComponent<InputManager>().jumpsLeft = 2;
        }
        
        timer.GetComponent<Timer>().timerOn = true;


    }
}
