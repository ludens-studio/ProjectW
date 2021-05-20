using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public Slider musicController;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        MusicMgr.GetInstance().SetBKObject(this.GetComponent<AudioSource>());
        MusicMgr.GetInstance().PlayBkMusic();
    }
    void Update(){
        if(musicController == null)
            musicController = GameObject.Find("Slider").GetComponent<Slider>();
        AudioControll(musicController);
    }

    // 音量大小控制
    public void AudioControll(Slider slider){
        float value = slider.value;
        MusicMgr.GetInstance().ChangeBKValue(value);
    }
}
