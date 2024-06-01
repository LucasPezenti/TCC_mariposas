using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    //public Message[] messages;
    //public Actor[] actors;
    public string startDialogueID;
    public string endDialogueID;
    public bool repeat;
    public bool areaTrigger;
    public GameObject interactionObj;
    private bool inRange;

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
            FindObjectOfType<DialogueManager>().LoadDialogue(startDialogueID, endDialogueID);
            interactionObj.SetActive(false);
        }else{
            FindObjectOfType<DialogueManager>().LoadDialogue(startDialogueID, endDialogueID);
        }
    }

    public bool GetRepeat(){
        return repeat;
    }

    void Update()
    {
        if (inRange)
        {
            if (Input.GetKey(KeyCode.E))
            {
                StartDialogue();
                TurnDialogueAlertOff();
            }
        }            
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(areaTrigger){
            if(other.gameObject.CompareTag("Player")){
                inRange = true;
                StartDialogue();
            }
        }
        else
        {
            if (other.gameObject.CompareTag("Player"))
            {
                inRange = true;
                TurnDialogueAlertOn();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        inRange = false;

        if (!areaTrigger)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                TurnDialogueAlertOff();
            }
        }
    }

    public void TurnDialogueAlertOn()
    {
        interactionObj.SetActive(true);
    }

    public void TurnDialogueAlertOff()
    {
        interactionObj.SetActive(false);
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
    public int spriteId;
}
