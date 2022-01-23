using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesScript : MonoBehaviour
{
    //player script reffrence
    Player player;
    //setting spike damage
    public int Damage = 1;
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
    //when colliding with spike
    void OnCollisionEnter2D(Collision2D coll)
    {  
        //player takes damage from spikes
        player.TakeDamage(Damage);
    }
}
