using UnityEngine;
using System.Collections;

public class RodAnimation : MonoBehaviour {

    //TSM Animator組件
    public Animator anim;
    void Start()
    {
        anim =GetComponent<Animator>();
    }
    void update() //隱藏物件函數
    {
        anim.SetTrigger("Backstatic");
    }
}
        
