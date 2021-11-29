using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ShakeCheck : MonoBehaviour
{
    [Header("Manager")]
    [SerializeField] AllFish AllFishManager;
    [HideInInspector] public float strength=5.0f;
    [Header("Animator")]
    public Animator FishingRodControl;
    // public Text view_text;
    [Header("ImageTarget")]
    public GameObject ImageTarget;
    private int nowcurrent_FishID;
    private int totalFish; // 目前總魚數
    private int ObjCount=0;
    private UnityEvent events; //檢測到搖晃後執行(套入延時之後)
    void Start()
    {
        // Debug.Log(playerData.instancePlayerInfo.RodID);
        int TempID=playerData.instancePlayerInfo.RodID; //從商店選的釣竿
        AllFishManager.objRods[TempID-1].SetActive(true); //Debug用
        totalFish=AllFishManager.Fishobjects.Length; //從AllFish取得魚的數量
        Debug.Log("目前有:"+totalFish+"隻魚");
        FishingRodControl=GetComponent<Animator>();
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow)){
            FishingRodControl.SetBool("startshake",true);
            Invoke("showfish",1.0f);
            Invoke("changeScene",2.0f);
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
        Debug.Log(nowcurrent_FishID);
        ObjCount=0;
        while(ObjCount<AllFishManager.Fishobjects.Length){
            AllFishManager.Fishobjects[ObjCount].SetActive(false); //先把全部物件設成false
            ObjCount+=1;
        }
        AllFishManager.Fishobjects[nowcurrent_FishID].SetActive(true);
        // Instantiate(AllFishManager.Fishobjects[nowcurrent_FishID]);
        StoreFishData.instanceDataFish.numCurrentID=nowcurrent_FishID; //將目前隨機出現的魚的ID傳給StoreFishData
        // Debug.Log("這隻魚的ID="+nowcurrent_FishID);
       
        // view_text.gameObject.SetActive(true);   
    }
    public void changeScene(){
        StoreFishData.instanceDataFish.GoCongrat();
    }
}
// public class SecondCLASS: MonoBehaviour
// {

// }