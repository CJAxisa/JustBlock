using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public string timerText;
    public float timer;
    public GameObject playerOne;
    public GameObject playerTwo;

	// Use this for initialization
	void Start ()
    {
        timerText = gameObject.GetComponent<Text>().text;
        timer = 99f;
        Debug.Log(timer);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(!playerOne.activeSelf && !playerTwo.activeSelf)
        {
            timer -= Time.deltaTime;
            timerText = timer.ToString("0");
            gameObject.GetComponent<Text>().text = timerText;
        }
	}
}
