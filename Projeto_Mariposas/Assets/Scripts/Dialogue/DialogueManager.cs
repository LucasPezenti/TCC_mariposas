using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBox;
    public Image charImage;
    public TextMeshProUGUI charName;
    public TextMeshProUGUI messageText;

    Message[] curMessages;
    Actor[] curChars;
    int activeMessage = 0;
    public static bool onDialogue = false;

    public void OpenDialogue(Message[] messages, Actor[] actors){
        if(!onDialogue){
            curMessages = messages;
            curChars = actors;
            activeMessage = 0;
            onDialogue = true;
            //Debug.Log("Dialogue started! Number of messages: " + messages.Length);
            DisplayMessage();
        }
    }

    public void DisplayMessage(){
        Message messageDisplay = curMessages[activeMessage];
        messageText.text = messageDisplay.message;
        Actor charDisplay = curChars[messageDisplay.charId];
        charName.text = charDisplay.name;
        charImage.sprite = charDisplay.sprite;
        dialogueBox.SetActive(true);
    }

    public void NextMessage(){
        activeMessage++;
        if(activeMessage < curMessages.Length){
            DisplayMessage();
        }else{
            onDialogue = false;
            dialogueBox.SetActive(false);
            //Debug.Log("Dialogue ended");
        }
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space) && onDialogue == true){
            NextMessage();
        }
    }

}
