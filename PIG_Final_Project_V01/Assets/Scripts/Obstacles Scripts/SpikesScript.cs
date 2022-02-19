using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesScript : MonoBehaviour
{    
    //Player script reffrence
    Player player;


    //Setting spike damage
    public int Damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        //Player script reffrence
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();        

    }

    //When colliding with spike
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            //player gets knocked back from spike
            player.HandleKnockBack();
            //Player takes damage from spikes
            player.TakeDamage(Damage);
        }
    }
}
