using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RandowShow : MonoBehaviour
{
    public AllFish AllFishManager;
    private int totalFish;
    private int nowcurrent_FishID;
    // public Transform spawnPoint;
    // public int ObjID;  //以nowcurrent_FishID代替
    private int ObjCount=0;
    void Start(){
        totalFish=AllFishManager.Fishobjects.Length; //從AllFish取得魚的數量
        Debug.Log("目前有:"+totalFish+"隻魚");
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow)){
            nowcurrent_FishID=Random.Range(0, AllFishManager.Fishobjects.Length); //Fishobjects是AllFish的陣列
            ObjCount=0;  
            while(ObjCount<AllFishManager.Fishobjects.Length){
                AllFishManager.Fishobjects[ObjCount].SetActive(false);
                ObjCount+=1;
            }
            AllFishManager.Fishobjects[nowcurrent_FishID].SetActive(true);
            GetFish.instanceDataFish.numCurrentID=nowcurrent_FishID; //將目前隨機出現的魚的ID傳給GETFISH
            Debug.Log("這隻魚的ID="+nowcurrent_FishID);
        }   
    }
    public void GoCongrat(){
        GetFish.instanceDataFish.GoCongrat();
    }
}
// public class SecondCLASS: MonoBehaviour
// {

// }
