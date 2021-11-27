﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ShopManager : MonoBehaviour
{
    public int[,] ShopItems=new int[3,4];
    [SerializeField] public int current_money;
    public Text CoinsTxt; // 目前金錢
    public Text WarningTxt;
    void Awake(){ //將獲得的錢帶入別的Scene
        DontDestroyOnLoad(this.gameObject);
    } 
    void Start()
    {
        //物件ID
        // CoinsTxt.text="Coins:"+coins.ToString();
        CoinsTxt.text="Coins:"+playerData.instancePlayerInfo.current_money.ToString(); //從playeData取得靜態變數current_money
        PlayerPrefs.GetInt("Money");
        ShopItems[1,1]=1;
        ShopItems[1,2]=2;
        ShopItems[1,3]=3;
        //價格
        ShopItems[2,1]=299;
        ShopItems[2,2]=399;
        ShopItems[2,3]=599;
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
    public void Earn_Money(){
        current_money=200;
        playerData.instancePlayerInfo.current_money+=current_money;
        PlayerPrefs.SetInt("Money",playerData.instancePlayerInfo.current_money);
    }
}
