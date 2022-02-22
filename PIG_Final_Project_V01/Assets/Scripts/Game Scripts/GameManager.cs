using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    // script reference.
    public PauseMenu pm;

    // Update is called once per frame
    void Update()
    {
        // if player press esc key launch pause menu.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pm.Pause();
        }

        // if player press f1 key closes pause menu.
        if (Input.GetKeyDown(KeyCode.F1))
        { 
            pm.Resume();
        }
    }
}
