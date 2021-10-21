using UnityEngine;
using System.Collections;

public class AudioPlayer : MonoBehaviour {
    /// <summary>TrackStatusManager.cs</summary>
    public TrackableStatusManager TSM;
    /// <summary>AudioManager.cs</summary>
    public AudioManager AM;
    /// <summary>播放第N首音樂</summary>
    public int PlayAudioOrder;
    /// <summary>是否循環播放</summary>
    public bool Loop;
    /// <summary>是否撥放中</summary>
    private bool Playing;
    void Start()
    {
        if (Loop)
        {
            //啟動音樂撥放器循環撥放
            AM.AudioPlayer.loop = true;
        }
    }

    void Update()
    {
        //辨識目標為辨識狀態&音樂停止中
        if (TSM.Status == TrackableStatusManager.TurnStates.TRACK && !Playing)
        {
            //音樂撥放中
            Playing = true;
            //撥放音樂
            AM.AudioPlay(PlayAudioOrder);
        }
        else if (TSM.Status == TrackableStatusManager.TurnStates.LOST && Playing)
        {
            //音樂停止中
            Playing = false;
            //停止音樂
            AM.AudioStop();
        }
    }
}
