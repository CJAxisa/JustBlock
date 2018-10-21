using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour {

    private InputManager IM;
	// Use this for initialization
	void Start () {
        if(gameObject.GetComponent<InputManager>()!= null)
        {
            IM = gameObject.GetComponent<InputManager>();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
