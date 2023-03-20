using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadKeyLevelGraveyard : MonoBehaviour
{
    
    AudioSource audioData;
    [SerializeField] Player player;
    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if (player.hasBallOfDeath)
            {
                audioData.Play(0);
                Invoke("LoadNextLevel", 2);
            }
        }

        
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(2);
    }

}
