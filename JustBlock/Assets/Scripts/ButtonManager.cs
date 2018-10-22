using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class ButtonManager : MonoBehaviour {
    public bool isPlaying;
     AudioSource audioSource;
	// Use this for initialization
	void Start () {
        isPlaying = true;
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void StartGame()
    {
        SceneManager.LoadScene("CJTestScene");
    }
    public void Controls()
    {
        SceneManager.LoadScene("HowToPlay");
    }
    public void EndGame()
    {
        Application.Quit();
    }
    public void BackToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void UnPause()
    {
        gameObject.GetComponent<SceneManagement>().pauseMenu.SetActive(false);
        gameObject.GetComponent<SceneManagement>().UnFreezePlayerOne();
    }

    public void ControlsMenu()
    {
        gameObject.GetComponent<SceneManagement>().controlsMenu.SetActive(true);
        gameObject.GetComponent<SceneManagement>().pauseMenu.SetActive(false);
    }

    public void BackToPause()
    {
        gameObject.GetComponent<SceneManagement>().controlsMenu.SetActive(false);
        gameObject.GetComponent<SceneManagement>().pauseMenu.SetActive(true);
    }
    public void MusicOnOff()
    {
        
        if(isPlaying)
        {
            audioSource.Pause();
            isPlaying = false;
        }
        else
        {
            audioSource.Play();
            isPlaying = true;
        }
    }
}
