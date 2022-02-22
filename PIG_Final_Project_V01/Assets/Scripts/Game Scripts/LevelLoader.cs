using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // scene variable.
    private int nextSceneToLoad;

    // Start is called before the first frame update
    void Start()
    {
        // setting the scene index number according to the current scene.
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //when player collide with exit point move him to next scene in index.
        GameObject collGameObject = collision.gameObject;

        if (collGameObject.tag == "Player")
        {
            SceneManager.LoadScene(nextSceneToLoad);
        }
    }
}
