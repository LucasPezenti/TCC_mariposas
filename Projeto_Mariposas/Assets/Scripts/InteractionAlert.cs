using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionAlert : MonoBehaviour
{
    [SerializeField] GameObject interactionAlert;
    public static bool alert;

    void Start(){
        alert = false;
    }

    void Update(){
        if(!alert){
            interactionAlert.SetActive(false);
        }
        else{
            interactionAlert.SetActive(true);
        }
    }

    public void interactOn(){
        alert = true;
    }

    public void interactOff(){
        alert =false;
    }
}
