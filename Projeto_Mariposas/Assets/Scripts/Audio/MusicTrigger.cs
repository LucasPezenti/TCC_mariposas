using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
    private AudioManager audioManager;
    public string musicName;
    void Start()
    {
        audioManager = AudioManager.GetInstance();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioManager.Play(musicName);
        }
    }
}
