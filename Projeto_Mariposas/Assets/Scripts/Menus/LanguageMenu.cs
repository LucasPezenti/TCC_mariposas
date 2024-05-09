using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LanguageMenu : MonoBehaviour
{
    // Buttons
    [SerializeField] private Button PTB_Btn;
    [SerializeField] private Button ENG_Btn;
    [SerializeField] private Button confirmBtn;

    // Texts to change according to the language
    public TextMeshProUGUI selectionText;
    public TextMeshProUGUI confirmText;

    GameManager GameManager = GameManager.GetInstance();

    private void Awake(){
        PTB_Btn.onClick.AddListener(SelectPTB);
        ENG_Btn.onClick.AddListener(SelectENG);

        confirmBtn.onClick.AddListener(ConfirmSelection);
        confirmBtn.gameObject.SetActive(false);
    }
    
    public void SelectPTB(){
        GameManager.curLanguage = Languages.PTB;
        selectionText.text = "Selecione o idioma";
        confirmText.text = "Confirmar";
        confirmBtn.gameObject.SetActive(true);
        Debug.Log(GameManager.curLanguage);
    }

    public void SelectENG(){
        GameManager.curLanguage = Languages.ENG;
        selectionText.text = "Select the language";
        confirmText.text = "Confirm";
        confirmBtn.gameObject.SetActive(true);
        Debug.Log(GameManager.curLanguage);
    }

    public void ConfirmSelection(){
        SceneManager.LoadScene("MainMenu");
    }
}