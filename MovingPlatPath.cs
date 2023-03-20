using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatPath : MonoBehaviour
{

    [SerializeField] List<Transform> wayPoints;
    [SerializeField] float moveSpeed = 2f;
    int waypointIndex = 0;
    [SerializeField] GameObject cross;
    Ischecked chk;


    Vector2 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        try
        {


            transform.position = wayPoints[waypointIndex].transform.position;
            //cross = GameObject.Find("Cross");
            chk = cross.GetComponent<Ischecked>();
            // chk.isChecked.isOn = false;
        }
        catch(Exception)
        {

        }
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionStay2D(Collision2D col)
    {
        
        if (col.gameObject.CompareTag("Player"))
        {
            if (chk.isChecked == true)
            {
               
                //Destroy(cross);
                col.collider.transform.SetParent(transform);

                if (waypointIndex == 0)
                {
                    targetPosition = wayPoints[1].transform.position;
                }
                else if (waypointIndex == 1)
                {
                    targetPosition = wayPoints[0].transform.position;
                }

                var movementThisFrame = moveSpeed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            }
        }
        
    }

   
}
