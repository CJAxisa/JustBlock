using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour {

    private InputManager IM;
    private GameObject projectile;
	// Use this for initialization
	void Start () {
        IM =gameObject.GetComponent<InputManager>();
	}
	
	// Update is called once per frame
	void Update () {
        projectile = GameObject.FindGameObjectWithTag("Fireball");
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Fireball")
        {
            Fireball.setHit(true);
        }
    }
}
