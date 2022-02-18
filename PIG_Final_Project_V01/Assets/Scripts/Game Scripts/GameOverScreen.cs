using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    //Method for Restart Button, Loads the first (playable) scene in the index.
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    //Method for Main Menu Button, Loads Main menu scene.
    public void ReturnToMainMenu()
    {        
        SceneManager.LoadScene(0);
    }

    //Method for Quit Button, Closes the application.
    public void QuitGame()
    {
        Application.Quit();
    }
}
