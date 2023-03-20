using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Solve4 : MonoBehaviour
{

    [SerializeField] private Text pressEText;
    [SerializeField] Text time;
    [SerializeField] Image solve;
    [SerializeField] InputField num1Ans;
    [SerializeField] InputField num2Ans;
    [SerializeField] Player player;
    [SerializeField] Button submit;
    [SerializeField] GameObject cross;
    Ischecked chk;
    [SerializeField] bool chk1;
    float timeLeft = 30f;
    int num1;
    int num2;
    bool active;
    bool isPaused;
    // Animator myAnimator;
    AudioSource audioData;
    



    // Start is called before the first frame update
    void Start()
    {
        solve.gameObject.SetActive(false);
        num1Ans.gameObject.SetActive(false);
        num2Ans.gameObject.SetActive(false);       
        pressEText.gameObject.SetActive(false);
        active = false;
        //myAnimator = GetComponent<Animator>();
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            show();
            if (chk1)
            {
                Timer();
            }
            num1 = int.Parse(num1Ans.GetComponent<InputField>().text);
            num2 = int.Parse(num2Ans.GetComponent<InputField>().text);
        }
        catch
        {

        }
        
    }

    public void OnButtonClick()
    {
       
        if(num1<=num2)
        {
            Correct();
            Destroy(gameObject);

        }
        else
        {
            Wrong();
            //Destroy(gameObject);           
        }
        
    }

    public void Wrong()
    {
        /*isPaused = true;
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
        Destroy(cross.gameObject);
       // myAnimator.SetBool("Solved", true);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
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
            pressEText.gameObject.SetActive(false);
            active = false;
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
