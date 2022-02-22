using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour
{
    // instance variable and initializer.
    public static DontDestroyOnLoad instance = null;

    // Start is called before the first frame update
    void Awake()
    {
        // destroy the game object if the instance already exist in scene.
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            // if the game object doesnt exist makes the game object the instance.
            instance = this;
        }
        // making sure the game object with this script will move between scenes.
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        // when the scene index number is above 3 which is the max number of levels the game object will be destroyed.
       if (SceneManager.GetActiveScene().buildIndex > 3 || SceneManager.GetActiveScene().buildIndex == 0)
       {
           Destroy(GameObject.FindWithTag("GameManager"));
       }
    }
}
