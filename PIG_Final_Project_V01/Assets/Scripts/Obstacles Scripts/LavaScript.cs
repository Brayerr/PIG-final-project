﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour
{    
    //Player refference
    Player player;

    //Initializing lava damage
    public int damage = 5;

    // Start is called before the first frame update
    void Start()
    {
        //player script reffrence
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();      
    }

    //When colliding with lava
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.CompareTag("Player") && player.playerCanTakeDamage)
        {
            //player takes damage from lava
            player.currentHealth = 0;
            StartCoroutine(player.PlayerTakeDamageDelay());
        }
    }
}
