using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    private Animator FishingRodControl;
    private void OntrtiggerEnter(Collider other){
        if(other.CompareTag("player")){
            FishingRodControl.SetBool("StartFish",true);
        }
    }
    private void OntrtiggerExit(Collider other){
        if(other.CompareTag("player")){
            FishingRodControl.SetBool("StartFish2",false);
        }
    }
}   
