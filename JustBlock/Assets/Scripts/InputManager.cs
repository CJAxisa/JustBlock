using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
    public bool playerOne;
    public float maxSpeed;
    public float maxAccel;
    public float maxJumpSpeed;
    public float maxJumpAccel;

    public float gravity;

    public Vector2 acceleration;
    public Vector2 velocity;
    public Vector2 position;
    public Vector2 raycastPos;
    public Vector2 raycastPosTopLeft;
    public Vector2 raycastPosTopRight;
    public Vector2 raycastPosTopMid;
    public int numJumps;
    public int jumpsLeft;
    public int jumpFrames;
    public int jumpFramesLeft;

    public bool facingLeft;
    public bool isJump;
    public bool isGrounded;
    //control key strings
    private string up;
    private string left;
    private string right;
    private string down;

    // Use this for initialization
    void Start () {

        //setting up controls for each player on keyboard
		if(playerOne)
        {
            up = "w";
            left = "a";
            right = "d";
            down = "s";
            facingLeft = false;

        }
        else
        {
            up = "up";
            left = "left";
            right = "right";
            down = "down";
            facingLeft = true;
        }
        //bools
        isJump = false;

        position = transform.position;

        

    }

    // Update is called once per frame
    void Update ()
    {
       



        if (isGrounded)
        {
            jumpFramesLeft = jumpFrames;
            jumpsLeft = numJumps;
        }
        //Getting basic movement input
        if (Input.GetKey(left))
        {
            acceleration.x -= 1;
            facingLeft = true;
        }
        if (Input.GetKey(right))
        {
            acceleration.x += 1;
            facingLeft = false;
        }


        if (Input.GetKeyDown(up))
        {            
            if(isGrounded)
            {
                isGrounded = false;
                position.y += 0.01f;
                isJump = true;
                jumpsLeft--;
            }
            else if (jumpsLeft > 0)
            {
                jumpsLeft--;
                //JUMP HERE
                velocity.y *=0f;
                velocity.x *= 0.3f;
                isJump = true;
                jumpFramesLeft = jumpFrames;
            }
        }


        if (isJump)
        {
            if(jumpFramesLeft<=0||!Input.GetKey(up))
                isJump = false;
            jumpFramesLeft--;
            acceleration.y += 2f;
        }

        if (Input.GetKey(down))
        {
            acceleration.y -= 15f;
            isJump = false;
        }

        if (!Input.anyKey)
        {
            acceleration.x *= 0f;
        }

        

        CalcMovement();
    }

    void CalcMovement()
    {

        //floor raycast
        if (facingLeft)
        {
            raycastPos = new Vector2(position.x + gameObject.GetComponent<BoxCollider2D>().size.x * 0.5f, position.y - gameObject.GetComponent<BoxCollider2D>().size.y * 0.5f);
            Debug.DrawRay(raycastPos, Vector2.left, Color.green, 2f);
            if (Physics2D.Raycast(raycastPos, Vector2.left, gameObject.GetComponent<BoxCollider2D>().size.x*0.9f))
            {
                if (!isJump)
                    isGrounded = true;
            }
            else
            {
                if (!isJump)
                    isGrounded = false;
            }
        }
        else
        {
            raycastPos = new Vector2(position.x - gameObject.GetComponent<BoxCollider2D>().size.x * 0.5f, position.y - gameObject.GetComponent<BoxCollider2D>().size.y * 0.5f);
            Debug.DrawRay(raycastPos, Vector2.right, Color.green, 2f);
            if (Physics2D.Raycast(raycastPos, Vector2.right, gameObject.GetComponent<BoxCollider2D>().size.x*0.9f))
            {
                if (!isJump)
                    isGrounded = true;
            }
            else
            {
                if (!isJump)
                    isGrounded = false;
            }
        }

        

        if (!isGrounded)
            acceleration.y -= gravity;
        if (!isJump&&acceleration.magnitude >= maxAccel)
        {
            acceleration.Normalize();
            acceleration*= maxAccel;
        }
        if(isJump&&acceleration.magnitude >=maxJumpAccel)
        {
            acceleration.Normalize();
            acceleration *= maxJumpAccel;
        }

        if(acceleration.magnitude==0)
        {
            if (velocity.magnitude != 0)
            {
                Debug.Log("no accel");

                if (Mathf.Abs(velocity.magnitude) < 0.01f)
                    velocity *= 0f;
                velocity *= 0.9f;
            }
        }
        velocity += acceleration;
        if (isGrounded && Mathf.Abs(velocity.y) > 0f)
            velocity.y *= 0f;
        if (!isJump&&velocity.magnitude >= maxSpeed)
        {
            velocity.Normalize();
            velocity *= maxSpeed;
        }
        if (isJump && velocity.magnitude >= maxJumpSpeed)
        {
            velocity.Normalize();
            velocity *= maxJumpSpeed;
        }

        raycastPosTopLeft = new Vector2(position.x - gameObject.GetComponent<BoxCollider2D>().size.x * 0.5f, position.y + gameObject.GetComponent<BoxCollider2D>().size.y * 0.5f);
        raycastPosTopRight = new Vector2(position.x + gameObject.GetComponent<BoxCollider2D>().size.x * 0.5f, position.y + gameObject.GetComponent<BoxCollider2D>().size.y * 0.5f);
        raycastPosTopMid = new Vector2(position.x, position.y + gameObject.GetComponent<BoxCollider2D>().size.y * 0.5f);

        if (facingLeft)
        {
            if (Physics2D.Raycast(raycastPosTopLeft, Vector2.down, gameObject.GetComponent<BoxCollider2D>().size.y * 0.9f) && velocity.x < 0f)
                velocity.x *= 0f;
            else if (Physics2D.Raycast(raycastPosTopMid, Vector2.down, gameObject.GetComponent<BoxCollider2D>().size.y * 0.9f) && velocity.x > 0f)
                velocity.x *= 0f;
        }
        else
        {
            if (Physics2D.Raycast(raycastPosTopMid, Vector2.down, gameObject.GetComponent<BoxCollider2D>().size.y * 0.9f) && velocity.x > 0f)
                velocity.x *= 0f;
            else if (Physics2D.Raycast(raycastPosTopRight, Vector2.down, gameObject.GetComponent<BoxCollider2D>().size.y * 0.9f) && velocity.x < 0f)
                velocity.x *= 0f;
        }

        position += velocity;
        transform.position = position;

    }

}
