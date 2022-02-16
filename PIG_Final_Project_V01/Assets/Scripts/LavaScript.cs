﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour
{    
    //player refference
    Player player;
    //initializing lava damage
    public int damage = 5;
    // Start is called before the first frame update
    void Start()
    {
        //player script reffrence
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //when colliding with lava
    void OnCollisionEnter2D(Collision2D coll)
    {
        //player takes damage from lava
        player.TakeDamage(damage);        
    }
}
