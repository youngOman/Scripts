using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 金錢暫存區
public class playerData : MonoBehaviour
{
    public static playerData instancePlayerInfo;
    public int current_money;
    private void Awake(){
        instancePlayerInfo=this;
    }
}
