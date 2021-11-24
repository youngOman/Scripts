using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//獎勵關卡的頁面要顯示從GetFish取得的ID
public class ShowFishManager : MonoBehaviour
{
    public GameObject[] objFishes;
    // public Transform SpawnPlace;
    void Start(){
        int TempID=GetFish.instanceDataFish.numCurrentID;
        Instantiate(objFishes[TempID]);
        objFishes[TempID].SetActive(true);
    }
    
}
