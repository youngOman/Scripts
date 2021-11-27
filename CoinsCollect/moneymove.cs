using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneymove : MonoBehaviour
{
    public Animator ani;
    // Start is called before the first frame update
    void Start () {
	        
	}
	
    public void primavera(){
    	this.ani.SetTrigger("Test");
    	
	}
	void Update()
	{
	    
	}
}