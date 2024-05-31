using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    GameManager GameManager = GameManager.GetInstance();

    [Header("Buttons")]
    [SerializeField] private Button newGameBtn;

    //[SerializeField] private Button resumeGameBtn;

    [SerializeField] private Button settingsBtn;
    
    [SerializeField] private Button aboutBtn;

    [SerializeField] private Button creditsBtn;

    [SerializeField] private Button quitBtn;

    [SerializeField] private Button controlsBtn;

    [SerializeField] private Button languageBtn;

    [Header("Screens")]
    public GameObject mainScreen;
    public GameObject settingsScreen;
    //public GameObject aboutScreen;
    public GameObject creditScreen;
    public GameObject controlsScreenBpt;
    public GameObject controlsScreenEng;
    public GameObject languageScreen;
    public GameObject aboutScreen;

    public Animator creditsAnimator;

    private void Awake(){
        newGameBtn.onClick.AddListener(StartNewGame);
        settingsBtn.onClick.AddListener(OpenSettings);
        creditsBtn.onClick.AddListener(OpenCredits);
        quitBtn.onClick.AddListener(QuitGame);
        controlsBtn.onClick.AddListener(OpenControls);
        languageBtn.onClick.AddListener(OpenLanguageSelection);
    }

    public void StartNewGame(){
        SceneManager.LoadScene("Prologue");
    }

    // Desenvolver sistema de saves para utilizar a opção "Continuar jogo"
    /*
    public void ResumeGame(){

    }
    */

    //  Criar menu de configurações
    
    public void OpenSettings(){
        settingsScreen.SetActive(true);
        mainScreen.SetActive(false);
    }

    public void OpenControls()
    {
        if (GameManager.GetInstance().GetCurLanguage() == Languages.BPT)
        {
            controlsScreenBpt.SetActive(true);
        }

        else if(GameManager.GetInstance().GetCurLanguage() == Languages.ENG)
        {
            controlsScreenEng.SetActive(true);
        }

    }

    public void OpenLanguageSelection()
    {
        languageScreen.SetActive(true);
    }

    public void OpenAboutScreen()
    {
        aboutScreen.SetActive(true);
    }


    //  Criar tela de créditos

    public void OpenCredits(){
        creditScreen.SetActive(true);
        creditsAnimator.SetTrigger("TriggerCredits");
        
    }

    public void QuitGame(){
        Debug.Log("Jogo fechado!");
        Application.Quit();
    }

}
