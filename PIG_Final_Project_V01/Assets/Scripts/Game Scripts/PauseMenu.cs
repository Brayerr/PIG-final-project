using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    // script reference.
    public PauseMenu pm;
    // menu variables.
    public bool pauseMenuOpen = false;

    // pause button method.
    public void Pause()
    {
        //setting menu to active, freezing game time, setting bool to true, feedback to player.
        this.gameObject.SetActive(true);
        Time.timeScale = 0f;
        pauseMenuOpen = true;
        Debug.Log("pause menu opened");
    }

    // resume button method.
    public void Resume()
    {
        //setting menu to false, unfreezing game time, setting bool to false, feedback to player.
        this.gameObject.SetActive(false);
        Time.timeScale = 1f;
        pauseMenuOpen = false;
        Debug.Log("pause menu closed");
    }

    // back to main menu button method.
    public void MainMenu()
    {
        //unfreezing game time, loading main menu scene, feedback to player.
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
        Debug.Log("back to main menu");
    }
}
