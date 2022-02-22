using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Method to load first level when play button is pressed.
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Method to close the game in case the quit button was pressed.
    public void QuitGame()
    {
        Application.Quit();
    }

    //Method to load level select scene in case the level select button was pressed.
    public void LevelSelect()
    {
        SceneManager.LoadScene("Level Select Menu");
    }


}

