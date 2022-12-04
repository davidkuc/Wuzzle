using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource music;
    void Awake()
    {
        music = transform.Find("Music").GetComponent<AudioSource>();
    }

    public void MuteAudio() => music.mute = true;
    public void MuteOffAudio() => music.mute = false;
}
