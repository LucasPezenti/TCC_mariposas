using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

interface IInteractable{
    public void Interact();
}

public class Interactable : MonoBehaviour
{

    public bool inRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;

    // Update is called once per frame
    void Update()
    {
        if(inRange){
            if(Input.GetKeyDown(interactKey)){
                interactAction.Invoke();
            }
        }    
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            inRange = true;
            other.gameObject.GetComponent<InteractionAlert>().interactOn();
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            inRange = false;
            other.gameObject.GetComponent<InteractionAlert>().interactOff();
        }
    }
}
