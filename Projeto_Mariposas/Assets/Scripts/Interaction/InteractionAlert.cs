
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionAlert : MonoBehaviour
{
    [SerializeField] private GameObject alertObject;
    public static bool isInteractable;

    void Start(){
        isInteractable = false;
    }

    void Update(){
        if(!isInteractable){ // Se necessário, Adicionar verificação de diálogo
            alertObject.SetActive(false);
        }
        else{
            alertObject.SetActive(true);
        }
    }

}
