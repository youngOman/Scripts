using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ShopManager : MonoBehaviour
{
    public int[,] ShopItems=new int[3,4];
    private int current_coins;
    public int totalCoins;
    public Text CoinsTxt;
    public Text WarningTxt;
    void Awake(){
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        totalCoins=PlayerPrefs.GetInt("Money");
        //物件ID
        // CoinsTxt.text="Coins:"+coins.ToString();
        CoinsTxt.text="Coins:"+playerData.instancePlayerInfo.current_money.ToString();
        ShopItems[1,1]=1;
        ShopItems[1,2]=2;
        ShopItems[1,3]=3;
        //價格
        ShopItems[2,1]=299;
        ShopItems[2,2]=399;
        ShopItems[2,3]=599;
    }

    // Update is called once per frame
    public void GetMoney(){
        current_coins=800;
        playerData.instancePlayerInfo.current_money=current_coins;
        PlayerPrefs.SetInt("Money",totalCoins);
    }
    public void buy()
    {
        GameObject ButtonRef=GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject; //要在EventSystem加上Tag
        if(playerData.instancePlayerInfo.current_money>=ShopItems[2,ButtonRef.GetComponent<ButtonInfo>().ItemID]){
            playerData.instancePlayerInfo.current_money-=ShopItems[2,ButtonRef.GetComponent<ButtonInfo>().ItemID];
            CoinsTxt.text="Coins:"+playerData.instancePlayerInfo.current_money.ToString();
        }else{
            WarningTxt.text="錢不夠用!";
        }
    }
}
