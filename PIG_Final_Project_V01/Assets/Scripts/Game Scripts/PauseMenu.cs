using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public PauseMenu pm;

    public bool pauseMenuOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        this.gameObject.SetActive(true);
        Time.timeScale = 0f;
        pauseMenuOpen = true;
        Debug.Log("pause menu opened");

    }

    public void Resume()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1f;
        pauseMenuOpen = false;
        Debug.Log("pause menu closed");
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
        Debug.Log("back to main menu");
    }
}
