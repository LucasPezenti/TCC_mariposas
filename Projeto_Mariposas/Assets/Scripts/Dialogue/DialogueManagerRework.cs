using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManagerRework : MonoBehaviour
{
    public GameObject canvasBox;
    public TextMeshProUGUI nameBox;
    public TextMeshProUGUI textBox;

    private Queue<string> inputStream = new Queue<string>();

    public void StartDialogue(Queue<string> dialogue){
        canvasBox.SetActive(true);
        inputStream = dialogue;
        PrintDialogue();
    }

    public void AdvanceDialogue(){
        PrintDialogue();
    }

    private void PrintDialogue(){
        if(inputStream.Peek().Contains("[ENDQUEUE]")){
            inputStream.Dequeue(); // clear queue
            EndDialogue();
        }

        else if(inputStream.Peek().Contains("[ID=")){
            string name = inputStream.Peek();
            name = inputStream.Dequeue().Substring(name.IndexOf('=') + 1, name.IndexOf(']') - (name.IndexOf('=') + 1));
            nameBox.text = name;
            PrintDialogue();
        }

        else{
            textBox.text = inputStream.Dequeue();
        }
    }

    public void EndDialogue(){
        textBox.text = "";
        nameBox.text = "";
        inputStream.Clear();
        canvasBox.SetActive(false);
    }

}
