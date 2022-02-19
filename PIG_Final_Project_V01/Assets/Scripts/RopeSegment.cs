using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A script for each rope segmant logic
/// </summary>
public class RopeSegment : MonoBehaviour
{
    //track the gameObject of segmants above and below itself
    public GameObject connectedAbove, connectedBelow;
    void Start()
    {
        //assign connected object to above
        connectedAbove = GetComponent<HingeJoint2D>().connectedBody.gameObject;
        //try to talk to the script of the above segmant
        RopeSegment aboveSegment = connectedAbove.GetComponent<RopeSegment>();
        //if the above is a rope segmant:
        if (aboveSegment != null)
        {
            //assign the object holding this script as the below of the above object
            aboveSegment.connectedBelow = gameObject;
            //assign the anchor of this hingejoint to be at the bottom of the above object
            float spriteBottom = connectedAbove.GetComponent<SpriteRenderer>().bounds.size.y;
            GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(0, spriteBottom * -1);
        }
        else
        {
            //if the above is not a rope segmant (meaning its the hook), set anchor as the hook
            GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(0, 0);
        }
    }
}
