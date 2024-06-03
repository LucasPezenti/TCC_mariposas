using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioManager audioManager;
    public string musicName;
    void Start()
    {
        audioManager = AudioManager.GetInstance();
        audioManager.Play(musicName);
    }

    
}
