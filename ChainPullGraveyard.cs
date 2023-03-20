using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainPullGraveyard : MonoBehaviour
{
    [SerializeField] List<Transform> wayPoints;
    [SerializeField] float moveSpeed = 2f;
    int waypointIndex = 0;
    Vector2 targetPosition;
    [SerializeField]  GameObject skull;
    Transform skullpos;
    // Start is called before the first frame update
    void Start()
    {      
        
        skull.transform.position = wayPoints[waypointIndex].transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionStay2D(Collision2D col)
    {
        
        if (col.gameObject.CompareTag("Player"))
        {
           //col.collider.transform.SetParent(transform);
            targetPosition = wayPoints[1].transform.position;
            var movementThisFrame = moveSpeed * Time.deltaTime;
            skull.transform.position = Vector2.MoveTowards(skull.transform.position, targetPosition, movementThisFrame);            
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
        skull.transform.position = wayPoints[0].transform.position;
    }

    
}
