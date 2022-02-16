using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private int nextSceneToLoad;

    // Start is called before the first frame update
    void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collGameObject = collision.gameObject;

        if (collGameObject.tag == "Player")
        {
            SceneManager.LoadScene(nextSceneToLoad);
        }
    }
}
