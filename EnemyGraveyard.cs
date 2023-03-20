using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGraveyard : MonoBehaviour
{

     Rigidbody2D rb;
    Vector3 Healthbar;
    CapsuleCollider2D Collider2D;
    Animator myAnimator;
    [SerializeField] float moveSpeed;
    public float health = 10f;
   // public float maxHealth = 10f;
    [SerializeField] GameObject blade;
    // public HealthBarGraveyard healthBar;
    //AudioSource audioData;
    public bool isDead;


    // Start is called before the first frame update
    void Start()
    {
        try
       {
            // health = maxHealth;
            //audioData = GetComponent<AudioSource>();
            myAnimator = GetComponent<Animator>();
            Collider2D = GetComponent<CapsuleCollider2D>();
            isDead = false;
            gameObject.GetComponent<pressE>().enabled = false;
            rb = GetComponent<Rigidbody2D>();
            //audioData.Play(0);
        }
       catch(Exception)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        //healthBar.SetHealth(health, maxHealth);

        /*if (health <= 0)
        {
            isDead = true;
        }*/
        if (health <= 0)
            {
            Death();  
            }
        
            if (IsFacingRight())
            {
                rb.velocity = new Vector2(moveSpeed, 0f);
            }
            else
            {
                rb.velocity = new Vector2(-moveSpeed, 0f);
            }   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boundary"))
        {
            transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)), 1f);
        }

        if (collision.gameObject.CompareTag("Blade"))
        {
            health = health - 1f;            
                      
        }
    }
    void Death()
    {   
       
        moveSpeed = 0f;
        myAnimator.SetTrigger("Death");
        Collider2D.isTrigger=true;
        gameObject.GetComponent<pressE>().enabled = true;
        //audioData.Stop();

    }

    bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }

}