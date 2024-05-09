using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                HandleLanguage();
                break;
            case GameState.menu:
                break;
            case GameState.cutscene:
                break;
            case GameState.gameplay:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
        OnGameStateChanged?.Invoke(newState);
    }

    public void HandleLanguage(){
        if(curLanguage == Languages.PTB){
            DialogueFilePath = "Assets/Texts/Dialogues/DIAG_BPT.txt";
            UIFilePath = "Assets/Texts/UIUX/UIUX_BPT.txt";
        }

        else if(curLanguage == Languages.ENG){
            DialogueFilePath = "Assets/Texts/Dialogues/DIAG_ENG.txt";
            UIFilePath = "Assets/Texts/UIUX/UIUX_ENG.txt";
        }
    }

    public string GetDialogueFilePath(){
        return this.DialogueFilePath;
    }

    public string GetUIFilePath(){
        return this.UIFilePath;
    }
}

public enum GameState {
    language,
    menu,
    dialogue,
    cutscene,
    gameplay

}

public enum Languages{
    PTB,
    ENG
}

public enum Direction {
    right,
    left,
    up,
    down

}