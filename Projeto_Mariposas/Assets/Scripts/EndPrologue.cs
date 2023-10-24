using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class EndPrologue : MonoBehaviour, IInteractable
{
    [SerializeField] private PlayableDirector director;

    public void Interact()
    {
        PlayCutscene();
    }

    public void PlayCutscene(){
        director.Play();
    }
    
}
