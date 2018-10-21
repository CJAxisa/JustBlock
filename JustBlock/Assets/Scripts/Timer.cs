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
    public bool timerOn;

	// Use this for initialization
	void Start ()
    {
        timerText = gameObject.GetComponent<Text>().text;
        timer = 99f;
        timerOn = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        switch (timerOn)
        {
            case true:
                ContinueTimer();
                break;
            case false:
                PauseTimer();
                break;
            default:
                break;
        }
    }

    public void PauseTimer()
    {
        timer += 0;
        timerText = timer.ToString("0");
        gameObject.GetComponent<Text>().text = timerText;
    }

    public void ContinueTimer()
    {
        timer -= Time.deltaTime;
        timerText = timer.ToString("0");
        gameObject.GetComponent<Text>().text = timerText;
    }
}
