using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMusic : MonoBehaviour
{
    public AudioSource music;
    public void PlayMusic(){
        music.enabled = true;
    }
    public void StopMusic(){
        music.enabled = false;
    }
}
