using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class ShakeCheck2 : SetActiveouo
{
    [HideInInspector] public float strength=5.0f;
    public Animator FishingRodControl;
    public UnityEvent events; //檢測到搖晃後執行(套入延時之後)
    void Start()
    {
        FishingRodControl=GetComponent<Animator>();
        StartCoroutine(wait_change());
    }
    IEnumerator wait_change(){
        if(Input.GetKey(KeyCode.RightArrow)){
            FishingRodControl.SetBool("startshake",true);
            yield return new WaitForSeconds(3f);
            view_text.SetActive(true);
            fish.SetActive(true);
            retrybtn.SetActive(true);
            yield return new WaitForSeconds(2f); 
            SceneManager.LoadScene("Congrat");
            // Debug.Log("shaked");
	    }else{
            Debug.Log("Nothing happen");
        }
        // 測試用
        if(Input.acceleration.y > 2.0f){  
            FishingRodControl.SetBool("startshake",true);     
        }
    }
    public void changeScene(){
        SceneManager.LoadScene("Congrat");
    }
}
public class SetActiveouo : MonoBehaviour
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
