using System.Collections;
using System.Collections.Generic;
using UnityEngine;  
public class Test : MonoBehaviour
{
    void Start()
    {
        person me=new person();
        me.name="001";
        person girl=new person();
        girl.name="002";
        person.max1(2,3); // static 不需先宣告成物件
        present newpresent=new present("禮物",123);
        Debug.Log(newpresent);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    class person{
        public string name; //property
        public void give(present present,person to){ //method
            Debug.Log(name+"送了"+"給"+to.name);
        }
        public static int max1(int a,int b){
            int result;
            if(a>b){
                result=a;
            }else{
                result=b;
            }

            return result;
        }
        private int hp;
        public int HP{
            get{return hp;} //從讀取HP時會呼叫
            set{ //再存入數值時自動呼叫
                if (value <0) // value=存入的數值 Ex.呼叫person.HP=10時會將此數值存入value
                    hp=0; 
                else hp=value; 
            } 
        }
        // public void hurt(int decreaseHP){
        //     if(hp>=decreaseHP){
        //         hp-=decreaseHP;
        //     }else{
        //         hp=0;
        //     }
        // }
        // public int getHP(){
        //     return hp;
        // }
    }
    class present{
            public string Content;
            public int num;
        public present(string content,int number){
            Content=content;
            num=number;
        }

    }
}
