using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {
    public static bool fromPlayerOne;
    public static bool hit;
    public static bool blocked;
    public static float timeLimit;
    public float timeLeft;

    public  Vector2 acceleration;
    public  Vector2 velocity;
    public  Vector2 position;

    // Use this for initialization
    void Start () {
        hit = false;
        position = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //check if
        

            CalcMovements();
	}

    public void CalcMovements()
    {
        velocity += acceleration;
        position += velocity;

        transform.position = position;
    }

    public static void setHit(bool val)
    {
        hit = val;
    }

    public static bool getHit()
    {
        return hit;
    }

    
    public void getBlocked()
    {

    }
    public static void Destroy()
    {
        
        
        
        //destroy

    }

    public void bounceX()
    {
        velocity.x *= -1;
    }

    public void bounceY()
    {
        velocity.y *= -1;
    }

    public void bounceBoth()
    {
        velocity.x *= -1;
        velocity.y *= -1;
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("HIT");

        if (collision.gameObject.tag == "Wall")
        {
            ContactPoint2D[] contacts = new ContactPoint2D[5];
            collision.GetContacts(contacts);
            Vector2 colPoint = contacts[0].point;
            Debug.Log(contacts[0].point);
            Vector2 difference = position - colPoint;
            if (Mathf.Abs(difference.x) >= Mathf.Abs(difference.y))
                bounceX();
            else
                bounceY();  

        }

        if(collision.gameObject.tag == "Player")
        {
            //
        }
    }

    public static Fireball getFireball()
    {
        return GameObject.FindGameObjectWithTag("Fireball").GetComponent<Fireball>();
    }
}
