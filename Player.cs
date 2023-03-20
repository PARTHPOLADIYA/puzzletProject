using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] public bool hasBallOfDeath;
    [SerializeField] public float jumpSpeed = 28f;
    [SerializeField] public float runSpeed = 5f;
    [SerializeField] public Vector2 deathKick = new Vector2(25f,25f);
    [SerializeField] GameObject blade;
    [SerializeField] public float bladeSpeed = 8f;

    public bool isAlive = true;
    bool isMoving;
    public bool isFighting;

    Rigidbody2D myRidgidBody;
    CapsuleCollider2D myBodyCollider2D;
    Animator myAnimator;
    AudioSource audioData;
   
    [SerializeField] GameObject deathBallUI;
    [SerializeField] Text text;
    [SerializeField] GameObject tomb;
    [SerializeField] Text tombText;
    float move;
    GameObject blade1;
    
    [SerializeField] AudioClip groundSound;
    [SerializeField] AudioClip bridgeSound;
    [SerializeField] AudioClip jumpSound;

    bool facingRight = true;
    public bool enableFight;
    // Start is called before the first frame update
    void Start()
    {
        
        try
        {
            enableFight = true;
            hasBallOfDeath = false;
            myRidgidBody = GetComponent<Rigidbody2D>();
            myAnimator = GetComponent<Animator>();
            myBodyCollider2D = GetComponent<CapsuleCollider2D>();
            audioData = GetComponent<AudioSource>();
            deathBallUI.gameObject.SetActive(false);
            text.gameObject.SetActive(false);
            tombText.gameObject.SetActive(false);
          
        }
          
        catch (Exception)
        {

        }       
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");
        if (isAlive)
        {
            if (hasBallOfDeath == true)
            {
                deathBallUI.gameObject.SetActive(true);
                text.gameObject.SetActive(true);
            }

            if(isFighting && myBodyCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")) || isFighting && !myBodyCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                myAnimator.SetTrigger("Fight");
            }
            else
            {
               
                Invoke("SetFightFalse", 1f);
            }
           
            run();
            jump();
            //FlipSprite();
            Fight();
            //Die();
            if (myRidgidBody.velocity.x != 0)
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }

            if (isMoving)
            {
                if(!audioData.isPlaying)
                {                  
                    audioData.Play();
                }              
            }
            else
            {
                audioData.Stop();
            }
           
        }
    }

    private void FixedUpdate()
    {
        move = Input.GetAxisRaw("Horizontal");
        if (isAlive)
        {
            //run();

            // Fight();
            if (move < 0 && facingRight)
            {
                FlipSprite();

            }
            else if (move > 0 && !facingRight)
            {
                FlipSprite();
            }
        }
    }

    private void Fight()
    {

        if(Input.GetButtonDown("Fire1"))
        {
            if (enableFight)
            {

                isFighting = true;
               
                    GameObject blade1 = Instantiate(blade, transform.position, Quaternion.identity) as GameObject;
                    if (facingRight)
                    {
                        blade1.GetComponent<Rigidbody2D>().velocity = new Vector2(bladeSpeed, 0f);
                    }
                    else if (!facingRight)
                    {
                        blade1.GetComponent<Rigidbody2D>().velocity = new Vector2(-bladeSpeed, 0f);
                    }

                    Destroy(blade1, 1.5f);
                
                
            }
            
            //blade1.transform.Rotate(0, 0, 360 * Time.deltaTime);
          
        }
        else
        {
            //myAnimator.SetBool("Fighting", false);
            isFighting = false;

        }
    }

    void SetFightFalse()
    {
        isFighting = false;
    }

    

    private void run()
    {
        float controlThrow = Input.GetAxis("Horizontal");
        
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRidgidBody.velocity.y);
        myRidgidBody.velocity = playerVelocity;
       // myRidgidBody.AddForce(playerVelocity);

        bool playerHasHorizontalSpeed = Mathf.Abs(myRidgidBody.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed && myBodyCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {

            myAnimator.SetBool("Running", playerHasHorizontalSpeed);
        }
        else
        {
            myAnimator.SetBool("Running", false);
        }
     
    }

    private void jump()
    {
        if (!myBodyCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            myAnimator.SetBool("Jumping",true);

            audioData.clip = jumpSound;
            return;
        }
        else
        {
            myAnimator.SetBool("Jumping", false);
        }
            if (Input.GetButtonDown("Jump"))
            {
           
                Vector2 jumpVelocityAdd = new Vector2(0f, jumpSpeed);
                myRidgidBody.velocity += jumpVelocityAdd;
            }
            //else
            //{
            //    myAnimator.SetBool("Jumping", false);
            //}
        
    }

    private void FlipSprite()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    public void Die()
    {
                myAnimator.SetTrigger("Death");
                GetComponent<Rigidbody2D>().velocity = deathKick;
                isAlive = false;
                isMoving = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
        if(collision.gameObject.CompareTag("DeathBall"))
        {
            Destroy(collision.gameObject);
            hasBallOfDeath = true;
        }
        if(collision.gameObject.CompareTag("Tomb"))
        {
            if(hasBallOfDeath==true)
            {

            }
            else
            {
                tombText.gameObject.SetActive(true);
            }
        }

        if (collision.gameObject.CompareTag("Bridge"))
        {
            audioData.clip = bridgeSound;
        }
        else 
        {
            audioData.clip = groundSound;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tomb"))
        {
            tombText.gameObject.SetActive(false);
        }

    }


}
