using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking; // WebRequest需要 
using UnityEngine.SceneManagement;
public class Login : MonoBehaviour
{   
    public string url="https://ubt.butyshop.com/htdocs/UnitySqlconnect/login.php";
    public InputField InputplayerID;
    public InputField InputPasswd;
    public Button loginbtn;
    public Text warningText;
    public void Call_login(){
        Debug.Log("RUNNNNNN");
        string username=InputplayerID.text;
        string password=InputPasswd.text;
        StartCoroutine(login(username,password)); 
    }   
    IEnumerator login(string username,string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("InputplayerID",username);
        form.AddField("InputPasswd",password);
        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            www.downloadHandler=new DownloadHandlerBuffer();
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError){
                Debug.Log(www.error);
            }else{  
                Debug.Log("連線Mysql成功");
                string responseText=www.downloadHandler.text;
                if(responseText=="1"){
                    // PlayerPrefs.SetString("accountusername",username);
                    SceneManager.LoadScene("MainMenu");
                }else{
                    warningText.text="登入失敗!";
                }
                warningText.text=responseText;
                // Debug.Log(responseText);
                // warning.gameObject.SetActive(true);
            }   
        }
    }
    public void VerifyInputs(){ //檢查帳密格式
        loginbtn.interactable=(InputplayerID.text.Length>=8&&InputPasswd.text.Length>=8);
        // if(string.IsNullOrEmpty(InputplayerID.text))
    }
    public void LoadtoRegister(){
      SceneManager.LoadScene("register");
    }
}
