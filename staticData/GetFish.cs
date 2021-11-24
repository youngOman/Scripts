using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
// 負責將隨機產生的魚的值在不同Scene之間互傳
public class GetFish : MonoBehaviour {
    public static GetFish instanceDataFish;
    public int numCurrentID;
    private void Awake(){ //會比start先執行
        if(instanceDataFish!=null){ //返回釣魚畫面時會將原先隨機產生物件的Destroy掉
            Destroy(gameObject);
        }else{
            instanceDataFish=this;
            DontDestroyOnLoad(gameObject);
        }  
    }
    public void GoBackFishing(){
        SceneManager.LoadScene("startfishing");
    }
    public void GoCongrat(){
        SceneManager.LoadScene("Congrat");
    }
}
