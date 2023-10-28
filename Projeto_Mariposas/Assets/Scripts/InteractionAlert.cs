using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionAlert : MonoBehaviour
{
    public GameObject interactionAlert;

    public void interactOn(){
        interactionAlert.SetActive(true);
    }

    public void interactOff(){
        interactionAlert.SetActive(false);
    }
}
