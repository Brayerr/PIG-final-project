﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //player max health
    public int playerMaxHealth = 5;
    //player current health
    public int currentHealth;
    //checks if player is dead
    public bool playerIsDead = false;
    //checks if player can take damage
    public bool playerCanTakeDamage = true;
    //period of time that the player cant take damage
    public float damageDelay = 1.5f;
    
    // Start is called before the first frame update        
    void Start()
    {
        //setting player health to the max
        currentHealth = playerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //check if player died
        PlayerDead(currentHealth);
    }

    //function that checks player health
    public void PlayerDead(int currentHP)
    {
        //if player health hits 0
        if(currentHP <= 0)
        {
            //tells bool that player is dead
            playerIsDead = true;
            //resets player position to level start position
            transform.position = new Vector3(-7.04f, -3.27f, transform.position.z);
            //resets player health to max health
            currentHealth = playerMaxHealth;
            //feedback to console
            Debug.Log("You have died, restarting level.");
        }
    }

    //function that makes the player take damage
    public void TakeDamage(int dmg)
    {
        //checks if player can take damage(if delay is over)
        if (playerCanTakeDamage == true)
        {
            //player health - damage
            currentHealth -= dmg;
            //starts coroutine for player take damage delay
            StartCoroutine(PlayerTakeDamageDelay());
            //feedback that player got hit
            Debug.Log("hit player");        
        }
        //if player cant take damage
        else
            //feedback that player cannot take damage atm
            Debug.Log("cant take dmg");
    }

    //coroutine for player invincibility
    IEnumerator PlayerTakeDamageDelay()
    {
        //player cant take damage
        playerCanTakeDamage = false;
        //wait for damage delay
        yield return new WaitForSeconds(damageDelay);
        //player can take damage again
        playerCanTakeDamage = true;
    }
}