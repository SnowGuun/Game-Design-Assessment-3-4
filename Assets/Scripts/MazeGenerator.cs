using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    private int[,] maze = {
        {1, 0, 1, 1, 1, 1, 1, 1, 1, 1},
        {1, 0, 1, 0, 0, 0, 0, 0, 0, 1},
        {1, 0, 0, 0, 1, 0, 1, 1, 0, 1},
        {1, 1, 0, 1, 1, 0, 1, 0, 0, 1},
        {1, 1, 0, 1, 0, 0, 1, 1, 0, 1},
        {1, 0, 0, 0, 0, 0, 1, 0, 0, 1},
        {1, 0, 1, 1, 1, 0, 1, 1, 1, 1},
        {1, 0, 1, 0, 1, 0, 0, 1, 1, 1},
        {1, 0, 0, 0, 0, 1, 0, 0, 1, 1},
        {1, 1, 1, 1, 1, 1, 1, 0, 1, 1},
    };
    // Start is called before the first frame update
    void Start()
    {
        for(int x = 0; x < maze.GetLength(0); x++){
            for(int y = 0; y < maze.GetLength(1); y++){
                if(maze[x, y] == 1){
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.position = new Vector3(x*10, 0, y*10);
                    cube.transform.localScale = new Vector3(10, 10, 10);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
