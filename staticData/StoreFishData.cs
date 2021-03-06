using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
// 負責將隨機產生的魚的值在不同Scene之間互傳
public class StoreFishData : MonoBehaviour {
    public static StoreFishData instanceDataFish;
    public int numCurrentID;
    public int Fish_value; //負責將獎勵關卡的錢值傳給商店
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
