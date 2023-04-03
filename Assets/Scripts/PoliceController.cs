using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PoliceController : MonoBehaviour
{
    public float speed = 5.0f;
    private Vector3[] pos = 
    {
        new Vector3(120, 5, 20),
        new Vector3(60, 5, 20),
        new Vector3(60, 5, 80),
        new Vector3(80, 5, 80),
        new Vector3(80, 5, 90),
        new Vector3(120, 5, 90)
    };

    private int currentTarget = 0;
    public float flag;

    [SerializeField] private GameObject player;
    void Update()
    {
        if (Vector3.Distance(transform.position, pos[currentTarget]) < 0.1f){
            currentTarget += 1;
            if(currentTarget >= pos.Length){ currentTarget = 0; }
        }
        transform.position = Vector3.MoveTowards(transform.position, pos[currentTarget], speed * Time.deltaTime);

        flag = Vector3.Distance(transform.position, player.transform.position);
        if(Vector3.Distance(transform.position, player.transform.position) < 7){
            player.GetComponent<PlayerData>().setTagged(true);
        }
    }

}

