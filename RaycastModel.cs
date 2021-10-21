using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RaycastModel : MonoBehaviour {
    /// <summary>TrackableStatusManager.cs</summary>
    public TrackableStatusManager TSM;
    /// <summary>AudioManager.cs</summary>
    public AudioManager AM;
    /// <summary>ButtonManager.cs</summary>
    public ButtonManager ButtonManager;
    /// <summary>是否撥放音樂</summary>
    public bool PlayAudio;
    /// <summary>是否撥放音效</summary>
    public bool PlaySoundEffect;
    /// <summary>撥放第N首音樂</summary>
    public int PlayAudioOrder;
    /// <summary>撥放第N首音效</summary>
    public int PlaySoundEffectOrder;
    /// <summary>顯示模型編號</summary>
    void Update()
    {
        //手機模式
        //點擊螢幕
        #if UNITY_EDITOR
        //PC編輯模式
        //點擊滑鼠左鍵
        if (Input.GetMouseButtonDown(0))
        {
            //雷射線初始化
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //雷射線碰撞
            RaycastHit hit;
            //雷射線碰撞到物件且碰撞到本體
            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject == this.gameObject)
            {
                //辨識目標為辨識狀態
                if (TSM.Status == TrackableStatusManager.TurnStates.TRACK)
                {
                    //ButtonManager.cs不是空值
                    if (ButtonManager != null)
                    {
                            SceneManager.LoadScene("startfishing");
                            //AudioManager.cs不是空值
                            if (AM != null)
                            {
                                //撥放音樂狀態
                                if (PlayAudio)
                                    //撥放音樂
                                    AM.AudioPlay(PlayAudioOrder);

                                //撥放音效狀態
                                if (PlaySoundEffect)
                                    //撥放音效
                                    AM.SoundEffectPlay(PlaySoundEffectOrder);
                            }
                        //}
                    }
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
                //辨識目標為辨識狀態
                if (TSM.Status == TrackableStatusManager.TurnStates.TRACK)
                {
                    //ButtonManager.cs不是空值
                    if (ButtonManager != null)
                    {
                        //本體不是點擊狀態
                        if (!ButtonManager.isBtnPress(gameObject))
                        {
                            SceneManager.LoadScene("startfishing");
                            if (AM != null)
                            {
                                //撥放音樂狀態
                                if (PlayAudio)
                                    //撥放音樂
                                    AM.AudioPlay(PlayAudioOrder);
                                //撥放音效狀態
                                if (PlaySoundEffect)
                                    //撥放音效
                                    AM.SoundEffectPlay(PlaySoundEffectOrder);
                            }
                        }
                    }
                }
            }
        } 
#endif
    }
}
