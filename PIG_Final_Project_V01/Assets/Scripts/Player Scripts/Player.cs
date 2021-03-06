using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //rigidbody refference
    Rigidbody2D rb2d;
    //checkpoint variable
    public Vector3 checkPoint;
    //movement script refference
    PlayerMovment playerMovment;
    //danny refference
    Transform danny;
    //blood reference
    public ParticleSystem bloodEffect;
    //Animator Reference
    Animator animator;

    //player max health
    public float playerMaxHealth = 5;
    //player current health
    public float currentHealth;
    //player max lives
    public float playerMaxLives = 3;
    //player current lives
    public float currentLives;
    //checks if player is dead
    public bool playerIsDead = false;
    //checks if player can take damage
    public bool playerCanTakeDamage = true;
    //period of time that the player cant take damage
    public float damageDelay = 1.5f;
    //period of time before player will respawn.
    public float deathAnimDelay = 1.2f;

    //vertical knockback force
    public int verticalKnockBackForce = 2;
    //horizontal knockback force
    public int horizontalKnockBackForce = 2;
    
    // Start is called before the first frame update        
    void Start()
    {
        //setting player health to the max
        currentHealth = playerMaxHealth;
        //setting player Lives to the max
        currentLives = playerMaxLives;
        //setting up checkpoint values as level start values
        checkPoint = new Vector3(-7.04f, -3.27f, transform.position.z);
        //rigidbody refference
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        //movement script refference
        playerMovment = gameObject.GetComponent<PlayerMovment>();
        //danny refference
        danny = gameObject.GetComponent<Transform>();
        //animator reference
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //check if player died
        PlayerDead(currentHealth);
    }

    private void OnLevelWasLoaded(int level)
    {
        // at the start of the game the player will be spawned at the pre determind start position.
       FindStartPos();
    }
    
    public void FindStartPos()
    {
        // will move the player to the position of the object with the tag StartPos.
        transform.position = GameObject.FindWithTag("StartPos").transform.position;
    }

    //function that checks player health
    public void PlayerDead(float currentHP)
    {
        // as long as the player has more then 0 lives his health can be reduced.
        if (currentLives > 0)
        {
            //if player health hits 0
            if (currentHP <= 0)
            {
                //tells bool that player is dead
                playerIsDead = true;
                StartCoroutine(DeathDelay());
                //resets player health to max health
                currentHealth = playerMaxHealth;
                //feedback to console
                Debug.Log("You have died, restarting level.");
            }
        }
        else
        {
            // the player has 0 lives so he will be moved to the game over scene.
            SceneManager.LoadScene("GameOver");
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
            //feedback that player got hit
            Debug.Log("hit player");
            //instantiating particle effect for damage taking
            Instantiate(bloodEffect, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), transform.rotation, danny);
            //starts coroutine for player take damage delay from spikes
            StartCoroutine(PlayerTakeDamageDelay());
        }
        //if player cant take damage
        else
            //feedback that player cannot take damage atm
            Debug.Log("cant take dmg");
    }

    //coroutine for player invincibility
    public IEnumerator PlayerTakeDamageDelay()
    {
        //player cant take damage
        playerCanTakeDamage = false;
        //wait for damage delay
        yield return new WaitForSeconds(damageDelay);
        //player can take damage again
        playerCanTakeDamage = true;
    }

    public void HandleKnockBack()
    {
        if (playerCanTakeDamage == true)
        { 
            //knockback up
            rb2d.AddForce(Vector2.up * verticalKnockBackForce);
            Debug.Log("KB UP");

            //if player walks right when being hit
            if(playerMovment.horizontalMove > 0)
            {
                //, he gets knockbacked to the left
                rb2d.AddForce(Vector2.left * horizontalKnockBackForce);
                Debug.Log("KB LEFT");
            }

            //if player walks left when being hit
            else if (playerMovment.horizontalMove < 0)
            {
                //, he gets knockbacked to the right
                rb2d.AddForce(Vector2.right * horizontalKnockBackForce);
                Debug.Log("KB RIGHT");
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Spike") || coll.gameObject.CompareTag("Projectile"))
        {
            GameObject test = coll.gameObject;
            SpikesScript spikeScript = test.GetComponent<SpikesScript>();
            //player gets knocked back from spike
            HandleKnockBack();
            //Player takes damage from spikes
            TakeDamage(spikeScript.Damage);
        }

        if (coll.gameObject.CompareTag("Lava") && playerCanTakeDamage)
        {
            //player takes damage from lava
            currentHealth = 0;
            StartCoroutine(PlayerTakeDamageDelay());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if checkpoint collides with player and player checkpoint isnt equal to this checkpoint
        if (collision.gameObject.CompareTag("CheckPoint") == true && checkPoint != this.transform.position)
        {
            //make players checkpoint this checkpoint
            checkPoint = this.transform.position;
            //send message to player
            Debug.Log("checkpoint saved");
        }
    }

    public IEnumerator DeathDelay()
    {
        Debug.Log("isDead");
        //player death animation
        animator.SetBool("isDead", true);
        GetComponent<PlayerMovment>().enabled = false;
        yield return new WaitForSeconds(deathAnimDelay);
        GetComponent<PlayerMovment>().enabled = true;
        //Stop death
        animator.SetBool("isDead", false);
        //player died so removing 1 life
        currentLives--;
        //resets player position to level start position
        transform.position = checkPoint;
    }
}
