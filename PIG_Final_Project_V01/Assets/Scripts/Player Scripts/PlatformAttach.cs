using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour
{
    private readonly string PLAYER_TAG = "Player";
    Transform player;
    private Vector3 lastPos;
    //set the player so it can adjust its location from the platform
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(PLAYER_TAG))
        {
            player = other.transform;
        }
    }

    //clear the player so it stop adjusting its location.
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(PLAYER_TAG))
        {
            player = null;
        }
    }

    private void Update()
    {
        if (player)
            player.transform.position += transform.position - lastPos;
        lastPos = transform.position;
    }
}
