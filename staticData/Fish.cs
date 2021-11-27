using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//從ScriptedFish中存取並設定魚的基本資料
public class Fish : MonoBehaviour
{
    public ScriptedFish scriptedFish;
    public Text nameText;
    public Text Fish_Value;
    public Text OnlyFishName; //在獎勵關卡只顯示魚種名稱
    void Start(){
        nameText.text="釣到"+scriptedFish.fish_name.ToString()+"啦";
        OnlyFishName.text=scriptedFish.fish_name.ToString();
        Fish_Value.text=scriptedFish.Fish_Value.ToString();
        Debug.Log("這隻價值"+scriptedFish.Fish_Value);
    }
    public void Initialize(){
        saveGameManager.fishes.Add(this); //將新增的魚加到saveGameManager的static_List裡
    }
}
