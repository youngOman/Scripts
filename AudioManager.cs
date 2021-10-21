using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
    /// <summary>音樂撥放器</summary>
    public AudioSource AudioPlayer;
    /// <summary>音效撥放器</summary>
    public AudioSource SoundEffectPlayer;
    /// <summary>音樂撥放清單</summary>
    public AudioClip[] Audio;
    /// <summary>音效撥放清單</summary>
    public AudioClip[] SoundEffect;

    /// <summary>撥放音樂</summary>
    /// <param name="PlayAudioOrder">撥放第N首音樂</param>
	public void AudioPlay(int PlayAudioOrder)
    {
        AudioPlayer.clip = Audio[PlayAudioOrder];
        AudioPlayer.Play();
    }
    /// <summary>停止音樂</summary>
    public void AudioStop()
    {
        AudioPlayer.Stop();
    }
    /// <summary>撥放音效</summary>
    /// <param name="PlaySoundEffectOrder">撥放第N首音效</param>
    public void SoundEffectPlay(int PlaySoundEffectOrder)
    {
        SoundEffectPlayer.clip = SoundEffect[PlaySoundEffectOrder];
        SoundEffectPlayer.Play();
    }
    /// <summary>停止音效</summary>
    public void SoundEffectStop()
    {
        SoundEffectPlayer.Stop();
    }
    /// <summary>調整音樂音量</summary>
    /// <param name="vol">音量</param>
    public void AudioVol(float vol)
    {
        AudioPlayer.volume = vol;
    }
    /// <summary>調整音效音量</summary>
    /// <param name="vol">音量</param>
    public void SoundEffectVol(float vol)
    {
        SoundEffectPlayer.volume = vol;
    }
    /// <summary>回傳音樂音量</summary>
    public float AudioVolume()
    {
        return AudioPlayer.volume;
    }
    /// <summary>回傳音效音量</summary>
    public float SoundEffectVolume()
    {
        return SoundEffectPlayer.volume;
    }

}
