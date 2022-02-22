using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    //Player refference
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        //player script reffrence
        player = GameObject.FindObjectOfType<Player>();
    }

    //Trigger function
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if shredder collides with player
        if (collision.gameObject.CompareTag("Player"))
        {
            //move player to start of level
            player.transform.position = new Vector3(-7.04f, -3.27f, transform.position.z);
            //message to player
            Debug.Log("mate stay in the map please.");
        }
    }
}
