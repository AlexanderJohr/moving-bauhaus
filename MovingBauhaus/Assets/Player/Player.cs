using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public AudioManager audiomanager;

    public bool ignore;
    public float PlayerJumpPower; //This Variavle Jumppower :ジャンプで上方向にかける強さを決めます。
    public float JumpTime; //Maximum Time for jump
    public float PlayerSpeed; //Maximum Player Movement Speed
    public float PlayerMaxSpeed; //Maximum Player Movement Speed
    public float checkRadius;
    public Transform groundCheck;
    public Transform playerSprite;
    public LayerMask whatIsGround;
    public AudioClip clip1;

    private Rigidbody2D rb;
    private Vector2 v;
    private bool jump;
    private bool isGrounded;
    private bool beingTouched;
    private float volScale;
    private int jumpCounter;
    private AudioSource audioS;

    public Rigidbody2D Rb
    {
        get
        {
            return rb;
        }

        set
        {
            rb = value;
        }
    }

    // Use this for initialization
    void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 1;
        audioS = GetComponent<AudioSource>();
        ignore = false;
        jump = false;
        beingTouched = false;
        jumpCounter = 1;
    }           //OnEnable is called everytime the Object is enabled. It's better for player respawn.

    // Update is called once per frame
    private void Update()
    {

        if (Input.touchCount > 0 && ignore == false)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                //When a touch has first been detected, change the message and record the starting position
                case TouchPhase.Began:
                    beingTouched = true;
                    break;

                case TouchPhase.Ended:
                    beingTouched = false;
                    break;

                default:
                    break;
            }
        }

    }

    void FixedUpdate()
    {
        Jump();
        Move();
    }

    //void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("Ground"))
    //    {
    //        jump = false;
    //    }
    //}

    void Jump()
    {
        var lastVel = rb.velocity.y;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (!isGrounded)
        { jump = true; }
        else if (isGrounded && lastVel <= 0)
        { jump = false; }
        var jumpForce = Vector2.up * PlayerJumpPower * 10f * Time.deltaTime;
        //if (isGrounded) { jump = false; }
        if (jump == false)
        {
            switch (beingTouched)
            {
                case true:
                    if (jumpCounter == 0)
                    {
                        rb.AddForce(jumpForce);
                        volScale = 0.5f;
                        audioS.PlayOneShot(clip1, volScale);
                    }
                    jumpCounter = 1;
                    break;

                case false:
                    if (!isGrounded)
                    {
                        jump = true;
                    }
                    else if (isGrounded && lastVel <= 0)
                    {
                        jump = false;
                    }
                    jumpCounter = 0;
                    break;

                default:
                    break;
            }

        }
    }

    void Move()
    {
        v = rb.velocity;

        var accelForceLeft = Vector2.left * PlayerSpeed * 10f * Time.deltaTime;
        var moveForceLeft = Vector2.left * PlayerSpeed * 2f * Time.deltaTime;
        var jumpForceLeft = Vector2.left * PlayerSpeed * 3f * Time.deltaTime;

        var accelForceRight = Vector2.right * PlayerSpeed * 10 * Time.deltaTime;
        var moveForceRight = Vector2.right * PlayerSpeed * 2f * Time.deltaTime;
        var jumpForceRight = Vector2.right * PlayerSpeed * 3f * Time.deltaTime;

        playerSprite.Rotate(0, 0, -v.x);

        if (Input.acceleration.x < 0 && v.x > -PlayerMaxSpeed)       //If the Smartphone is tilted to the left and Player is not faster than PlayerMaxSpeed
        {
            
            if (v.x > 0)                                                //And if he is still moving to the right                                                   
            {
                if (jump)
                {
                    rb.AddForce(jumpForceLeft);
                    
                } else
                {
                    rb.AddForce(accelForceLeft);
                    
                }        //Move him faster to the left --> Smooth change of direction
            }
            else if (Input.acceleration.x > -0.1 && v.x > -0.5 && v.x < 0.5)     //Or if the phone is only lightly tilted and he is slower than 0.5 either left or right
            {
                v.x = 0;
                rb.velocity = v; //Make Player stand still
            }
            else
            {
                if (jump)
                {
                    rb.AddForce(jumpForceLeft);
                    
                } else
                {
                    rb.AddForce(moveForceLeft);
                    
                }   //Otherwise player moves to right 
            }

        }
        else if (Input.acceleration.x < 0 && v.x >= -PlayerMaxSpeed) //If the Smartphone is tilted to the left and Player is equals to or faster than PlayerMaxSpeed
        {
            v.x = -PlayerMaxSpeed * Time.deltaTime;
            rb.velocity = v;
            //Limit Player speed to PlayerMaxSpeed
        }
        else if (Input.acceleration.x > 0 && v.x <= PlayerMaxSpeed) //If the Smartphone is tilted to the right and Player is not faster than PlayerMaxSpeed
        {
            
            if (v.x < 0)                                               //And if he is still moving to the left
            {
                if (jump)
                {
                    rb.AddForce(jumpForceRight);
                    
                } else
                {
                    rb.AddForce(accelForceRight);
                    
                }       //Move him faster to the right --> Smooth change of direction
            }
            else if (Input.acceleration.x < 0.1 && v.x > -0.5f && v.x < 0.5f)     //Or if the phone is only lightly tilted and he is slower than 0.5 either left or right
            {
                v.x = 0f;
                rb.velocity = v;   //Make Player stand still
                
            }
            else
            {
                if (jump)
                {
                    rb.AddForce(jumpForceRight);
                    
                } else
                {
                    rb.AddForce(moveForceRight);
                    
                };    //Otherwise player moves to right 
            }
        }
        else if (Input.acceleration.x > 0 && v.x <= PlayerMaxSpeed) //If the Smartphone is tilted to the right and Player is equals to or faster than PlayerMaxSpeed
        {
            v.x = PlayerMaxSpeed * Time.deltaTime;
            rb.velocity = v;                                        //Limit Player speed to PlayerMaxSpeed
            
        }
        //Debug.Log(rb.velocity);
    }

    public void PausePlayer()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        ignore = true;
    }

    public void UnPausePlayer()
    {
        rb.constraints = RigidbodyConstraints2D.None;
        ignore = false;
    }

}

