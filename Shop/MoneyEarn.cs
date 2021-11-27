using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoneyEarn : MonoBehaviour
{
    public void EarnMoney(){
        GameObject.FindGameObjectWithTag("ShopManager").GetComponent<ShopManager>().Earn_Money(); //Collect Coins
    }
}
