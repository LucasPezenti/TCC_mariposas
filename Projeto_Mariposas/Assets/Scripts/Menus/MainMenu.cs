using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    GameManager gameManager = GameManager.GetInstance();
    AudioManager audioManager = AudioManager.GetAudioInstance();

    [Header("Buttons")]
    [SerializeField] private Button newGameBtn;

    //[SerializeField] private Button resumeGameBtn;

    [SerializeField] private Button settingsBtn;
    
    [SerializeField] private Button aboutBtn;

    [SerializeField] private Button creditsBtn;

    [SerializeField] private Button quitBtn;

    [SerializeField] private Button controlsBtn;

    [SerializeField] private Button languageBtn;

    [Header("Back Buttons")]
    [SerializeField] private Button backCreditsBtn;
    [SerializeField] private Button backAboutBtn;
    [SerializeField] private Button backOptionsBtn;
    [SerializeField] private Button backLanguageBtn;
    [SerializeField] private Button backControlsBptBtn;
    [SerializeField] private Button backControlsEngBtn;

    [Header("Screens")]
    public GameObject mainScreen;
    public GameObject settingsScreen;
    public GameObject aboutScreen;
    public GameObject creditScreen;
    public GameObject controlsScreenBpt;
    public GameObject controlsScreenEng;
    public GameObject languageScreen;

    public Animator creditsAnimator;

    private void Awake(){
        newGameBtn.onClick.AddListener(StartNewGame);
        settingsBtn.onClick.AddListener(OpenSettings);
        creditsBtn.onClick.AddListener(OpenCredits);
        quitBtn.onClick.AddListener(QuitGame);
        controlsBtn.onClick.AddListener(OpenControls);
        languageBtn.onClick.AddListener(OpenLanguageSelection);
        aboutBtn.onClick.AddListener(OpenAboutScreen);

        backCreditsBtn.onClick.AddListener(BackCredits);
        backAboutBtn.onClick.AddListener(BackAbout);
        backOptionsBtn.onClick.AddListener(BackOptions);
        backLanguageBtn.onClick.AddListener(BackLanguage);
        backControlsBptBtn.onClick.AddListener(BackControlsBpt);
        backControlsEngBtn.onClick.AddListener(BackControlsEng);
    }

    public void StartNewGame(){
        audioManager.Play("ButtonFX01");
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
        audioManager.Play("ButtonFX01");
    }

    public void OpenControls()
    {
        if (gameManager.GetCurLanguage() == Languages.BPT)
        {
            controlsScreenBpt.SetActive(true);
        }

        else if(gameManager.GetCurLanguage() == Languages.ENG)
        {
            controlsScreenEng.SetActive(true);
        }
        audioManager.Play("ButtonFX01");

    }

    public void OpenLanguageSelection()
    {
        languageScreen.SetActive(true);
        audioManager.Play("ButtonFX01");
    }

    public void OpenAboutScreen()
    {
        aboutScreen.SetActive(true);
        audioManager.Play("ButtonFX01");
    }


    //  Criar tela de créditos

    public void OpenCredits(){
        creditScreen.SetActive(true);
        FindAnyObjectByType<CreditsMovement>().StartCredits();
        //creditsAnimator.SetTrigger("TriggerCredits");
        audioManager.Play("ButtonFX01");

    }

    public void QuitGame(){
        audioManager.Play("ButtonFX01");
        Debug.Log("Jogo fechado!");
        Application.Quit();
    }


    public void BackCredits()
    {
        creditScreen.SetActive(false);
        audioManager.Play("ButtonFX01");
    }

    public void BackAbout()
    {
        aboutScreen.SetActive(false);
        audioManager.Play("ButtonFX01");
    }

    public void BackOptions()
    {
        mainScreen.SetActive(true);
        settingsScreen.SetActive(false);
        audioManager.Play("ButtonFX01");
    }

    public void BackLanguage()
    {
        languageScreen.SetActive(false);
        audioManager.Play("ButtonFX01");
    }

    public void BackControlsBpt()
    {
        controlsScreenBpt.SetActive(false);
        audioManager.Play("ButtonFX01");
    }

    public void BackControlsEng()
    {
        controlsScreenEng.SetActive(false);
        audioManager.Play("ButtonFX01");
    }

}
