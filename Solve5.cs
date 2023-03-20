using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Solve5 : MonoBehaviour
{

    [SerializeField] private Text pressEText;
    [SerializeField] Text time;
    [SerializeField] bool chk1;
    [SerializeField] Image solve;
    [SerializeField] InputField num1Ans;
    [SerializeField] InputField num2Ans;
    [SerializeField] Player player;
    [SerializeField] Button submit;
    [SerializeField] GameObject cross;
    [SerializeField] GameObject deathBall;
    float timeLeft = 30f;
    Ischecked chk;
    String for1;
       String if1;
    bool active;
    bool isPaused;
    [SerializeField]public bool solved;
    Animator myAnimator;
  




    // Start is called before the first frame update
    void Start()
    {
        solve.gameObject.SetActive(false);
        num1Ans.gameObject.SetActive(false);
        num2Ans.gameObject.SetActive(false);
        pressEText.gameObject.SetActive(false);
        active = false;
        solved = false;
        myAnimator = gameObject.GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        show();
        for1 = num1Ans.GetComponent<InputField>().text.ToString();
        if1 = num2Ans.GetComponent<InputField>().text.ToString();

        if(solved==true)
        {
            Destroy(gameObject);
           
        }
        if (chk1)
        {
            Timer();
        }
    }

    public void OnButtonClick()
    {

        if (for1== "i=0;i<=100;i++" || for1 == "i=0;i==100;i++" || for1 == "i=0;i==100;++i" || for1 == "i=0;i<=100;++i" && if1 == "i%2==0")
        {
            solved = true;
            Correct();
            
        }
        else
        {
            Wrong();
            
        }

    }

    public void Wrong()
    {
        /* isPaused = true;
         Time.timeScale = 1;
         player.Die();
         solve.gameObject.SetActive(false);*/
        chk1 = true;
    }

    public void Correct()
    {
        player.isFighting = true;
        player.runSpeed = 5f;
        player.jumpSpeed = 28f;
        solve.gameObject.SetActive(false);
        isPaused = true;
        Time.timeScale = 1;
        chk = cross.GetComponent<Ischecked>();
        chk.CheckTrue();
        myAnimator.SetBool("Solved", true);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            pressEText.gameObject.SetActive(true);
            active = true;
        }
    }
    void Timer()
    {

        timeLeft -= Time.deltaTime;
        time.text = timeLeft.ToString();
        if (timeLeft < 0)
        {
            time.gameObject.SetActive(false);
            //GameOver Scene
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            solve.gameObject.SetActive(false);
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
                player.isFighting = false;
                player.runSpeed = 0;
                player.jumpSpeed = 0;
                solve.gameObject.SetActive(true);
                num1Ans.gameObject.SetActive(true);
                num2Ans.gameObject.SetActive(true);
                pressEText.gameObject.SetActive(false);
                isPaused = false;
                //Time.timeScale = 0;
            }
        }
    }
}
