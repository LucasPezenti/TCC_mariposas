using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager Instance;

    public static event Action<GameState> OnGameStateChanged;
    public GameState State;


    // Language variables 
    // Save the current language
    public static Languages curLanguage;
    private string DialogueFilePath;
    private string UIFilePath;
    
    public static GameManager GetInstance(){
        return Instance;
    }

    void Awake()
    {
        if(Instance != null){
            Destroy(gameObject);
        }

        else{
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    void Start()
    {
        ChangeGameState(GameState.language);
    }

    public void ChangeGameState(GameState newState) {
        if(State == newState) return;

        State = newState;
        switch(newState){
            case GameState.language:
                SceneManager.LoadScene("LanguageSelection");
                break;
            case GameState.menu:
                SceneManager.LoadScene("MainMenu");
                break;
            case GameState.prologue:
                SceneManager.LoadScene("Prologue");
                break;
            case GameState.chapter1:
                SceneManager.LoadScene("Chapter1");
                break;
            case GameState.testePuzzle:
                SceneManager.LoadScene("TestePuzzle");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
        OnGameStateChanged?.Invoke(newState);
    }

    public string GetDialogueFilePath(){
        return this.DialogueFilePath;
    }

    public string GetUIFilePath(){
        return this.UIFilePath;
    }

    public void SetDialogueFilePath(string path){
        this.DialogueFilePath = path;
    }

    public void SetUIFilePath(string path){
        this.UIFilePath = path;
    }
}

public enum GameState {
    language,
    menu,
    prologue,
    chapter1,
    testePuzzle

}

public enum Languages{
    BPT,
    ENG
}

public enum Direction {
    right,
    left,
    up,
    down

}