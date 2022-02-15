using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ropeswing : MonoBehaviour
{
    public Rigidbody2D rb;
    private HingeJoint2D hj;

    public float pushForce = 10f;

    public bool isAttached = false;
    public Transform attachedRope;
    public GameObject lastGrabbed;

    //public GameObject pulleySelected = null;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        hj = gameObject.GetComponent<HingeJoint2D>();
    }

    void Update()
    {
        CheckKeyboardInput();
    }

    void CheckKeyboardInput()
    {
        if (Input.GetKey(KeyCode.A) && isAttached)
            rb.AddRelativeForce(new Vector3(-1, 0, 0) * pushForce);
        if (Input.GetKey(KeyCode.D) && isAttached)
            rb.AddRelativeForce(new Vector3(1, 0, 0) * pushForce);
        if (Input.GetKeyDown(KeyCode.Space) && isAttached)
            Detach();
    }

    public void Attach(Rigidbody2D heldRope)
    {
        //is player attached
        hj.connectedBody = heldRope;
        hj.enabled = true;
        isAttached = true;
        //lastGrabbed = heldRope.gameObject.transform.parent.gameObject;
        attachedRope = heldRope.gameObject.transform.parent;
    }

    void Detach()
    {
        isAttached = false;
        hj.enabled = false;
        hj.connectedBody = null;
        StartCoroutine(AttachedFalse());
    }


    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (!isAttached)
        {
            if (coll.gameObject.CompareTag("Rope"))
            {
                if (attachedRope != coll.gameObject.transform.parent)
                {
                    if (lastGrabbed == null || coll.gameObject.transform.parent.gameObject != lastGrabbed)
                    {
                        Attach(coll.gameObject.GetComponent<Rigidbody2D>());
                    }
                }
            }
        }
    }

    IEnumerator AttachedFalse()
    {
        yield return new WaitForSeconds(0.3f);
        attachedRope = null;
    }
}
