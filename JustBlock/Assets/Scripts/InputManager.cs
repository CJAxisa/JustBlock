using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
    public bool playerOne;
    public float maxSpeed;
    public float maxAccel;

    public Vector2 acceleration;
    public Vector2 velocity;
    public Vector2 position;

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
        }
        else
        {
            up = "up";
            left = "left";
            right = "right";
            down = "down";
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (playerOne)
        {
            up = "w";
            left = "a";
            right = "d";
            down = "s";
        }
        else
        {
            up = "up";
            left = "left";
            right = "right";
            down = "down";
        }
        //Getting basic movement input
        if (Input.GetKey(left))
            acceleration.x -= 1;
		if(Input.GetKey(right))
            acceleration.x += 1;
        if (Input.GetKey(down))
            acceleration.y -= 1;
        if (!Input.anyKey)
        {
            acceleration *= 0f;
        }

        CalcMovement();
    }

    void CalcMovement()
    {
        
        if (acceleration.magnitude >= maxAccel)
        {
            acceleration.Normalize();
            acceleration*= maxAccel;
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
        if (velocity.magnitude >= maxSpeed)
        {
            velocity.Normalize();
            velocity *= maxSpeed;
        }

        position += velocity;
        transform.position = position;

    }
}
