using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    //player refference
    Player player;
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

    //trigger function
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if checkpoint collides with player and player checkpoint isnt equal to this checkpoint
        if(collision.gameObject.CompareTag("Player") == true && player.checkPoint != this.transform.position)
        {
            //make players checkpoint this checkpoint
            player.checkPoint = this.transform.position;
            //send message to player
            Debug.Log("checkpoint saved");
        }
    }
}
