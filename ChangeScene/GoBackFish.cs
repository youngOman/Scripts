﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoBackFish : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
     public void LoadtoFishing(){
      GetFish.instanceDataFish.GoBackFishing();
    }
}
