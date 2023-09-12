using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public UnityEngine.UI.Image actorImage;
    public TextMeshProUGUI charName;
    public TextMeshProUGUI messageText;
    public RectTransform backgroundBox;
    Message[] curMessages;
    Actor[] curActors;
    int activeMessage = 0;

    public void OpenDialogue(Message[] messages, Actor[] actors){
        curMessages = messages;
        curActors = actors;
        activeMessage = 0;

        Debug.Log("Dialogue started! Number of messages: " + messages.Length);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
