using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JunglePopUpSystem : MonoBehaviour
{

    bool active;
    [SerializeField] private TMP_Text pressEText;
    [SerializeField] private Text imgText;
    [SerializeField] Image img;
    [SerializeField] Sprite explaination_img;
    [SerializeField] Image explain_hierarchy;
    [SerializeField] [TextArea(10, 40)] String text;
    [SerializeField] Button Exit;



    // Use this for initialization
    private void Start()
    {
        explain_hierarchy.sprite = null;
        active = false;
        pressEText.gameObject.SetActive(false);
        img.gameObject.SetActive(false);
        imgText.gameObject.SetActive(false);
        //explain_hierarchy.gameObject.SetActive(false);
        
        Exit.onClick.AddListener(TaskOnClick);
        Exit.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        show();

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
                
                Exit.gameObject.SetActive(true);
                pressEText.gameObject.SetActive(false);
               Time.timeScale = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            pressEText.gameObject.SetActive(true);
            active = true;
        }
    }


    void TaskOnClick()
    {

       Time.timeScale = 1;
        active = false;
        pressEText.gameObject.SetActive(false);
        img.gameObject.SetActive(false);
        imgText.gameObject.SetActive(false);
        explain_hierarchy.sprite = null;
        Exit.gameObject.SetActive(false);

        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            active = false;
            pressEText.gameObject.SetActive(false);
        }
    }
            /* private void OnTriggerExit2D(Collider2D collision)
               {
                   if (collision.gameObject.CompareTag("Player"))
                   {
                       active = false;
                       pressEText.gameObject.SetActive(false);
                       img.gameObject.SetActive(false);
                       imgText.gameObject.SetActive(false);
                       explain_hierarchy.sprite = null;
                   }
               }  */

            /* private void PickUp()
             {
                 Destroy(gameObject);
             }*/

        }
