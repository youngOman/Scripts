using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 儲存所有魚的FBX
public class AllFish : MonoBehaviour
{
    public GameObject[] Fishobjects;
    public Transform SpawnPlace;
    private GameObject CurrentObjID;
    void Start(){
        // int tempCurrentFishID=GetFish.instanceDataFish.numCurrentID; //釣完魚
        CurrentObjID=Instantiate(Fishobjects[0],SpawnPlace);
    }
    public void Spawnfish(int FishID) {
        Destroy(CurrentObjID);
        CurrentObjID=Instantiate(Fishobjects[FishID],SpawnPlace);
    }
}
