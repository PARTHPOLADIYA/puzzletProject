using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class EnemyGFXGraveyard : MonoBehaviour
{
    [SerializeField] bool isDead;
    public float health = 10f;
    // Start is called before the first frame update
    public AIPath aiPath;
     Animator myAnimator;
    AudioSource audioData;
    [SerializeField] AudioClip speaking;
    [SerializeField] AudioClip dying;
    [SerializeField] GameObject Key;

    private void Start()
    {
        // audioData.Play();
        Key.SetActive(false);
        audioData = gameObject.GetComponent<AudioSource>();
        myAnimator = gameObject.GetComponent<Animator>();
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        try
        {

            if (!audioData.isPlaying)
            {
                audioData.Play();
            }

            if (isDead == true)
            {

                Death();
            }

            if (health <= 0)
            {
                isDead = true;
            }

            if (aiPath.desiredVelocity.x >= 0.01f)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            else if (aiPath.desiredVelocity.x <= -0.01f)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
        catch
        {

        }
    }

    private void Death()
    {
        //audioData.Stop();
        audioData.loop = false;
        audioData.clip = dying;
        Invoke("Volume", 4f);
        Key.SetActive(true);
        //audioData.Play();
        gameObject.GetComponent<AIPath>().enabled = false;
        myAnimator.SetTrigger("Death");
        //gameObject.GetComponent<CapsuleCollider2D>().isTrigger = true;
        gameObject.tag = "Untagged";
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Blade"))
        {
            health = health - 1f;
            Destroy(collision.gameObject);

        }
    }
    void Volume()
    {
        audioData.volume = 0;
    }
}
