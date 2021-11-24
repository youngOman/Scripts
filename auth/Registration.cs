using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking; // WebRequest需要 
using UnityEngine.SceneManagement;
public class Registration : MonoBehaviour
{
    public string url="https://ubt.butyshop.com/htdocs/UnitySqlconnect/register.php";
    public InputField InputplayerID;
    public InputField InputPasswd;
    public InputField InputPlayerName;
    public Button Registerbtn;
    public Text Warningtext;
    public void CallRegister(){
        Debug.Log("Run");
        string newaccount=InputplayerID.text;
        string newpassword=InputPasswd.text;
        string newusername=InputPlayerName.text;
        StartCoroutine(Register(newaccount,newpassword,newusername));
        // StartCoroutine(Register("Test","123456","123"));
    }   
    IEnumerator Register(string newaccount,string newpassword,string newusername)
    {
        WWWForm form = new WWWForm();
        form.AddField("InputplayerID",newaccount);
        form.AddField("InputPasswd",newpassword);
        form.AddField("InputPlayerName",newusername);
        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            www.downloadHandler=new DownloadHandlerBuffer();
            yield return www.SendWebRequest();
            string responseText=www.downloadHandler.text;
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error); //與網頁都連線失敗
            }
            else
            {
                Debug.Log("連線成功");
                if(responseText=="1"){
                    SceneManager.LoadScene("login");
                }else{ //連線成功但登入失敗
                    Warningtext.text=responseText;
                }           
            }
        }
    }
    public void VerifyInputs(){ //檢查帳密格式
        Registerbtn.interactable=(InputplayerID.text.Length>=8&&InputPasswd.text.Length>=8);
    }
}
