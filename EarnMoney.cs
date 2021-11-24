using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarnMoney : MonoBehaviour
{
    // Start is called before the first frame update
    public void Earn(){
        playerData.instancePlayerInfo.current_money+=200;   

    }
}
