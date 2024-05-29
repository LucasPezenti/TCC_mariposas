using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    [Header("Buttons")]
    [SerializeField] private Button newGameBtn;

    //[SerializeField] private Button resumeGameBtn;

    //[SerializeField] private Button settingsBtn;
    
    [SerializeField] private Button aboutBtn;

    [SerializeField] private Button creditsBtn;

    [SerializeField] private Button quitBtn;

    [Header("Screens")]
    public GameObject mainScreen;
    //public GameObject settingsScreen;
    //public GameObject aboutScreen;
    public GameObject creditScreen;

    private void Awake(){
        newGameBtn.onClick.AddListener(StartNewGame);
        creditsBtn.onClick.AddListener(OpenCredits);
        quitBtn.onClick.AddListener(QuitGame);
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
    /*
    public void OpenSettings(){

    }
    */

    //  Criar tela de créditos
    
    public void OpenCredits(){
        creditScreen.SetActive(true);
        mainScreen.SetActive(false);
    }

    public void QuitGame(){
        Debug.Log("Jogo fechado!");
        Application.Quit();
    }

}
