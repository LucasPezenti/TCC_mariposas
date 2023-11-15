using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;
    public bool repeat;
    public GameObject interaction;

    public void StartDialogue(){
        if(!repeat){
            FindObjectOfType<DialogueManager>().OpenDialogue(messages, actors);
            interaction.SetActive(false);
        }else{
            FindObjectOfType<DialogueManager>().OpenDialogue(messages, actors);
        }
    }
}

[System.Serializable]
public class Message{
    public int charId;
    public string message;
}

[System.Serializable]
public class Actor{
    public string name;
    public Sprite sprite;
}
