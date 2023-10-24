using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
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
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            inRange = false;
        }
    }
}
