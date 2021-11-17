using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class ShakeCheck : SetActiveouo
{
    [HideInInspector] public float strength=5.0f;
    public Animator FishingRodControl;
    public UnityEvent events; //檢測到搖晃後執行(套入延時之後)
    void Start()
    {
        FishingRodControl=GetComponent<Animator>(); 
    }
    void Update()
    {
        if(Input.acceleration.y > 2.0f){ 
            FishingRodControl.SetBool("startshake",true);
            Invoke("showfish",4.0f);
            Invoke("changeScene",7.0f);
            // Debug.Log("shaked");
	    }else{
            Debug.Log("Nothing happen");
        }
        // 測試用
        if(Input.GetKey(KeyCode.RightArrow)){
            FishingRodControl.SetBool("startshake",true);
            // SceneManager.LoadScene("Congrat");
        }

    }
    public void showfish(){
        view_text.SetActive(true);
        fish.SetActive(true);
        retrybtn.SetActive(true);
    }
    public void changeScene(){
        SceneManager.LoadScene("Congrat");
    }
}
public class SetActiveouo2 : MonoBehaviour
{
    public GameObject fish; //新增那個要顯示/隱藏物體的名子
    public GameObject view_text;
    public GameObject retrybtn;
    public GameObject ImageTarget;  
    public void Active_yes() //顯示物件函數
    {
        view_text.SetActive(true);  
    }
    public void Active_no() //隱藏物件函數
    {
        fish.SetActive(false);
        retrybtn.SetActive(false); 
        view_text.SetActive(false);
    }
}