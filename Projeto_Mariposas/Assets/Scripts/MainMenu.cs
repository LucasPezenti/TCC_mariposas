using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button newGameBtn;
    //[SerializeField] private Button resumeGameBtn;
    //[SerializeField] private Button settingsBtn;
    //[SerializeField] private Button creditsBtn;
    [SerializeField] private Button quitBtn;

    private void Awake(){
        newGameBtn.onClick.AddListener(StartNewGame);

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
    /*
    public void OpenCredits(){

    }
    */

    public void QuitGame(){
        Debug.Log("Jogo fechado!");
        Application.Quit();
    }
}
