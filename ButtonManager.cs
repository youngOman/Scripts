using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {
    /// <summary>模型陣列</summary>
    public GameObject[] Model;
    /// <summary>模型按鈕陣列</summary>
    public GameObject[] Button;
    /// <summary>未點擊狀態貼圖</summary>
    public Texture Up;
    /// <summary>已點擊狀態貼圖</summary>
    public Texture Down;
    /// <summary>開啟模型</summary>
    /// <param name="obj">GameObject/要開啟的模型</param> //param可新增解說
    public void ShowModel(GameObject obj)
    {
        //所有模型初始化
        ModelInit();
        //開啟模型
        obj.SetActive(true);
    }
    /// <summary>設定模型按鈕貼圖</summary>
    /// <param name="_this">GameObject/要設定的模型</param>
    public void ButtonTexture(GameObject _this)
    {
        //模型按鈕貼圖初始化
        BtnTextureInit();
        //設定模型按鈕貼圖
        _this.GetComponent<Renderer>().material.mainTexture = Down;
    }
    /// <summary>所有模型初始化</summary>
    public void ModelInit(int rotate_x = 0,int rotate_y = 0,int rotate_z = 0)
    {
        foreach (GameObject i in Model)
        {
            //關閉模型
            i.SetActive(false);
            //設定模型Y軸
            i.transform.localEulerAngles = new Vector3(rotate_x, rotate_y, rotate_z);
        }
    }
    /// <summary>設定模型按鈕貼圖</summary>
    public void BtnTextureInit()
    {
        foreach (GameObject i in Button)
        {
            //設定模型按鈕貼圖
            i.GetComponent<Renderer>().material.mainTexture = Up;
        }
    }
    /// <summary>檢查模型是否為點擊狀態</summary>
    public bool isBtnPress(GameObject _this)
    {
        return _this.GetComponent<Renderer>().material.mainTexture == Down;
    }
    // /// <summary>模型旋轉</summary>
    // /// <param name="val">float/模型旋轉參數</param>
    // public void Rotate(float val)
    // {
    //     foreach (GameObject i in Model)
    //     {
    //         if (i.activeSelf)
    //         {
    //             //模型旋轉
    //             i.transform.Rotate(Vector3.forward, Time.deltaTime * val * 100);
    //         }
    //     }
    // }
}
