using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button newGameBtn;
    public TextMeshProUGUI newGameBtnText;

    //[SerializeField] private Button resumeGameBtn;
    
    //[SerializeField] private Button settingsBtn;
    public TextMeshProUGUI settingsBtnText;
    
    //[SerializeField] private Button creditsBtn;
    public TextMeshProUGUI creditsBtnText;
    
    [SerializeField] private Button quitBtn;
    public TextMeshProUGUI quitBtnText;

    private void Awake(){
        newGameBtn.onClick.AddListener(StartNewGame);
        quitBtn.onClick.AddListener(QuitGame);
        LoadMenuTexts();
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

    public void LoadMenuTexts(){
        if(System.IO.File.Exists(GameManager.GetInstance().GetDialogueFilePath())){
            string[] lines = System.IO.File.ReadAllLines(GameManager.GetInstance().GetUIFilePath());

            foreach(string line in lines){
                string[] info = line.Split('/');
                if(line.Contains("PlayID")){
                    newGameBtnText.text = info[1].Trim();
                }
                
                if(line.Contains("OptionsID")){
                    settingsBtnText.text = info[1].Trim();
                }

                if(line.Contains("CreditsID")){
                    creditsBtnText.text = info[1].Trim();
                }

                if(line.Contains("QuitID")){
                    quitBtnText.text = info[1].Trim();
                }
            }
        }
    }
}
