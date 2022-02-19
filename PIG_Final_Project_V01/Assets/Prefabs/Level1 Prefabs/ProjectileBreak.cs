using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//a simple script to make projectiles break after hitting objects
public class ProjectileBreak : MonoBehaviour
{
    //for hitting player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject, 0.2f);
    }

    //for hitting wall or shredder
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ProjShredder"))
        {
            Destroy(this.gameObject, 0.2f);
        }
    }
}
