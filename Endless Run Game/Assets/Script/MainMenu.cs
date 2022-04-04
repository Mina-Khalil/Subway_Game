using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
     private int count = 0;
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
        Name.NamePlayer = Name.NamePlayer;
        AudioManger.ismute = AudioManger.ismute;
    }
    public void Back()
    {
        SceneManager.LoadScene("Main Menu");
        AudioManger.ismute = AudioManger.ismute;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void pauseGame()
    {

        if (count == 0)
        {
            Time.timeScale = 0;
            count = 1;
        }
        else
        {
            Time.timeScale = 1;
            count = 0;
        }
    }


}
