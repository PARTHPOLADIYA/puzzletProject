using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] GameObject Teleporter;
    // Start is called before the first frame update
    void Start()
    {
        Teleporter.SetActive(false);
    }

  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Teleporter.SetActive(true);
        }
    }
}
