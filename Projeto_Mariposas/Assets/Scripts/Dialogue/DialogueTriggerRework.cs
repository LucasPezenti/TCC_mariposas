using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class DialogueTriggerRework : MonoBehaviour
{
    public TextAsset textFileAsset;
    private Queue<string> dialogue = new Queue<string>();
    private float waitTime = 0.5f;
    private float nextTime = 0f;

    void TriggerDialogue(){
        ReadTextFile();
        FindObjectOfType<DialogueManagerRework>().StartDialogue(dialogue);
    } 

    private void ReadTextFile(){
        string txt = textFileAsset.text;
        string[] lines = txt.Split(System.Environment.NewLine.ToCharArray());

        foreach(string Line in lines){
            if(!string.IsNullOrEmpty(Line)){
                if(Line.StartsWith("[")){
                    string special = Line.Substring(0, Line.IndexOf(']') + 1);
                    string curr = Line.Substring(Line.IndexOf(']') + 1);
                    dialogue.Enqueue(special);
                    dialogue.Enqueue(curr);
                }

                else{
                    dialogue.Enqueue(Line);
                }
            }
        }
        dialogue.Enqueue("[ENDQUEUE]");
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            TriggerDialogue();
            //Debug.Log("Collision");
        }
    }

    private void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E) && nextTime < Time.timeSinceLevelLoad){
            nextTime = Time.timeSinceLevelLoad + waitTime;
            FindObjectOfType<DialogueManagerRework>().AdvanceDialogue();
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            FindObjectOfType<DialogueManagerRework>().EndDialogue();
        }
    }
}
