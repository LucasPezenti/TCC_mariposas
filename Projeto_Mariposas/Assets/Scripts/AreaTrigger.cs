using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AreaTrigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            GetComponent<DialogueTrigger>().StartDialogue();
        }
    }
}
