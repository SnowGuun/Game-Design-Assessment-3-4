using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceController : MonoBehaviour
{
    public float speed = 5.0f;
    public Vector3 pointA = new Vector3(10f, 5f, 9f);
    public Vector3 pointB = new Vector3(32f, 5f, 9f);
    public Vector3 pointC = new Vector3(32f, 5f, 32f);
    public Vector3 pointD = new Vector3(10f, 5f, 32f);
    
    private Vector3 currentTarget;

    void Start()
    {        
        currentTarget = pointB;
    }

    void Update()
    {

        if (Vector3.Distance(transform.position, currentTarget) < 0.1f){
            if (currentTarget == pointA)
            {
                currentTarget = pointB;
            }
            else if (currentTarget == pointB)
            {
                currentTarget = pointC;
            }
            else if (currentTarget == pointC)
            {
                currentTarget = pointD;
            }
            else
            {
                currentTarget = pointA;

            }

        }
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);

      
    }

}

