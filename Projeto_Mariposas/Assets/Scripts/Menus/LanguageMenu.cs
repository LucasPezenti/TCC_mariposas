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
        GameManager.GetInstance().SetDialogueFilePath("Assets/Texts/Dialogues/DIAG_BPT.txt");
        GameManager.GetInstance().SetUIFilePath("Assets/Texts/UIUX/UIUX_BPT.txt");
        selectionText.text = "Selecione o idioma";
        confirmText.text = "Confirmar";
        confirmBtn.gameObject.SetActive(true);
    }

    public void SelectENG(){
        GameManager.GetInstance().SetDialogueFilePath("Assets/Texts/Dialogues/DIAG_ENG.txt");
        GameManager.GetInstance().SetUIFilePath("Assets/Texts/UIUX/UIUX_ENG.txt");
        selectionText.text = "Select the language";
        confirmText.text = "Confirm";
        confirmBtn.gameObject.SetActive(true);
    }

    public void ConfirmSelection(){
        SceneManager.LoadScene("MainMenu");
    }
}