using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JungleCoinCounter : MonoBehaviour
{
    TMP_Text coinText;
    //Text coinText;
    public static int coinAmount;
    // Start is called before the first frame update
    void Start()
    {
        coinText = GetComponent<TMP_Text>();

    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = coinAmount.ToString();
    }
}
