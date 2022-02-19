using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelSelectMenu : MonoBehaviour
{
    public void LoadLevelTutorial()
    {
        SceneManager.LoadScene("Tutorial Level");
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("level1");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Amit's workshop");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
