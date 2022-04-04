using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerManager : MonoBehaviour {

    public static bool gameOver;
    public GameObject gameOverPlane;
    public static bool IsGameStart;
    public GameObject startingText;
    public static int NumberOfCoins;
    public Text Coinstext;
    public Text scoreText;
    public Text Savename;
    public Text SaveScore;


    void Start () {

        gameOver = false;
        IsGameStart = false;
        NumberOfCoins = 0;

    }
	
	void Update () {
        Coinstext.text = "Coins : " + NumberOfCoins;
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPlane.SetActive(true);
            scoreText.text = Name.NamePlayer +" Is Score = " + NumberOfCoins ;
        }
        // start the game:
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IsGameStart = true;
            Destroy(startingText);
            if (AudioManger.ismute == false)
            {
                FindObjectOfType<AudioManger>().PlaySound("Button");
            }
        }

        // save you highScore
        if (NumberOfCoins > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", NumberOfCoins);
            PlayerPrefs.SetString("Name", Name.NamePlayer);
        }
    }
 
    public void clickHighScore()
    {
        Savename.text = PlayerPrefs.GetString("Name");
        SaveScore.text = PlayerPrefs.GetInt("HighScore").ToString();
  
    }
}
