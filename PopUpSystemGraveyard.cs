using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PopUpSystemGraveyard : MonoBehaviour
{
    public GameObject popupBox;
    public Animator animator;
    public Text panelText;

    public void PopUp(string text)
    {
        popupBox.SetActive(true);
        panelText.text = text;
        animator.SetTrigger("pop");
    }

}
