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

    // Save the current language
    public static Languages curLanguage;

    private void Awake(){
        PTB_Btn.onClick.AddListener(SelectPTB);
        ENG_Btn.onClick.AddListener(SelectENG);

        confirmBtn.onClick.AddListener(ConfirmSelection);
        confirmBtn.gameObject.SetActive(false);
    }
    
    public void SelectPTB(){
        curLanguage = Languages.PTB;
        selectionText.text = "Selecione o idioma";
        confirmText.text = "Confirmar";
        confirmBtn.gameObject.SetActive(true);
        Debug.Log(curLanguage);
    }

    public void SelectENG(){
        curLanguage = Languages.ENG;
        selectionText.text = "Select the language";
        confirmText.text = "Confirm";
        confirmBtn.gameObject.SetActive(true);
        Debug.Log(curLanguage);
    }

    public void ConfirmSelection(){
        SceneManager.LoadScene("MainMenu");
    }
}

public enum Languages{
    PTB,
    ENG
}
