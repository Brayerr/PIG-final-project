using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public Rigidbody2D hook;            //track the rope hook
    public GameObject ropePrefab;       //segmant prefab
    public int numLinks = 5;            //rope length
    public Rigidbody2D bottomJoint;     //track the last joint
    
    void Start()
    {
        GenerateRope();
    }

    //primary method
    void GenerateRope()
    {
        //track the segmant above, will be hook in the first time
        Rigidbody2D prevBod = hook;
        //start generating rope segmants
        for (int i = 0; i < numLinks; i++)
        {
            //instantiate segmant
            GameObject newSeg = Instantiate(ropePrefab);
            //give it transforms
            newSeg.transform.parent = transform;
            newSeg.transform.position = transform.position;
            //tracks hingejoint of the new segmant
            HingeJoint2D hj = newSeg.GetComponent<HingeJoint2D>();
            //connect it to the tracked segmant above
            hj.connectedBody = prevBod;
            //update the tracked segmant above to be the recently created segmant
            prevBod = newSeg.GetComponent<Rigidbody2D>();

            //disable the colliders on segmants that are not the last 2, since we only want to grab to those
            if (numLinks - i > 2)
                newSeg.GetComponent<BoxCollider2D>().enabled = false;
            //assign the last segmant to bottomJoint
            if (i == numLinks - 1)
                bottomJoint = newSeg.GetComponent<Rigidbody2D>();
        }
    }
}
