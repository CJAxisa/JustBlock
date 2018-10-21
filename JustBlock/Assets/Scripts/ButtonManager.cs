using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
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
}
