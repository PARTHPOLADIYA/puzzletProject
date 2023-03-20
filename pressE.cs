using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pressE : MonoBehaviour
{
    bool active;
    [SerializeField] private Text pressEText;
    [SerializeField] private Text imgText;
    [SerializeField] Image img;
    [SerializeField] Sprite explaination_img;
    [SerializeField] Image explain_hierarchy;
    [SerializeField] [TextArea(10,40)] String text;
    [SerializeField] GameObject switch1;
    Animator myAnimator;
    AudioSource audioData;


    // Use this for initialization
    private void Start()
    {
        try
        {


            explain_hierarchy.sprite = null;
            active = false;
            pressEText.gameObject.SetActive(false);
            img.gameObject.SetActive(false);
            imgText.gameObject.SetActive(false);
            //explain_hierarchy.gameObject.SetActive(false);
            myAnimator = gameObject.GetComponent<Animator>();
            audioData = GetComponent<AudioSource>();
        }
        catch
        {

        }
        
    }

    // Update is called once per frame
    private void Update()
    {
        try
        {
            show();
        }
        catch
        {

        }

    }

    private void show()
    {
        if (active == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                img.gameObject.SetActive(true);
                imgText.text = text;
                imgText.gameObject.SetActive(true); 
                explain_hierarchy.sprite = explaination_img;
               /* if (explain_hierarchy.sprite == null)
                {
                    explain_hierarchy.gameObject.SetActive(false);
                }*/
                pressEText.gameObject.SetActive(false);
                try
                {
                    audioData.Play(0);
                    myAnimator.SetBool("Solved", true);
                    

                }
                catch(Exception)
                {

                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                pressEText.gameObject.SetActive(true);
                active = true;
            }
        }
        catch
        {

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        try
        {


            if (collision.gameObject.CompareTag("Player"))
            {

                active = false;
                pressEText.gameObject.SetActive(false);
                img.gameObject.SetActive(false);
                imgText.gameObject.SetActive(false);
                explain_hierarchy.sprite = null;
                try
                {
                    switch1.GetComponent<Ischecked>().CheckTrue();


                }
                catch (Exception e)
                {

                }
            }
        }
        catch
        {

        }
    }

   /* private void PickUp()
    {
        Destroy(gameObject);
    }*/

}
