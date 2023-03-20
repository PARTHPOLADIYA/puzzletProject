using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSoundManager : MonoBehaviour
{
    AudioSource CoinAudio;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Coin"))
        {
            CoinAudio.Play();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CoinAudio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
