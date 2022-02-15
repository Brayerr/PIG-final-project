using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
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
        if (collision.gameObject.CompareTag("Player"))
        {
            player.transform.position = new Vector3(-7.04f, -3.27f, transform.position.z);
            Debug.Log("mate stay in the map please.");
        }
    }
}
