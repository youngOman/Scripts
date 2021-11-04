using UnityEngine;
using System.Collections;

public class AnimationManager : MonoBehaviour {

    //TSM Animator組件
    private Animator anim;
    void Start()
    {
        anim =GetComponent<Animator>();
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow)){
            anim.SetBool("startshake1",true);
        }
    }
}
        
