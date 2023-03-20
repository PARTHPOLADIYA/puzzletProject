using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakOnCollisionGraveyard : MonoBehaviour
{
    AudioSource audioData;
    [SerializeField] bool breakbridge;
    // Start is called before the first frame update
    void Start()
    {
        breakbridge = false;
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(breakbridge==true)
        {
            audioData.Play(0);
        }
    }
    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("Player"))
        {
            audioData.Play(0);
            Invoke("Destroy", 0.5f);



        }

    }

        void Destroy()
        {
        Destroy(gameObject);
    }
}
