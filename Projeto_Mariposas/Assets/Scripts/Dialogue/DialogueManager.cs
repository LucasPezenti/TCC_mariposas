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
    public string idFinal = "[ENDQUEUE]";
    public List<string> curDialogue = new List<string>();

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

    public void DisplayMessage(){
        Message messageDisplay = curMessages[activeMessage];    // Pega na lista a mensagem que será mostrada
        messageText.text = messageDisplay.message;              // Mostra a mensagem
        Actor charDisplay = curChars[messageDisplay.charId];    // Pega na lista o personagem que está falando
        charName.text = charDisplay.name;                       // Mostra o nome do personagem
        charImage.sprite = charDisplay.sprite;                  // Mostra a sprite do personagem
        dialogueBox.SetActive(true);                            // Torna a caixa de diálogo visível
    }

    //  Método novo, lendo os diálogos a partir do arquivo .txt
    public void LoadDialogue(string DialogueID){
        if(File.Exists(GameManager.GetDialogueFilePath())){
            bool startReading = false;
            idInicial = DialogueID;
            string[] lines = File.ReadAllLines(GameManager.GetDialogueFilePath());

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
                    curDialogue.Add(line);
                }
            }
        }
        else{
            Debug.Log("O arquivo não foi encontrado.");
        }
        //Debug.Log("Dialogue started! Number of messages: " + messages.Length);
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
