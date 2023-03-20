using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostCryptPlayer : MonoBehaviour

{
    // config
    [SerializeField] float jumpSpeed = 28f;
    [SerializeField] float runSpeed = 5f;
    [SerializeField] Vector2 deathKick = new Vector2(25f, 25f);

    // state 
    bool isAlive = true;

    // cached component refrences
    Rigidbody2D myRidgidBody;
    Animator myAnimator;
    CapsuleCollider2D myBodyColider;


    // messages then methods 
    void Start()
    {
        myRidgidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyColider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive) { return; }
        run();
        FlipSide();
        jump();
        Die();
    }

    private void run()
    {
        float controlThrow = Input.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRidgidBody.velocity.y);
        myRidgidBody.velocity = playerVelocity;

        bool playerHasHorizonticalSpeed = Mathf.Abs(myRidgidBody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Running", playerHasHorizonticalSpeed);
        
    }
    public void FlipSide()
    {
        // if the player is moving horizontically
        bool playerHasHorizonticalSpeed = Mathf.Abs(myRidgidBody.velocity.x) > Mathf.Epsilon;
        {
            // reverse the scaling of x axis
            if(playerHasHorizonticalSpeed)
            {
                transform.localScale = new Vector2(Mathf.Sign(myRidgidBody.velocity.x), 1f);
            }
        }
    }
    private void jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocityAdd = new Vector2(0f, jumpSpeed);
            myRidgidBody.velocity += jumpVelocityAdd;
        }
    }

    private void Die()
    {

        if (myBodyColider.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            isAlive = false;
            myAnimator.SetTrigger("Dying");
            GetComponent<Rigidbody2D>().velocity = deathKick;
        }
    }
}