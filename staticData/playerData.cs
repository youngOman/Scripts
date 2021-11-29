using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 金錢暫存區
public class playerData : MonoBehaviour
{
    public static playerData instancePlayerInfo;
    public int current_money; //[HideInInspector] 若想要預設0元的話使用這個，不然就去Inspector預設800
    public int RodID; //釣竿ID
    private void Awake(){
        if(instancePlayerInfo!=null){ //返回釣魚畫面時會將原先隨機產生物件的Destroy掉
            Destroy(gameObject);
        }else{
            instancePlayerInfo=this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
