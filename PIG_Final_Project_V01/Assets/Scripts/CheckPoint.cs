using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") == true && player.checkPoint != this.transform.position)
        {
            player.checkPoint = this.transform.position;
            Debug.Log("checkpoint saved");
        }
    }
}
