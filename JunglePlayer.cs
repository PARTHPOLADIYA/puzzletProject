using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JunglePlayer : MonoBehaviour
{
    [SerializeField] public  AudioClip JumpSound;
    [SerializeField] public AudioClip walk;
    [SerializeField] public  AudioClip shootSound;

    public Transform FirePoint;
    public GameObject BulletPrefab;
    AudioSource footsteps;


    bool isAlive;

    [SerializeField] public static bool isMoving;

    [SerializeField] public  float jumpSpeed = 28f;
    [SerializeField] public float movementSpeed = 7f;
    Rigidbody2D myRidgidBody;
    Animator myAnimator;
    [SerializeField] public bool shoot;
    public bool ShootTrue = true;

    private bool facingRight;
    bool Jump;
    
    CapsuleCollider2D myBodyCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        myBodyCollider2D = gameObject.GetComponent<CapsuleCollider2D>();
        footsteps = gameObject.GetComponent<AudioSource>();
        isAlive = true;
        facingRight = true;
        myRidgidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();

    }
    private void Update()
    {
            HandleInput();
        
        if (myRidgidBody.velocity.x != 0)
        {
            isMoving = true;
           // footsteps.clip = walk;
        }
        else
        {
            isMoving = false;
        }


       
        if (!footsteps.isPlaying)
        {

            footsteps.Play();

        }

        if (!myBodyCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            isMoving = false;
        }

        if (!isMoving)
        {
            footsteps.clip = null;
        }

 

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (isAlive)
        {
            if (isMoving  /*&& myBodyCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground"))*/)
            {
                footsteps.clip = walk;
            }

            float horizontal = Input.GetAxis("Horizontal");
           
            HandleMovement(horizontal);
            Flip(horizontal);
            HandleAttack();
            jump();
            ResetValues();
        }

       
    }

    private void HandleMovement(float horizontal)
    {
        if(!this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("ShootPlayer"))
        {
            myRidgidBody.velocity = new Vector2(horizontal * movementSpeed, myRidgidBody.velocity.y);
        }
       
        myAnimator.SetFloat("speed", Mathf.Abs(horizontal));
    }

    private void HandleAttack()
    {
        if(shoot /*&& !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("ShootPlayer")*/)
        {
        

            Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);          
            myAnimator.SetTrigger("shoot");
            myRidgidBody.velocity = Vector2.zero;
        }
      
       
    }

    private void HandleInput()
    {
        if(Input.GetButtonDown("Fire1")/*Input.GetKeyDown(KeyCode.W)*/)
        {
            if (ShootTrue)
            {
                shoot = true;
                footsteps.PlayOneShot(shootSound);
            }
            

            //footsteps.PlayOneShot(shootSound);
        
        }
      
        if (Input.GetButtonDown("Jump"))
        {
            Jump = true;
            footsteps.PlayOneShot(JumpSound);
            /*if (!myBodyCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                footsteps.PlayOneShot(JumpSound);
            }  */
        }
    }

    private void Flip(float horizontal)
    {
        if(horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            transform.Rotate(0f, 180, 0f);
          
        }
    }

    private void ResetValues()
    {
        shoot = false;
        Jump = false;
    }

    private void jump()
    {
        if (Jump && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("JumpPlayer") )
        {
           // footsteps.clip = JumpSound;
            myAnimator.SetTrigger("Jumping");
            Vector2 jumpVelocityAdd = new Vector2(0f, jumpSpeed);
            myRidgidBody.velocity += jumpVelocityAdd;
        }
    }

      public void Die()
      {
          myAnimator.SetTrigger("Death");
          isAlive = false;
      }

      private void OnCollisionEnter2D(Collision2D collision)
      {
          if (collision.gameObject.tag == "Enemy")
          {

              Die();
          }
      }
}

