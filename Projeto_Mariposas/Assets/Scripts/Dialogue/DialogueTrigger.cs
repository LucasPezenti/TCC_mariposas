using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;
    public string dialogueID;
    public bool repeat;
    public bool areaTrigger;
    public GameObject interactionObj;

    public void StartDialogue(){
        /*
        if(!repeat){
            FindObjectOfType<DialogueManager>().OpenDialogue(messages, actors);
            interactionObj.SetActive(false);
        }else{
            FindObjectOfType<DialogueManager>().OpenDialogue(messages, actors);
        }
        */
        if(!repeat){
            FindObjectOfType<DialogueManager>().LoadDialogue(dialogueID);
            interactionObj.SetActive(false);
        }else{
            FindObjectOfType<DialogueManager>().LoadDialogue(dialogueID);
        }
    }

    public bool GetRepeat(){
        return repeat;
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(areaTrigger){
            if(other.gameObject.CompareTag("Player")){
                GetComponent<DialogueTrigger>().StartDialogue();

            }
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
    public string spritePath;
}
