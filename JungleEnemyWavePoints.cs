using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JungleEnemyWavePoints : MonoBehaviour
{
    AudioSource BlastAudio;



    //  public JungleEnemyQuestionPopUp EnemyPopup;
    public float delay = 0f;
    Animator myAnimator;
    public int health = 100;
    // public GameObject deathEffect;
   // [SerializeField] float moveSpeed = 1f;
   Rigidbody2D myrigidbody;


    private Vector3 posA;
    private Vector3 posB;
    private Vector3 nexPos;
    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform childTransform;
    [SerializeField]
    private Transform transformB;

    // Start is called before the first frame update
    void Start()
    {
        BlastAudio = gameObject.GetComponent<AudioSource>();
        myAnimator = GetComponent<Animator>();
        myrigidbody = GetComponent<Rigidbody2D>();

        posA = childTransform.localPosition;
        posB = transformB.localPosition;
        nexPos = posB;
    }

    // Update is called once per frame
    void Update()
    {
        Move();   

    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            die();
        }
    }
    private void Move()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nexPos, speed * Time.deltaTime);
        if (Vector3.Distance(childTransform.localPosition, nexPos) <= 0.1)
        {
            ChangeDestination();
        }
    }
    private void ChangeDestination()
    {
        nexPos = nexPos != posA ? posA : posB;
        flip();
    }
    void flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
    void die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        BlastAudio.Play();
        myAnimator.SetBool("EnemyDie", true);       
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
        /*if(myAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
             Destroy(gameObject);
        }*/

    }

}
