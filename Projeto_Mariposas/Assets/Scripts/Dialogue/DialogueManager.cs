using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Mono.Cecil.Cil;
using System.Collections.Generic;
using System.IO;

public class DialogueManager : MonoBehaviour
{
    GameManager GameManager = GameManager.GetInstance();

    public GameObject dialogueBox;
    public Image charImage;
    public TextMeshProUGUI charName;
    public TextMeshProUGUI messageText;

    public string idInicial;
    private const string idFinal = "[ENDQUEUE]";
    private const string idActor = "ActorLine";
    private const string idMessage = "MessageLine";
    //public List<string> curDialogue = new List<string>();
    public List<Message> messageList  = new List<Message>();
    public List<Actor> actorList  = new List<Actor>();

    Message[] curMessages;
    Actor[] curChars;
    int activeMessage = 0;
    public static bool onDialogue = false;

    //  Método manual, colocando os diálogos no unity pelo DialogueTrigger
    public void OpenDialogue(Message[] messages, Actor[] actors){
        if(!onDialogue){
            curMessages = messages;     // Carrega a lista de mensagens do diálogo atual
            curChars = actors;          // Carrega a lista de personagens do diálogo atual
            activeMessage = 0;          // Identificado, volta para a primmeira mensagem da lista
            onDialogue = true;          
            //Debug.Log("Dialogue started! Number of messages: " + messages.Length);
            DisplayMessage();   
        }
    }

    //  Versão manual
    /*
    public void DisplayMessage(){
        Message messageDisplay = curMessages[activeMessage];    // Pega na lista a mensagem que será mostrada
        messageText.text = messageDisplay.message;              // Mostra a mensagem
        Actor charDisplay = curChars[messageDisplay.charId];    // Pega na lista o personagem que está falando
        charName.text = charDisplay.name;                       // Mostra o nome do personagem
        //charImage.sprite = charDisplay.sprite;                  // Mostra a sprite do personagem
        dialogueBox.SetActive(true);                            // Torna a caixa de diálogo visível
    }
    */

    //  Versão com leitura de txt
    public void DisplayMessage(){
        Message messageDisplay = messageList[activeMessage];    // Pega na lista a mensagem que será mostrada
        messageText.text = messageDisplay.message;              // Mostra a mensagem
        Actor charDisplay = actorList[messageDisplay.charId];    // Pega na lista o personagem que está falando
        charName.text = charDisplay.name;                       // Mostra o nome do personagem
        charImage.sprite = Resources.Load(charDisplay.spritePath) as Sprite;
        dialogueBox.SetActive(true);
    }
    //  Método novo, lendo os diálogos a partir do arquivo .txt
    public void LoadDialogue(string DialogueID){
        if(File.Exists(GameManager.GetInstance().GetDialogueFilePath())){
            bool startReading = false;
            idInicial = DialogueID;
            string[] lines = File.ReadAllLines(GameManager.GetInstance().GetDialogueFilePath());

            foreach (string line in lines)
            {
                if (line.Contains(idInicial))
                {
                    startReading = true;
                    continue;
                    
                }
                else if (line.Contains(idFinal))
                {
                    break;
                }

                if (startReading)
                {
                    string[] info = line.Split(';');
                    if(line.Contains(idActor)){
                        actorList.Add(new Actor {name = info[1].Trim(), spritePath = info[2].Trim()}); 
                    }
                    else if(line.Contains(idMessage)){
                        messageList.Add(new Message {charId = int.Parse(info[1].Trim()), message = info[2].Trim()}); 
                        Debug.Log(messageList.Count);
                    }
                    
                    //curDialogue.Add(line);
                }
            }

            activeMessage = 0;          // Identificado, volta para a primmeira mensagem da lista
            onDialogue = true;          
            DisplayMessage();   
        }

        else{
            Debug.Log("O arquivo não foi encontrado.");
        }
    }

    public void NextMessage(){
        activeMessage++;
        if(activeMessage < messageList.Count){
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
