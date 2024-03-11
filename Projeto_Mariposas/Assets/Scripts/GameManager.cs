using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static event Action<GameState> OnGameStateChanged;

    public GameState State;
    
    void Awake()
    {
        Instance = this;
    }
    
    void Start()
    {
        ChangeGameState(GameState.menu);
    }

    public void ChangeGameState(GameState newState) {
        if(State == newState) return;

        State = newState;
        switch(newState){
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
}

public enum GameState {
    menu,
    cutscene,
    gameplay

}
