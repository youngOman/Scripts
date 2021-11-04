using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gofishin : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TheObject;
    public GameObject FoundObject;
    public string RaycastReturn;
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
 #if UNITY_EDITOR
//         //PC編輯模式
//         //點擊滑鼠左鍵
//         if (Input.GetMouseButtonDown(0))
//         {
//             //雷射線初始化
//             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//             //雷射線碰撞
//             RaycastHit hit;
//             //雷射線碰撞到物件且碰撞到本體
//             if (Physics.Raycast(ray, out hit) && hit.transform.gameObject == this.gameObject)
//             {
//                 //辨識目標為辨識狀態
//                 if (TSM.Status == TrackableStatusManager.TurnStates.TRACK){
//                     Debug.Log("Hello");

//                 }
//             }
//         }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                   RaycastReturn = hit.collider.gameObject.name;
                    FoundObject = GameObject.Find(RaycastReturn);
                    Destroy(FoundObject);
                    SceneManager.LoadScene("startfishing");
                }
            }
        }
#elif UNITY_ANDROID || UNITY_IPHONE
        //點擊螢幕
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            //雷射線初始化
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            //雷射線碰撞
            RaycastHit hit;
            //雷射線碰撞到物件且碰撞到本體
            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject == this.gameObject)
            {
                if (hit.collider != null)
                {
                   RaycastReturn = hit.collider.gameObject.name;
                    FoundObject = GameObject.Find(RaycastReturn);
                    Destroy(FoundObject);
                    SceneManager.LoadScene("startfishing");
                }
            }
        } 
#endif
    }
}
