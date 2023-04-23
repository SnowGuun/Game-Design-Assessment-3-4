using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceController : MonoBehaviour
{
    private Vector3 nextTile;
    private string currentDir, excludedDir;
    private bool reachedTile = true;
    private bool chasingPlayer = false;
    public float speed = 0.01f;
    [SerializeField] private GameObject player;
    public bool tagged = false;

    void Start() {
        nextTile = transform.position;
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) <= 7){
            LoseCondition.lose();
        }

        Ray ray = new Ray(transform.position, player.transform.position - transform.position);
        RaycastHit hitData;
        Physics.Raycast(ray, out hitData);

        int cX = (int)(((transform.position.x - (transform.position.x % 10)) / 10));
        int cZ = (int)(((transform.position.z - (transform.position.z % 10)) / 10));

        if(hitData.transform.name == "Player"){ 
            if(!chasingPlayer){
                reachedTile = true;
                speed = 15f;
            }
            chasingPlayer = true; 
        }
        else{ 
            speed = 5f;
            chasingPlayer = false; 
        }

        int pX = (int)(((hitData.transform.position.x - ((hitData.transform.position.x + 5) % 10)) / 10) + 1);
        int pZ = (int)(((hitData.transform.position.z - ((hitData.transform.position.z + 5) % 10)) / 10) + 1);

        if(Vector3.Distance(transform.position, nextTile) < 0.1f){
            reachedTile = true;
        }

        if(reachedTile && !chasingPlayer){
            setNewTile(cX, cZ);
        }
        else if(reachedTile && chasingPlayer){
            setChaseTile(cX, cZ, pX, pZ);
        }
        transform.position = Vector3.MoveTowards(transform.position, nextTile, speed*Time.deltaTime);
    }

    private void setNewTile(int cX, int cZ){
        bool up = MazeData.isWallAtTile(cX, cZ+1);
        bool down = MazeData.isWallAtTile(cX, cZ-1);
        bool left = MazeData.isWallAtTile(cX-1, cZ);
        bool right = MazeData.isWallAtTile(cX+1, cZ);

        int walkableAreas = 0;
        string[] dir = new string[4];
        if(!up) { dir[walkableAreas] = "up"; walkableAreas += 1; }
        if(!down) { dir[walkableAreas] = "down"; walkableAreas += 1; }
        if(!left) { dir[walkableAreas] = "left"; walkableAreas += 1; }
        if(!right) { dir[walkableAreas] = "right"; walkableAreas += 1; }

        if(walkableAreas <= 1){
            currentDir = dir[Random.Range(0, walkableAreas)];
        }
        else{
            do{
                currentDir = dir[Random.Range(0, walkableAreas)];
            } while (currentDir == excludedDir);
        }
        
        if(currentDir == "up"){ excludedDir = "down"; } 
        else if(currentDir == "down"){ excludedDir = "up"; } 
        else if(currentDir == "left"){ excludedDir = "right"; } 
        else if(currentDir == "right"){ excludedDir = "left"; }

        switch(currentDir){
            case "up": nextTile = new Vector3(10*cX, 5, 10*(cZ+1)); break;
            case "down": nextTile = new Vector3(10*cX, 5, 10*(cZ-1)); break;
            case "left": nextTile = new Vector3(10*(cX-1), 5, 10*cZ); break;
            case "right": nextTile = new Vector3(10*(cX+1), 5, 10*cZ); break;
            default: break;
        }
        reachedTile = false;
    }
    private void setChaseTile(int cX, int cZ, int pX, int pZ){
        string[] tempDirToP = {"n","n","n","n"};
        int counter = 0;
        if(pX > cX){ tempDirToP[counter] = "right"; counter += 1; }
        if(pX < cX){ tempDirToP[counter] = "left"; counter += 1; }
        if(pZ > cZ){ tempDirToP[counter] = "up"; counter += 1; }
        if(pZ < cZ){ tempDirToP[counter] = "down"; counter += 1; }
        //Debug.Log("Preferred: " + tempDirToP[0] + tempDirToP[1] + tempDirToP[2] + tempDirToP[3]);

        bool up = MazeData.isWallAtTile(cX, cZ+1);
        bool down = MazeData.isWallAtTile(cX, cZ-1);
        bool left = MazeData.isWallAtTile(cX-1, cZ);
        bool right = MazeData.isWallAtTile(cX+1, cZ);

        counter = 0;
        string[] tempWalkableDir = {"n", "n", "n", "n"};
        if(!up){ tempWalkableDir[counter] = "up"; counter += 1; }
        if(!down){ tempWalkableDir[counter] = "down"; counter += 1; }
        if(!left){ tempWalkableDir[counter] = "left"; counter += 1; }
        if(!right){ tempWalkableDir[counter] = "right"; counter += 1; }
        //Debug.Log("Walkable: " + tempWalkableDir[0] + tempWalkableDir[1] + tempWalkableDir[2] + tempWalkableDir[3]);

        counter = 0;
        string[] dir = {"n", "n"};
        for(int i = 0; i < tempDirToP.Length; i++){
            if(tempDirToP[i] != "n"){
                for(int m = 0; m < tempWalkableDir.Length; m++){
                    if(tempDirToP[i] == tempWalkableDir[m]){
                        dir[counter] = tempDirToP[i];
                        counter += 1;
                    }
                }
            }
        }
        //Debug.Log("final: " + dir[0] + ", " + dir[1]);

        if(counter == 1){ currentDir = dir[0]; }
        else{ currentDir = dir[Random.Range(0, 1)]; }

        if(currentDir == "up"){ excludedDir = "down"; } 
        else if(currentDir == "down"){ excludedDir = "up"; } 
        else if(currentDir == "left"){ excludedDir = "right"; } 
        else if(currentDir == "right"){ excludedDir = "left"; }

        switch(currentDir){
            case "up": nextTile = new Vector3(10*cX, 5, 10*(cZ+1)); break;
            case "down": nextTile = new Vector3(10*cX, 5, 10*(cZ-1)); break;
            case "left": nextTile = new Vector3(10*(cX-1), 5, 10*cZ); break;
            case "right": nextTile = new Vector3(10*(cX+1), 5, 10*cZ); break;
            default: break;
        }
        reachedTile = false;
    }
}

