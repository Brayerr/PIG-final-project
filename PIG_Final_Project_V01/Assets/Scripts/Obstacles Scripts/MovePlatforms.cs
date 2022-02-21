using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatforms : MonoBehaviour
{
    public GameObject[] waypoints;
    public int current = 0;
    public float speed;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(waypoints[current].transform.position, transform.position) < 0.1)
        {
            //if arrived at waypoint go to next on list
            current++;
            //if arrived at last waypoint on list go to first
            if(current >= waypoints.Length)
            {
                current = 0;
            }
        }
        // move position of platform towards next waypoint in certain speed
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
    }
}
