using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ropeswing : MonoBehaviour
{
    public Rigidbody2D rb;              //tracks rigidbody
    private HingeJoint2D hj;            //tracks hingejoint
    public int detachforce;

    public bool isAttached = false;     //tracks if the player is on a rope
    public Transform attachedRope;      //tracks the transform of the rope player is attached to

    private void Awake()
    {
        //assign rigidbody and hingejoint of player
        rb = gameObject.GetComponent<Rigidbody2D>();
        hj = gameObject.GetComponent<HingeJoint2D>();
    }

    void Update()
    {
        CheckKeyboardInput();
    }

    void CheckKeyboardInput()
    {
        //use Detach if attached and jump is pressed
        if (Input.GetKeyDown(KeyCode.Space) && isAttached)
        {
            Detach();
        }
    }

    //method to be used when colliding with rope. will attach player to the bottom rope segmant
    public void Attach(Rigidbody2D heldRope)
    {
        hj.enabled = true;  //enable the hingejoint on player (disabled by default)
        isAttached = true;  //track player as attached
        //track the transform of the rope which is the parent of the collided hinge joint
        attachedRope = heldRope.gameObject.transform.parent;
        //track the rope parent gameobject
        GameObject ropeParent = heldRope.gameObject.transform.parent.gameObject;
        //connect hingejoint to the bottom segmant of that rope
        hj.connectedBody = ropeParent.GetComponent<Rope>().bottomJoint;
    }

    //method to disconnect from the rope
    void Detach()
    {
        isAttached = false;  //track player as not attached
        hj.enabled = false;  //disable hingejoint
        hj.connectedBody = null;    //clear the hingejoint of player
        ///start a coroutine to set attachedRope to null after a small delay. 
        ///this will allow the player to quickly jump between 2 ropes but prevent the player from immediately reattaching to the same rope.
        StartCoroutine(AttachedFalse());
        rb.AddRelativeForce(new Vector3(0, detachforce, 0));  //add a jump force when detaching
    }

    //on trigger, check if need to call the attach method
    private void OnTriggerEnter2D(Collider2D coll)
    {
        //if player is not currently attached
        if (!isAttached)
        {
            //if the object triggering is a rope
            if (coll.gameObject.CompareTag("Rope"))
            {
                //if the rope touched is not the same rope the player is currently holding or just detached from
                if (attachedRope != coll.gameObject.transform.parent)
                {
                    //call the attach method 
                    Attach(coll.gameObject.GetComponent<Rigidbody2D>());
                }
            }
        }
    }

    //a coroutine that will clear attachedRope after a delay, called when detaching
    IEnumerator AttachedFalse()
    {
        yield return new WaitForSeconds(0.3f);
        //if the player is not attached, clear attachedRope.
        if (!isAttached)
            attachedRope = null;
    }
}
