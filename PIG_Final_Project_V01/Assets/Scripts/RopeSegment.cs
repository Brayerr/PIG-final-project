using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSegment : MonoBehaviour
{
    public GameObject connectedAbove, connectedBelow;
    private BoxCollider2D collider;
    void Start()
    {
        connectedAbove = GetComponent<HingeJoint2D>().connectedBody.gameObject;
        RopeSegment aboveSegment = connectedAbove.GetComponent<RopeSegment>();
        if (aboveSegment != null)
        {
            aboveSegment.connectedBelow = gameObject;
            float spriteBottom = connectedAbove.GetComponent<SpriteRenderer>().bounds.size.y;
            GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(0, spriteBottom * -1);
        }
        else
        {
            GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(0, 0);
        }
    }

    void Update()
    {
        if (connectedBelow != null)
        {
            collider = gameObject.GetComponent<BoxCollider2D>();
            collider.enabled = false;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("trigger");
    }
}
