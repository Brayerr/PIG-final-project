using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public CharacterController control;
    public Rigidbody2D rb;
    public Player player;

    public int godModeForce;
    public bool godModeActive = false;

    public float runSpeed = 40f;
    public float dashForce;
    public float startDashTimer;

    public float dashCD = 1f;
    public float nextDashTime = 0f;

    float dashDirection;
    float currentDashTimer;
    public float horizontalMove = 0f;
    public float verticalMove = 0f;
    bool jump = false;
    public bool isDashing;

    //wall jump variables.
    public float wallJumpTime = 0.2f;
    public float wallSlideSpeed = 0.3f;
    public float wallDistance = 0.12f;
    bool isWallSliding = false;
    RaycastHit2D WallCheckHit;
    float jumpTime;
    public LayerMask wallLayer;
    public float wallJumpForce = 12.5f;
    public float wallJumpPush = 20f;
    public float airDelay;

    //Animator variables.
    public Animator animator;
    int isWalkingHash;

    public Ropeswing rS;
   
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
    }

    // Update is called once per frame
    void Update()
    {
        //setting up horizontal movement keys
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        
        bool isWalking = animator.GetBool("isWalking");
        bool playerRunning = Input.GetButton("Horizontal");
         

        //setting jump key
        if (Input.GetButtonDown("Jump"))
        {
            //if jumping
            jump = true;
            //jump animation starts
            animator.SetBool("isJumping", true);
            animator.SetBool(isWalkingHash, false);
            
        }

        //Animation activation
        //if Left or Right are pressed
        if (!isWalking && playerRunning)
        {
            //walking animation starts
            animator.SetBool(isWalkingHash,true);
        }
        //if Left or Right are unpressed
        if (isWalking && !playerRunning)
        {
            //walking animation stops
            animator.SetBool(isWalkingHash, false);
        }
        //if player is on the ground
        if(control.m_Grounded)
        {
            //stop jumping animation
            animator.SetBool("grounded", true);
            //stop wall jump animation
            animator.SetBool("walled", false);
        }
        else
        {
            animator.SetBool("grounded", false);
        }

        if (Input.GetButtonUp("Jump"))
        {
            animator.SetBool("isJumping", false);
        }


        //setting wall jump key
        if (isWallSliding && Input.GetButtonDown("Jump"))
        {
            jump = true;
            rb.velocity = new Vector2(-Input.GetAxisRaw("Horizontal") * wallJumpPush, wallJumpForce);
            StartCoroutine(AirControlDelay());
            isWallSliding = false;
        }
            
        //dash code + dash cooldown
        if (Time.time > nextDashTime)
        {
            //if left shift is pressed and not standing still
            if (Input.GetKeyDown(KeyCode.LeftShift) && horizontalMove != 0)
            {
                isDashing = true;
                animator.SetTrigger("isDashing 0");                
                currentDashTimer = startDashTimer;
                rb.velocity = Vector2.zero;
                dashDirection = (int)horizontalMove;
                nextDashTime = Time.time + dashCD;
            }
        }

        if (rS.isAttached == true &&  horizontalMove > 0)
        {
            animator.SetBool("isSwinging", true);
        }
        else if(rS.isAttached == true && horizontalMove < 0)
        {
            animator.SetBool("isSwinging", true);
        }
        else
        {
            animator.SetBool("isSwinging", false);
        }

        //if pressed G god mode will activate
        if (Input.GetKeyDown(KeyCode.G))
        {
            GodModeOn();
        }

        //if pressed G while god mode is on, make god mode off
        if (godModeActive && Input.GetKeyDown(KeyCode.H))
            GodModeOff();

        //vertical movement for god mode
        if (Input.GetKeyDown(KeyCode.DownArrow) && godModeActive)
        {
            rb.AddForce(Vector2.down * godModeForce);
        }


        //if pressed up arrow the player will go up
        if (Input.GetKeyDown(KeyCode.UpArrow) && godModeActive)
        {
            rb.AddForce(Vector2.up * godModeForce);
        }

        //if pressed right arrow the player will go right
        if (Input.GetKeyDown(KeyCode.RightArrow) && godModeActive)
        {
            rb.AddForce(Vector2.right * godModeForce);
        }

        //if pressed left arrow the player will go left
        if (Input.GetKeyDown(KeyCode.LeftArrow) && godModeActive)
        {
            rb.AddForce(Vector2.left * godModeForce);
        }

    }

    private void FixedUpdate()
    {
        //actual moving player in fixed update
        control.Move(horizontalMove* Time.fixedDeltaTime, jump);
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
            {
                isDashing = false;
            }

        }

        //wall jump
        if (control.m_FacingRight)
        {
            //raycast to jump from wall on the right side
            WallCheckHit = Physics2D.Raycast(transform.position, new Vector2(wallDistance, 0), wallDistance, wallLayer);            
        }
        else
        {
            //raycast to jump from wall on the left side
            WallCheckHit = Physics2D.Raycast(transform.position, new Vector2(-wallDistance, 0), wallDistance, wallLayer);            
        }

        if (WallCheckHit && !control.m_Grounded && horizontalMove != 0)
        {
            //activating the wall slide. 
            isWallSliding = true;
            jumpTime = Time.time + wallJumpTime;
        }
        else if (jumpTime < Time.time)
        {            
            isWallSliding = false;
        }

        if (isWallSliding)
        {
            //wall slide animation
            animator.SetBool("walled", true);
            //so the player wont be able to dash off the wall
            isDashing = false;
            //slowing down the player if he is wall sliding
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, wallSlideSpeed, float.MaxValue));
        }
    }
    
    IEnumerator AirControlDelay()
    {
        control.m_AirControl = false;
        yield return new WaitForSeconds(airDelay);
        control.m_AirControl = true;
    }

    //god mode on function
    public void GodModeOn()
    {
        //make player weight 0
        rb.gravityScale = 0;
        //player cant take damage
        player.playerCanTakeDamage = false;
        //setting bool to true
        godModeActive = true;
        //feedback
        Debug.Log("God mode ON");
    }

    //god mode off function
    public void GodModeOff()
    {
        //player weight 3
        rb.gravityScale = 3;
        //player can take damage again
        player.playerCanTakeDamage = true;
        //god mode is off
        godModeActive = false;
        //feedback
        Debug.Log("God mode OFF");
    }
}
