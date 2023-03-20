using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JungleCrystal : MonoBehaviour
{
    [SerializeField] TMP_Text Timers;
    public float timeleft = 60.0f;

    [SerializeField] public TMP_Text TimerText;

    [SerializeField] bool timeCheck;


    bool DontDisplayAgain =  true;
  
    [SerializeField] Image Whiteimg;
    [SerializeField] Sprite Crystal_img;

    bool activecrystalBlue;
    [SerializeField] JunglePlayer player;
    [SerializeField] TMP_Text YouGotSecondChance;

    [SerializeField] private TMP_Text pressEText3;
    [SerializeField] private TMP_Text QuestionTextField;
    [SerializeField] [TextArea(10, 40)] String QuestionText;
    [SerializeField] bool Option1isRight;
    [SerializeField] Button Option1cb;
    [SerializeField] [TextArea(10, 40)] String Button1;

    [SerializeField] bool Option2isRight;
    [SerializeField] Button Option2cb;
    [SerializeField] [TextArea(10, 40)] String Button2;

    [SerializeField] bool Option3isRight;
    [SerializeField] Button Option3cb;
    [SerializeField] [TextArea(10, 40)] String Button3;

    [SerializeField] bool Option4isRight;
    [SerializeField] Button Option4cb;
    [SerializeField] [TextArea(10, 40)] String Button4;
    [SerializeField] Image BackGround;
   //[SerializeField] Button Continue;


    [SerializeField] [TextArea(10, 40)] String Question2Text;
    [SerializeField] bool Question2Option1isRight;
    [SerializeField] [TextArea(10, 40)] String Question2Button1;

    [SerializeField] bool Question2Option2isRight;
    [SerializeField] [TextArea(10, 40)] String Question2Button2;

    [SerializeField] bool Question2Option3isRight;
    [SerializeField] [TextArea(10, 40)] String Question2Button3;

    [SerializeField] bool Question2Option4isRight;
    [SerializeField] [TextArea(10, 40)] String Question2Button4;





    // Start is called before the first frame update

    private void Start()
    {
        activecrystalBlue = false;
        pressEText3.gameObject.SetActive(false);
        BackGround.gameObject.SetActive(false);
        QuestionTextField.gameObject.SetActive(false);
        Option1cb.gameObject.SetActive(false);
        Option2cb.gameObject.SetActive(false);
        Option3cb.gameObject.SetActive(false);
        Option4cb.gameObject.SetActive(false);
       // Continue.onClick.AddListener(TaskOnClick);
      //  Continue.gameObject.SetActive(false);
        YouGotSecondChance.gameObject.SetActive(false);
        Timers.gameObject.SetActive(false);
        Whiteimg.gameObject.SetActive(false);
    }

    public void SelectOptionCrystalBlue()
    {
        Debug.Log(" SelectOptionCrystalBlue");
        if (Option1isRight)
        {
            Option2cb.onClick.AddListener(wrongCrystalBlue);
            Option3cb.onClick.AddListener(wrongCrystalBlue);
            Option4cb.onClick.AddListener(wrongCrystalBlue);

            Option1cb.onClick.AddListener(correctCrystalBlue);
        }
        else if (Option2isRight)
        {
            Option2cb.onClick.AddListener(correctCrystalBlue);

            Option1cb.onClick.AddListener(wrongCrystalBlue);
            Option3cb.onClick.AddListener(wrongCrystalBlue);
            Option4cb.onClick.AddListener(wrongCrystalBlue);
        }
        else if (Option3isRight)
        {
            Option1cb.onClick.AddListener(wrongCrystalBlue);
            Option2cb.onClick.AddListener(wrongCrystalBlue);
            Option4cb.onClick.AddListener(wrongCrystalBlue);

            Option3cb.onClick.AddListener(correctCrystalBlue);
        }
        else if (Option4isRight)
        {
            Option1cb.onClick.AddListener(wrongCrystalBlue);
            Option2cb.onClick.AddListener(wrongCrystalBlue);
            Option3cb.onClick.AddListener(wrongCrystalBlue);

            Option4cb.onClick.AddListener(correctCrystalBlue);
        }

    }

    public void Question2SelectOptionCrystalBlue()
    {
        Debug.Log("Question2SelectOptionCrystalBlue");
        if (Question2Option1isRight)
        {
            Option2cb.onClick.AddListener(wrongPlayerDieCrystalBlue);
            Option3cb.onClick.AddListener(wrongPlayerDieCrystalBlue);
            Option4cb.onClick.AddListener(wrongPlayerDieCrystalBlue);

            Option1cb.onClick.AddListener(correctCrystalBlue);
        }
        else if (Question2Option2isRight)
        {
            Debug.Log("SecondOption true");
            Option2cb.onClick.AddListener(correctCrystalBlue);

            Option1cb.onClick.AddListener(wrongPlayerDieCrystalBlue);
            Option3cb.onClick.AddListener(wrongPlayerDieCrystalBlue);
            Option4cb.onClick.AddListener(wrongPlayerDieCrystalBlue);
        }
        else if (Question2Option3isRight)
        {
           Option1cb.onClick.AddListener(wrongPlayerDieCrystalBlue);
           Option2cb.onClick.AddListener(wrongPlayerDieCrystalBlue);
           Option4cb.onClick.AddListener(wrongPlayerDieCrystalBlue);

            Option3cb.onClick.AddListener(correctCrystalBlue);
        }
        else if (Question2Option4isRight)
        {
            Option1cb.onClick.AddListener(wrongPlayerDieCrystalBlue);
            Option2cb.onClick.AddListener(wrongPlayerDieCrystalBlue);
            Option3cb.onClick.AddListener(wrongPlayerDieCrystalBlue);

            Option4cb.onClick.AddListener(correctCrystalBlue);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timeCheck)
        {
            Timer();
        }
    }

    private void showCrystalBlue()
    {
        if (activecrystalBlue == true)
        { 
               
                SelectOptionCrystalBlue();
            //Time.timeScale = 0;
                player.movementSpeed = 0f;
                player.jumpSpeed = 0f;
                player.ShootTrue = false;

                TimerText.gameObject.SetActive(false);
                BackGround.gameObject.SetActive(true);
                QuestionTextField.text = QuestionText;
                QuestionTextField.gameObject.SetActive(true);
                Option1cb.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = Button1;
                Option1cb.gameObject.SetActive(true);

                Option2cb.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = Button2;
                Option2cb.gameObject.SetActive(true);

                Option3cb.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = Button3;
                Option3cb.gameObject.SetActive(true);

                Option4cb.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = Button4;
                Option4cb.gameObject.SetActive(true);
            //    Continue.gameObject.SetActive(true);
                pressEText3.gameObject.SetActive(false);
                YouGotSecondChance.gameObject.SetActive(false);
                DontDisplayAgain = false;
        }
    }

    private void show2CrystalBlue()
    {
        if (activecrystalBlue == true)
        {
            Question2SelectOptionCrystalBlue();
            //SelectOption();
            //Time.timeScale = 0;
            YouGotSecondChance.gameObject.SetActive(true);
            BackGround.gameObject.SetActive(true);
            QuestionTextField.text = Question2Text;
            QuestionTextField.gameObject.SetActive(true);
            Option1cb.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = Question2Button1;
            Option1cb.gameObject.SetActive(true);

            Option2cb.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = Question2Button2;
            Option2cb.gameObject.SetActive(true);

            Option3cb.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = Question2Button3;
            Option3cb.gameObject.SetActive(true);

            Option4cb.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = Question2Button4;
            Option4cb.gameObject.SetActive(true);
        //    Continue.gameObject.SetActive(true);
            pressEText3.gameObject.SetActive(false);
            TimerText.gameObject.SetActive(true);
            Timers.gameObject.SetActive(true);

        }
    }


    public void wrongCrystalBlue()
    {
        //Debug.Log("Wrong");
        //Time.timeScale = 1;
        System.Threading.Thread.Sleep(200);
        show2CrystalBlue();
        timeCheck = true;
    }

    public void correctCrystalBlue()
    {
        
        Debug.Log("CorrectCrystalBlue");
        //Time.timeScale = 1;
        TaskOnClick();
        timeCheck = false;
        player.movementSpeed = 9f;
        player.jumpSpeed = 36f;
        player.ShootTrue = true;

        Destroy(gameObject);
        Whiteimg.gameObject.SetActive(true);
        Whiteimg.sprite = Crystal_img;
        
    }

    public void wrongPlayerDieCrystalBlue()
    {
        Debug.Log("WrongDieCrystalBlue");
      //  Time.timeScale = 1;
        TaskOnClick();

        //JunglePlayer player = GetComponent<JunglePlayer>();
        player.Die();
    }

    public void TaskOnClick()
    {
        Time.timeScale = 1;
        activecrystalBlue = false;

        pressEText3.gameObject.SetActive(false);
        BackGround.gameObject.SetActive(false);
        QuestionTextField.gameObject.SetActive(false);
        Option1cb.gameObject.SetActive(false);
        Option2cb.gameObject.SetActive(false);
        Option3cb.gameObject.SetActive(false);
        Option4cb.gameObject.SetActive(false);
     //   Continue.gameObject.SetActive(false);
        YouGotSecondChance.gameObject.SetActive(false);
        Timers.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

       // show();
        if (collision.gameObject.tag == "Player")
        {
            
            Debug.Log("Is trigger");
            activecrystalBlue = true;
            if (DontDisplayAgain)
            {
               
                showCrystalBlue();
            }
            //Destroy(gameObject);
          //  Whiteimg.gameObject.SetActive(true);
          //  Whiteimg.sprite = Crystal_img;

        }

    }

    void Timer()
    {

        timeleft -= Time.deltaTime;
        TimerText.text = timeleft.ToString();
        if (timeleft <= 0)
        {
            TaskOnClick();
            player.Die();
        }

    }
}
