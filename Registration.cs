using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking; // WebRequest需要 
using UnityEngine.SceneManagement;
public class Registration : MonoBehaviour
{
    public string url="http://localhost/UnitySqlconnect/register.php";
    public InputField InputplayerID;
    public InputField InputPasswd;
    public InputField InputPlayerName;
    public Button Registerbtn;
    public Text Warningtext;
    public void CallRegister(){
        Debug.Log("Runnnn");
        StartCoroutine(Register());
        // StartCoroutine(Register("Test","123456","123"));

    }   
    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("InputplayerID",InputplayerID.text);
        form.AddField("InputPasswd",InputPasswd.text);
        form.AddField("InputPlayerName",InputPlayerName.text);
        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("連線成功");
                SceneManager.LoadScene("login");
            }
        }
    }
    public void VerifyInputs(){ //檢查帳密格式
        Registerbtn.interactable=(InputplayerID.text.Length>=8&&InputPasswd.text.Length>=8);
    }
}
