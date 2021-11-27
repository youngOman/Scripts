using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 儲存所有魚的FBX
public class AllFish : MonoBehaviour
{
    public GameObject[] Fishobjects;
    private GameObject CurrentObjID;
    void Start(){
        CurrentObjID=Instantiate(Fishobjects[0]);
    }
    public void Spawnfish(int FishID) {
        Destroy(CurrentObjID);
        CurrentObjID=Instantiate(Fishobjects[FishID]);
    }
}
