using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathBall : MonoBehaviour
{
    [SerializeField] GameObject deathBallUI;
    [SerializeField] Text text;
    [SerializeField] Player player;

    // Start is called before the first frame update
    void Start()
    {
        deathBallUI.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.hasBallOfDeath == true)
        {
            deathBallUI.gameObject.SetActive(true);
            text.gameObject.SetActive(true);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
           
        }
    }


}
