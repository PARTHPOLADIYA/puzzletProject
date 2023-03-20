using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetChkTrue : MonoBehaviour
{
    [SerializeField] GameObject switch1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChkTrue()
    {
        try
        {
            switch1.GetComponent<Ischecked>().CheckTrue();
        }
        catch (Exception e)
        {

        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            ChkTrue();
        }
    }

}
