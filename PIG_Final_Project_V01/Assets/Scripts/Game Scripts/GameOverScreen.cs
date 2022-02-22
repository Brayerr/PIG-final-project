using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameOverScreen : MonoBehaviour
{
    // score text reference.
    public TextMeshProUGUI scoreDisplay;

    // script reference.
    PlayerScore playerScore;

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

    private void Start()
    {
        //refrencing to the script to have access to player score. 
        playerScore = FindObjectOfType<PlayerScore>();
    }

    private void Update()
    {
        //setting the text to the player final score.
        scoreDisplay.text = ("You scored: " + playerScore.score);
    }
}
