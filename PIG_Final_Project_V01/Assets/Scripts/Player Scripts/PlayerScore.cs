using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerScore : MonoBehaviour
{
    //score variables.
    public int score = 0;
    //score text reference.
    public TextMeshProUGUI _score;

    // Start is called before the first frame update
    void Start()
    {
        //setting score to 0 and setting score text to 0.
        score = 0;
        _score.text = "Score: " + score;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //method to add score to player when colliding with coins and update the UI.
        Collectable collectable = other.GetComponent<Collectable>();
        if (collectable)
        {
            score += collectable.value;
            _score.text = "Score: " + score;

            Debug.Log("Score Is " + score);
            other.gameObject.SetActive(false);
        }
    }
}
