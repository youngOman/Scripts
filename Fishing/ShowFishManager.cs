using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//獎勵關卡的頁面要顯示從GetFish取得的ID
public class ShowFishManager : MonoBehaviour
{
    public GameObject[] objFishes;
    // public Transform SpawnPlace;
    void Start(){
        //得從startFishing獲得FishID後再傳至static變數再傳至TempID;
        int TempID=StoreFishData.instanceDataFish.numCurrentID;
        // Instantiate(objFishes[TempID],SpawnPlace);
        objFishes[TempID].SetActive(true);
    }
}
