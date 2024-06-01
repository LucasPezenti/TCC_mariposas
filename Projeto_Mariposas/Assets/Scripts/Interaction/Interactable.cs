using System;
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

    private bool inRange;
    [SerializeField] private KeyCode interactKey;
    [SerializeField] private UnityEvent interactAction;
    public GameObject alert;

    //[SerializeField] GameObject alertObject;

    // Update is called once per frame
    void Update()
    {
        if(inRange){
            Interact();
        }
    }

    private void Interact(){
        if(Input.GetKeyDown(interactKey)){
            TurnAlertOff();
            interactAction.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            inRange = true;
            TurnAlertOn();
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            inRange = false;
            TurnAlertOff();
        }
    }

    private void TurnAlertOn(){
        alert.SetActive(true);
    }

    private void TurnAlertOff(){
        alert.SetActive(false);
    }

    public bool GetInRange(){
        return this.inRange;
    }
}
