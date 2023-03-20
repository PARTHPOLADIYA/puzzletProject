using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressurePad : MonoBehaviour
{
    [SerializeField] GameObject platform;
    Animator myAnimator;
    BoxCollider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        collider = platform.GetComponent<BoxCollider2D>();
        collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
    private void OnTriggerStay2D(Collider2D collision)
    {
        //if (collision.gameObject.CompareTag("Box"))
        //{
            //platform.SetActive(true);
            collider.enabled = true;
            myAnimator.SetBool("On", true);
        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //platform.SetActive(false);
        collider.enabled = false;
        myAnimator.SetBool("On", false);
    }


}
