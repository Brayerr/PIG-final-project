using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public Rigidbody2D hook;
    public GameObject ropePrefab;
    public int numLinks = 5;
    public Rigidbody2D bottomJoint;
    // Start is called before the first frame update
    void Start()
    {
        GenerateRope();
    }
    //checkpoint
    void GenerateRope()
    {
        Rigidbody2D prevBod = hook;
        for (int i = 0; i < numLinks; i++)
        {
            GameObject newSeg = Instantiate(ropePrefab);
            newSeg.transform.parent = transform;
            newSeg.transform.position = transform.position;
            HingeJoint2D hj = newSeg.GetComponent<HingeJoint2D>();
            hj.connectedBody = prevBod;
            prevBod = newSeg.GetComponent<Rigidbody2D>();
            if (numLinks - i > 2)
                newSeg.GetComponent<BoxCollider2D>().enabled = false;
            if (numLinks == i + 1)
                bottomJoint = newSeg.GetComponent<Rigidbody2D>();
        }
    }

}
