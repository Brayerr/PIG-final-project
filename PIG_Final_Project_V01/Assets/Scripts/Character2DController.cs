using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2DController : MonoBehaviour
{
    public float movementSpeed = 1f;
    public float jumpForce = 1f;
    public float dashForce;
    public float startDashTimer;
    private float currentDashTimer;
    private float dashDirection;
    public bool isDashing;
    public float dashCD = 1f;
    public float nextDashTime = 0f;

    private Rigidbody2D rb;
    

    // Start is called before the first frame update
    void Start()
    {
        //rigidbody refference
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX;
        //setting up movement for character
        moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * movementSpeed, rb.velocity.y);

        //if character moves in different direction it rotates
        if (!Mathf.Approximately(0, moveX))
            transform.rotation = moveX > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;

        //jump code
        if(Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        //dash code + dash cooldown
        if (Time.time > nextDashTime)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && moveX != 0)
            {
                isDashing = true;
                currentDashTimer = startDashTimer;
                rb.velocity = Vector2.zero;
                dashDirection = (int)moveX;
                nextDashTime = Time.time + dashCD;
            }
        }
        if (isDashing)
        {
            rb.velocity = new Vector2(dashForce, 0) * dashDirection;
            currentDashTimer -= Time.deltaTime;
            dashCD = 2;
            dashCD -= Time.deltaTime;            

            if (currentDashTimer <= 0)            
                isDashing = false;
        }

    }
}
