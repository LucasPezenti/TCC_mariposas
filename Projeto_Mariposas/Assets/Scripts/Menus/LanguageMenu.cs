using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LanguageMenu : MonoBehaviour
{
    // Buttons
    [SerializeField] private Button BPT_Btn;
    [SerializeField] private Button ENG_Btn;
    [SerializeField] private Button confirmBtn;

    // Texts to change according to the language
    public TextMeshProUGUI selectionText;
    public TextMeshProUGUI confirmText;

    GameManager GameManager = GameManager.GetInstance();


    private void Log(string conteudo)
    {
        conteudo = DateTime.Now + " " + conteudo + Environment.NewLine;
        System.IO.File.AppendAllText("mariposas.log", conteudo);
    }

    private void Awake()
    {
        BPT_Btn.onClick.AddListener(SelectBPT);
        ENG_Btn.onClick.AddListener(SelectENG);

        confirmBtn.onClick.AddListener(ConfirmSelection);
        confirmBtn.gameObject.SetActive(false);
    }
    
    public void SelectBPT(){
        
        //GameManager.GetInstance().SetDialogueFilePath(Application.dataPath + "/DIAG_BPT.txt");
        //GameManager.GetInstance().SetUIFilePath(Application.dataPath + "/UIUX_BPT.txt");
        GameManager.GetInstance().ChangeLanguage(Languages.BPT);
        //Log(GameManager.GetInstance().GetDialogueFile());
        //Log(Application.dataPath);

        Debug.Log(GameManager.GetInstance().GetUIFilePath());
        selectionText.text = "Selecione o idioma";
        confirmText.text = "Confirmar";
        confirmBtn.gameObject.SetActive(true);
    }

    public void SelectENG(){
        //GameManager.GetInstance().SetDialogueFilePath(Application.dataPath + "/DIAG_ENG.txt");
        //GameManager.GetInstance().SetUIFilePath(Application.dataPath + "/UIUX_ENG.txt");
        GameManager.GetInstance().ChangeLanguage(Languages.ENG);

        selectionText.text = "Select the language";
        confirmText.text = "Confirm";
        confirmBtn.gameObject.SetActive(true);
    }

    public void ConfirmSelection(){
        SceneManager.LoadScene("MainMenu");
    }
}