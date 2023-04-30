using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMaker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject p = GameObject.CreatePrimitive(PrimitiveType.Plane);
        for(int x = -4; x < 34; x++){
            for(int y = -4; y < 40; y++){
                GameObject plane = Instantiate(p, new Vector3(0, 0, 0), Quaternion.identity);
                plane.transform.position = new Vector3(x*10, -1, y*10);
                plane.transform.parent = this.transform;
                plane.name = x + ":" + y;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
