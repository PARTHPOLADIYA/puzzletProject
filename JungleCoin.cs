using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JungleCoin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
           
            JungleCoinCounter.coinAmount += 1;
            Destroy(gameObject);
        }
    }

 
}
