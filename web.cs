using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
 
public class web : MonoBehaviour {
    void Start() {
        Debug.Log("run ma routine");
        StartCoroutine(GetText("http://localhost/UnitySqlconnect/register.php", result =>{Debug.Log(result);}));
    }
    IEnumerator GetText(string url, Action<string> result){
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
}
