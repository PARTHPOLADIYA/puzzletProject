using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ischecked : MonoBehaviour
{
    [SerializeField]  public bool isChecked;
    // Start is called before the first frame update
    void Start()
    {
        //isChecked = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckTrue()
    {
        isChecked = true;
    }
    public void CheckFalse()
    {
        isChecked = false;
    }
}
