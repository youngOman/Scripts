using UnityEngine;
using UnityEngine.UI;
public class ButtonInfo : MonoBehaviour
{
    public int ItemID;
    public Text PriceTxt;
    public GameObject ShopManager;
    void update(){   
        PriceTxt.text=ShopManager.GetComponent<ShopManager>().ShopItems[2,ItemID].ToString();
    }
}
