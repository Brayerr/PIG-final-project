using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelSelectMenu : MonoBehaviour
{
    // load tutorial button method.
    public void LoadLevelTutorial()
    {
        SceneManager.LoadScene("Tutorial Level");
    }

    // load level 1 button method.
    public void LoadLevel1()
    {
        SceneManager.LoadScene("level1");
    }

    // load level 2 button method.
    public void LoadLevel2()
    {
        SceneManager.LoadScene("Amit's workshop");
    }

    // load main menu button method.
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
