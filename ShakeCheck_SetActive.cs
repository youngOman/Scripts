using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;
public class ShakeCheck_SetActive : SetActiveouo
{
    public float strength=5.0f;
    public UnityEvent events; //檢測到搖晃後執行(套入延時之後)
    // SetActiveouo test = new SetActiveouo();
    // Vector3 curAcc = Input.acceleration; 
    void Start()
    {
        // strength=5.0f; //預設
    }
    void Update()
    {
        if(Input.acceleration.y > 3.0f){
            // ImageTarget.SetActive(true);
            view_text.SetActive(true);
            fish.SetActive(true);
            ButtonOver.SetActive(true);
            // transform.Translate(0,strength,0);
            Debug.Log("lv3");
	    }
	    else if(Input.acceleration.y > 2.0f){
            Debug.Log("lv2");
        }
        else if(Input.acceleration.y > 1.0f){
            Debug.Log("lv1");
        }
        else Debug.Log("Nothing happen");
    }
}
public class SetActiveouo : MonoBehaviour
{
    public GameObject fish; //新增那個要顯示/隱藏物體的名子
    public GameObject view_text;
    public GameObject ButtonOver;
    public GameObject ImageTarget;  
    public void Active_yes() //顯示物件函數
    {
        view_text.SetActive(true);  
    }
    public void Active_no() //隱藏物件函數
    {
       fish.SetActive(false);
    // ImageTarget.SetActive(false);
       view_text.SetActive(false);  
    }
}
