using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking; // WebRequest需要 
using UnityEngine.SceneManagement;
public class Registration : MonoBehaviour
{
    public InputField InputplayerID;
    public InputField InputPasswd;
    public InputField InputPlayerName;
    public Button Registerbtn;
    public Text ErrorText;
    public void CallRegister(){
        Debug.Log("RUNNNNNNNNNNNNNNNNNNNN");
        StartCoroutine(Register("http://localhost/UnitySqlconnect/register.php", result =>{Debug.Log(result);}));
    }   
    IEnumerator Register(string url, Action<string> result){
    UnityWebRequest www = UnityWebRequest.Get(url);
    yield return www.SendWebRequest();
    if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
            if (result != null)
                result(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.data); // this log is returning the requested data. 
            if (result != null)
                result(www.downloadHandler.text);
        }
    }
    IEnumerator login(string InputplayerID,string InputPasswd,string InputPlayerName)
    {
        WWWForm form = new WWWForm();
        form.AddField("InputplayerID",InputplayerID);
        form.AddField("InputPasswd",InputPasswd);
        form.AddField("InputPlayerName",InputPlayerName);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/UnitySqlconnect/register.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
    public void VerifyInputs(){ //檢查帳密格式
        Registerbtn.interactable=(InputplayerID.text.Length>=8&&InputPasswd.text.Length>=8);
    }
    
}
