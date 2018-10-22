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
    public int blockFrames;
    public int blockFramesLeft;
    public int blockLagFrames;
    public int blockLagLeft;

    public bool facingLeft;
    public bool isJump;
    public bool isGrounded;
    public bool isBlocking;

    //control key strings
    public string up;
    public string left;
    public string right;
    public string down;
    public string block;
    public string esc;

    public int health;

    // Use this for initialization
    void Start () {

        //setting up controls for each player on keyboard
		if(playerOne)
        {
            up = "w";
            left = "a";
            right = "d";
            down = "s";
            block = "space";
            esc = "escape";
            facingLeft = false;

        }
        else
        {
            up = "up";
            left = "left";
            right = "right";
            down = "down";
            block = "/";
            esc = "backspace";
            facingLeft = true;
        }
        //bools
        isJump = false;
        position = transform.position;
        health = 5;
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

        if(Input.GetKeyDown(block)&&!isBlocking&&blockLagLeft<=0)
        {
            isBlocking = true;
            blockFramesLeft = blockFrames;
        }

        if (blockLagLeft > 0)
            blockLagLeft--;

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
            acceleration.y += 3f;
        }

        if (Input.GetKey(down))
        {
            if(!isGrounded)
                acceleration.y -= 15f;
            else
            {
               velocity.x *= 0.1f;
                acceleration.x *= 0f;
            }
            isJump = false;
        }

        if (!Input.anyKey)
        {
            acceleration.x *= 0f;
            velocity.x *= 0.7f;
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

        Debug.DrawLine(raycastPosTopLeft, new Vector2(raycastPosTopLeft.x,raycastPosTopLeft.y - gameObject.GetComponent<BoxCollider2D>().size.y ), Color.red);
        Debug.DrawLine(raycastPosTopMid, new Vector2(raycastPosTopMid.x,raycastPosTopMid.y - gameObject.GetComponent<BoxCollider2D>().size.y*0.3f), Color.red);
        Debug.DrawLine(raycastPosTopRight, new Vector2(raycastPosTopRight.x,raycastPosTopRight.y - gameObject.GetComponent<BoxCollider2D>().size.y*0.3f), Color.red);

        if (facingLeft)
        {
            if (Physics2D.Raycast(raycastPosTopLeft, Vector2.down, gameObject.GetComponent<BoxCollider2D>().size.y * 0.7f))
            {
                velocity.x *= 0f;
                position.x += 0.01f;
            }
            else if (Physics2D.Raycast(raycastPosTopRight, Vector2.down, gameObject.GetComponent<BoxCollider2D>().size.y * 0.7f))
            {
                velocity.x *= 0f;
                position.x -= 0.01f;
            }
        }
        else
        {
            if (Physics2D.Raycast(raycastPosTopRight, Vector2.down, gameObject.GetComponent<BoxCollider2D>().size.y * 0.7f))
            {
                velocity.x *= 0f;
                position.x -= 0.01f;
            }
            else if (Physics2D.Raycast(raycastPosTopLeft, Vector2.down, gameObject.GetComponent<BoxCollider2D>().size.y * 0.7f) )
            {
                velocity.x *= 0f;
                position.x += 0.01f;
            }
        }

        if (isBlocking)
        {
            if (blockFramesLeft <= 0)
            {
                isBlocking = false;
                blockLagLeft = blockLagFrames;
            }
            blockFramesLeft--;
            velocity.x *= 0f;
            velocity.y *= 0f;
        }
        position += velocity;
        transform.position = position;

    }

}
