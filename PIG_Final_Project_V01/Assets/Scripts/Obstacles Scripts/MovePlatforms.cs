using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatforms : MonoBehaviour
{
    // waypoint reference.
    public GameObject[] waypoints;
    // platform variables.
    public int current = 0;
    public float speed;
    
    // Update is called once per frame
    void Update()
    {
        //if arrived at the waypoint.
        if(Vector3.Distance(waypoints[current].transform.position, transform.position) < 0.1)
        {
            //go to the next on the list.
            current++;
            //if arrived at last waypoint on the list go to the first.
            if(current >= waypoints.Length)
            {
                current = 0;
            }
        }
        // move position of platform towards next waypoint in certain speed.
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
    }
}
