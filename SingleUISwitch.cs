using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SingleUISwitch : MonoBehaviour {
    /// <summary>TrackableStatusManager.cs</summary>
    public TrackableStatusManager TSM;
    /// <summary>圖片狀態</summary>
    private bool CloseStatus;
    void Update()
    {
        //辨識目標為辨識狀態&圖片關閉狀態
        if (TSM.Status == TrackableStatusManager.TurnStates.TRACK && !CloseStatus)
        {
            //啟用圖片
            gameObject.GetComponent<Image>().enabled = true;
        }
        else
        {
            //關閉圖片
            gameObject.GetComponent<Image>().enabled = false;
        }
    }
    /// <summary>設定圖片狀態</summary>
    /// <param name="status">圖片狀態</param>
    public void ChangeStatus(bool status)
    {
        CloseStatus = status;
    }
}
