using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceController : MonoBehaviour
{
    private Vector3 prevTile, nextTile;
    private string currentDir, oldDir, excludedDir;
    private bool reachedTile = true;
    private bool turning = false;
    private float turnTimer = 0;
    public float speed, turningSpeed;
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3[] loadedTiles;
    public float flag;

    void Start() {
        int cX = (int)((transform.position.x - (transform.position.x % 10)) / 10);
        int cZ = (int)((transform.position.z - (transform.position.z % 10)) / 10);
        nextTile = new Vector3(cX*10, 5, cZ*10);
    }

    void Update()
    {
        flag = transform.rotation.y;
        //transform.LookAt(player.transform.position);
        if(Vector3.Distance(transform.position, player.transform.position) <= 8){
            LoseCondition.lose();
        }

        if(Vector3.Distance(transform.position, nextTile) < 0.1f){
            reachedTile = true;
        }

        Ray ray = new Ray(transform.position, player.transform.position - transform.position);
        RaycastHit hitData;
        Physics.Raycast(ray, out hitData);

        int cX = (int)((transform.position.x - (transform.position.x % 10)) / 10);
        int cZ = (int)((transform.position.z - (transform.position.z % 10)) / 10);

        int pX = (int)(((hitData.transform.position.x - ((hitData.transform.position.x + 5) % 10)) / 10) + 1);
        int pZ = (int)(((hitData.transform.position.z - ((hitData.transform.position.z + 5) % 10)) / 10) + 1);

        if(hitData.transform.name == "Player"){
            if(Vector3.Angle(transform.forward, player.transform.position - transform.position) < 45){
                Debug.Log("see player");
                LoadTiles(pX, pZ);
                speed = 15f;
                turningSpeed = 3f;
            }
        }
        if(turning){
            if(Vector3.Angle(transform.forward, new Vector3(nextTile.x*10, 5, nextTile.z*10) - new Vector3(prevTile.x*10, 5, prevTile.z*10)) == 0){
                turning = false;
                reachedTile = false;
            }
            else{
                
            }
        }
        else if(reachedTile){
            transform.position = nextTile;
            oldDir = currentDir;
            if(loadedTiles.Length > 0){
                prevTile = nextTile;
                nextTile = loadedTiles[0];
                Vector3[] tempVec = new Vector3[loadedTiles.Length + 1];
                for(int i = 0; i < loadedTiles.Length - 1; i++){
                    tempVec[i] = loadedTiles[i+1];
                }
                loadedTiles = new Vector3[tempVec.Length];
                for(int i = 0; i < tempVec.Length; i++){
                    loadedTiles[i] = tempVec[i];
                }

                if(nextTile.x > prevTile.x){ currentDir = "right"; }
                else if(nextTile.x < prevTile.x){ currentDir = "left"; }
                else if(nextTile.z > prevTile.z){ currentDir = "up"; }
                else if(nextTile.z < prevTile.z){ currentDir = "down"; }

                if(currentDir == "up"){ excludedDir = "down"; } 
                else if(currentDir == "down"){ excludedDir = "up"; } 
                else if(currentDir == "left"){ excludedDir = "right"; } 
                else if(currentDir == "right"){ excludedDir = "left"; }
            }
            else{
                speed = 5f;
                turningSpeed = 1f;
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

                if(walkableAreas > 1){
                    do{
                        currentDir = dir[Random.Range(0, walkableAreas)];
                    } while (currentDir == excludedDir);
                }
                else{ currentDir = dir[0]; }

                if(currentDir == "up"){ excludedDir = "down"; nextTile = new Vector3(cX, 5, cZ+1); } 
                else if(currentDir == "down"){ excludedDir = "up"; nextTile = new Vector3(cX, 5, cZ-1); } 
                else if(currentDir == "left"){ excludedDir = "right"; nextTile = new Vector3(cX+1, 5, cZ); } 
                else if(currentDir == "right"){ excludedDir = "left"; nextTile = new Vector3(cX-1, 5, cZ); }
            }
            if(currentDir != oldDir){ turning = true; }
            else{ reachedTile = false; }
        }
        else{
            Vector3 truePos = new Vector3(nextTile.x*10, 5, nextTile.z*10);
            transform.position = Vector3.MoveTowards(transform.position, truePos, speed*Time.deltaTime);
        }

    }

    private void LoadTiles(int pX, int pZ){
        loadedTiles = new Vector3[1];
        loadedTiles[0] = nextTile;
        bool canGoFurther = true;
        do{
            string[] tempDirToP = {"n","n","n","n"};
            int counter = 0;
            if(pX > loadedTiles[loadedTiles.Length-1].x){ tempDirToP[counter] = "right"; counter += 1; }
            if(pX < loadedTiles[loadedTiles.Length-1].x){ tempDirToP[counter] = "left"; counter += 1; }
            if(pZ > loadedTiles[loadedTiles.Length-1].z){ tempDirToP[counter] = "up"; counter += 1; }
            if(pZ < loadedTiles[loadedTiles.Length-1].z){ tempDirToP[counter] = "down"; counter += 1; }

            bool up = MazeData.isWallAtTile((int)loadedTiles[loadedTiles.Length-1].x, (int)loadedTiles[loadedTiles.Length-1].z + 1);
            bool down = MazeData.isWallAtTile((int)loadedTiles[loadedTiles.Length-1].x, (int)loadedTiles[loadedTiles.Length-1].z - 1);
            bool left = MazeData.isWallAtTile((int)loadedTiles[loadedTiles.Length-1].x - 1, (int)loadedTiles[loadedTiles.Length-1].z);
            bool right = MazeData.isWallAtTile((int)loadedTiles[loadedTiles.Length-1].x + 1, (int)loadedTiles[loadedTiles.Length-1].z);

            counter = 0;
            string[] tempWalkableDir = {"n", "n", "n", "n"};
            if(!up){ tempWalkableDir[counter] = "up"; counter += 1; }
            if(!down){ tempWalkableDir[counter] = "down"; counter += 1; }
            if(!left){ tempWalkableDir[counter] = "left"; counter += 1; }
            if(!right){ tempWalkableDir[counter] = "right"; counter += 1; }

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

            if(counter > 0){
                Vector3[] tempVec = new Vector3[loadedTiles.Length + 1];
                for(int i = 0; i < loadedTiles.Length; i++){
                    tempVec[i] = loadedTiles[i];
                }
                
                if(counter == 1){ currentDir = dir[0]; }
                else{ currentDir = dir[Random.Range(0, 1)]; }

                if(currentDir == "up"){ tempVec[tempVec.Length - 1] = new Vector3(tempVec[tempVec.Length - 2].x, 5, tempVec[tempVec.Length - 2].z + 1); }
                else if(currentDir == "down"){ tempVec[tempVec.Length - 1] = new Vector3(tempVec[tempVec.Length - 2].x, 5, tempVec[tempVec.Length - 2].z - 1); }
                else if(currentDir == "left"){ tempVec[tempVec.Length - 1] = new Vector3(tempVec[tempVec.Length - 2].x - 1, 5, tempVec[tempVec.Length - 2].z); }
                else if(currentDir == "right"){ tempVec[tempVec.Length - 1] = new Vector3(tempVec[tempVec.Length - 2].x + 1, 5, tempVec[tempVec.Length - 2].z); }

                loadedTiles = new Vector3[tempVec.Length];
                for(int i = 0; i < tempVec.Length; i++){
                    loadedTiles[i] = tempVec[i];
                }
            }
            else{
                canGoFurther = false;
            }

        } while(canGoFurther);
    }


}

