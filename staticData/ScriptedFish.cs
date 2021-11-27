using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//可以從自行點右鍵新增魚
[CreateAssetMenu(fileName ="Fish",menuName ="Scripted Objects/New Fish")] //能在unity中點右鍵創建魚
public class ScriptedFish : ScriptableObject // 不能放在GameObject上
{
    public string fish_name; //unity ScriptableObject的預設已經有name這個變數因此若要用必須new或是取不同名稱
    public int Fish_Value;
}
