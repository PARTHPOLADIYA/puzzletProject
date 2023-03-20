using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Solve1 : MonoBehaviour
{

    [SerializeField] private Text pressEText;
    [SerializeField] Image solve;
    [SerializeField] Image solve2;
    [SerializeField] Text description;
    [SerializeField] Text description2;
    [SerializeField] Text time;
    [SerializeField] Button option1;
    [SerializeField] Button option1_2;
    [SerializeField] Button option2;
    [SerializeField] Button option2_2;
    [SerializeField] Button option3;
    [SerializeField] Button option3_2;
    [SerializeField] Button option4;
    [SerializeField] Button option4_2;
    [SerializeField] Player player;
    [SerializeField] bool chk;
    float timeLeft = 30f;
    Animator myAnimator;
    bool active;
    bool isPaused;

    AudioSource audioData;



    // Start is called before the first frame update
    void Start()
    {
        solve.gameObject.SetActive(false);
        description.gameObject.SetActive(false);
        option1.gameObject.SetActive(false);
        option2.gameObject.SetActive(false);
        option3.gameObject.SetActive(false);
        option4.gameObject.SetActive(false);
        pressEText.gameObject.SetActive(false);
        description2.gameObject.SetActive(false);
        option1_2.gameObject.SetActive(false);
        option2_2.gameObject.SetActive(false);
        option3_2.gameObject.SetActive(false);
        option4_2.gameObject.SetActive(false);
        active = false;
        myAnimator = GetComponent<Animator>();
        audioData = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        show();
        if(chk)
        {
            Timer();
        }
      
        
    }

    public void Wrong()
    {
       chk=true;
       solve.gameObject.SetActive(false);
        description.gameObject.SetActive(false);
        option1.gameObject.SetActive(false);
        option2.gameObject.SetActive(false);
        option3.gameObject.SetActive(false);
        option4.gameObject.SetActive(false);
        pressEText.gameObject.SetActive(false);
        show2();


    }

    public void Wrong2()
    {
        //GameOver
        Debug.Log("GameOver");

    }

    private void show2()
    {
        
        solve2.gameObject.SetActive(true);
        description2.gameObject.SetActive(true);
        option1_2.gameObject.SetActive(true);
        option2_2.gameObject.SetActive(true);
        option3_2.gameObject.SetActive(true);
        option4_2.gameObject.SetActive(true);
        pressEText.gameObject.SetActive(false);
    }

    public void Correct()
    {
        audioData.Play(0);
        //player.isFighting = true;
        player.enableFight = true;
        player.runSpeed = 5f;
        player.jumpSpeed = 28f;
        solve.gameObject.SetActive(false);
        isPaused = true;
        Time.timeScale = 1;
        myAnimator.SetBool("Solved", true);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            pressEText.gameObject.SetActive(true);
            active = true;           
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            solve.gameObject.SetActive(false);
            description.gameObject.SetActive(false);
            option1.gameObject.SetActive(false);
            option2.gameObject.SetActive(false);
            option3.gameObject.SetActive(false);
            option4.gameObject.SetActive(false);
            pressEText.gameObject.SetActive(false);
            active = false;     
        }
    }

    private void show()
    {
        if (active == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                player.enableFight = false;
                player.runSpeed = 0f;
                player.jumpSpeed = 0f;
                solve.gameObject.SetActive(true);
                description.gameObject.SetActive(true);
                option1.gameObject.SetActive(true);
                option2.gameObject.SetActive(true);
                option3.gameObject.SetActive(true);
                option4.gameObject.SetActive(true);
                pressEText.gameObject.SetActive(false);
                isPaused = false;
               // Time.timeScale = 0;
               
            }
        }
    }

   

    void Timer()
    {
       


            timeLeft -= Time.deltaTime;
            time.text = timeLeft.ToString();
            if (timeLeft < 0)
            {
            time.gameObject.SetActive(false);
            Debug.Log("GameOver");
            //GameOver Scene
        }
    }
    

    IEnumerator waiter()
    {
       
        time.text = timeLeft.ToString();
        if (timeLeft < 0)
        {
            player.Die();
        }
        yield return new WaitForSeconds(1);
        
       
    }
    }
