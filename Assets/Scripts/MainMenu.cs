using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public Text highscoreText;
    private int highscore;

	// Use this for initialization
	void Start () {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        UpdateHighscore();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayGame()
    {
        Debug.Log("Play");
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    void UpdateHighscore()
    {
        highscoreText.text = "" + highscore;
    }
}
