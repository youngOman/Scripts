using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class ShakeCheck : MonoBehaviour
{
    public AllFish AllFishManager;
    [HideInInspector] public float strength=5.0f;
    public Animator FishingRodControl;
    public UnityEvent events; //檢測到搖晃後執行(套入延時之後)
    public GameObject view_text;
    public GameObject ImageTarget;  
    private int nowcurrent_FishID;
    private int totalFish; // 目前總魚數
    private int ObjCount=0;
    void Start()
    {
        totalFish=AllFishManager.Fishobjects.Length; //從AllFish取得魚的數量
        Debug.Log("目前有:"+totalFish+"隻魚");
        FishingRodControl=GetComponent<Animator>(); 
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow)){ 
            FishingRodControl.SetBool("startshake",true);
            Invoke("showfish",4.0f);
            Invoke("changeScene",7.0f);
            // Debug.Log("shaked");
	    }else{
            // Debug.Log("Nothing happen");
        }
        // 測試用
        // if(Input.acceleration.y > 2.0f){ 
        //     FishingRodControl.SetBool("startshake",true);
        // }

    }
    public void showfish(){
        nowcurrent_FishID=Random.Range(0, AllFishManager.Fishobjects.Length); //Fishobjects是AllFish的陣列
        ObjCount=0;  
        while(ObjCount<AllFishManager.Fishobjects.Length){
            AllFishManager.Fishobjects[ObjCount].SetActive(false);
            ObjCount+=1;
        }
        AllFishManager.Fishobjects[nowcurrent_FishID].SetActive(true);
        GetFish.instanceDataFish.numCurrentID=nowcurrent_FishID; //將目前隨機出現的魚的ID傳給GETFISH
        Debug.Log("這隻魚的ID="+nowcurrent_FishID);
        view_text.SetActive(true);
    }
    public void changeScene(){
        GetFish.instanceDataFish.GoCongrat();
    }
}
// public class SecondCLASS: MonoBehaviour
// {

// }