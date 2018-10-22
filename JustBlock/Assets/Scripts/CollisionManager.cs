using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour {
    public bool playerOne;
    private InputManager IM;
    private GameObject projectile;

    public int health;

    // Use this for initialization
    void Start ()
    {
        if (gameObject.GetComponent<InputManager>()!= null)
        {
            IM = gameObject.GetComponent<InputManager>();
        }

        health = 5;

    }

    // Update is called once per frame
    void Update () {
        if (health <= 0)
        {
            Die();
        }
	}

    public void Die()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Fireball")
        {
            if (IM.isBlocking)
            {
                if (IM.facingLeft)
                {
                    if (transform.position.x>collision.transform.position.x)
                    {
                        //BLOCKED
                        //Fireball.h
                    }
                    else
                    {
                        //die
                        Debug.Log("die or be die");
                    }

                }
                else
                {
                    if (transform.position.x < collision.transform.position.x)
                    {
                        //BLOCKED
                        Debug.Log("die or be die");
                    }
                    else
                    {
                        //die
                        Debug.Log("die or be die");
                    }
                }
            }
            else
            {
                //die
                Debug.Log("die or be die");
            }
            Fireball.setHit(true);
        }
    }
}
