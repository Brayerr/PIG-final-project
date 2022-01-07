using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public BrackeysChar2dController control;
    public Rigidbody2D rb;

    public float runSpeed = 40f;
    public float dashForce;
    public float startDashTimer;

    public float dashCD = 1f;
    public float nextDashTime = 0f;

    float dashDirection;
    float currentDashTimer;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    public bool isDashing;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //setting up horizontal movement keys
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        //setting jump key
        if(Input.GetButtonDown("Jump"))
            jump = true;

        //setting crouch hold key
        if(Input.GetButtonDown("Crouch"))
            crouch = true;

        //if player stops pressing crouch key it stops crouching
        else if(Input.GetButtonUp("Crouch"))
            crouch = false;

        //dash code + dash cooldown
        if (Time.time > nextDashTime)
        {
            //if left shift is pressed and not standing still
            if (Input.GetKeyDown(KeyCode.LeftShift) && horizontalMove != 0)
            {
                isDashing = true;
                currentDashTimer = startDashTimer;
                rb.velocity = Vector2.zero;
                dashDirection = (int)horizontalMove;
                nextDashTime = Time.time + dashCD;
            }
        }

        //Disable crouch when jump 
        if (jump == true)
        {
            crouch = false;
        }


    }

    private void FixedUpdate()
    {
        //actual moving player in fixed update
        control.Move(horizontalMove* Time.fixedDeltaTime, crouch, jump);
        //set jump back to false after jumping
        jump = false;

        //actual dash code and CD reset
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
