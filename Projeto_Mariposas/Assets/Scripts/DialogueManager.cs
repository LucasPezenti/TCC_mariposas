using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public UnityEngine.UI.Image charImage;
    public GameObject dialogueBox;
    public TextMeshProUGUI charName;
    public TextMeshProUGUI messageText;
    public RectTransform backgroundBox;
    Message[] curMessages;
    Actor[] curChars;
    int activeMessage = 0;
    public static bool isActive = false;

    public void OpenDialogue(Message[] messages, Actor[] actors){
        curMessages = messages;
        curChars = actors;
        activeMessage = 0;
        isActive = true;
        DisplayMessage();
        Debug.Log("Dialogue started! Number of messages: " + messages.Length);
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
            isActive = false;
            dialogueBox.SetActive(false);
            Debug.Log("Dialogue ended");
        }
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space) && isActive == true){
            NextMessage();
        }
    }

}
