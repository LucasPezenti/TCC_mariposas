using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IrinaScript : MonoBehaviour
{
    private Animator animator;
    private SideScrollMovement PlayerMovement;
    private string curState;

    // Animações Irina
    private bool IraWakeUP = true;
    private bool IraFall = false;
    const string PLAYER_IDLE_R = "Ira_Idle_R";
    const string PLAYER_IDLE_L = "Ira_Idle_L";
    const string PLAYER_WALK_R = "Ira_Walk_R";
    const string PLAYER_WALK_L = "Ira_Walk_L";
    const string IRINA_WAKE_UP = "Irina_WakeUp";
    const string IRINA_FALL = "Irina_LayDown";

    void Start()
    {
        animator = GetComponent<Animator>();
        PlayerMovement = GetComponent<SideScrollMovement>();
    }

    void Update()
    {
        AnimatePlayer();
    }

    public void AnimatePlayer(){
        //  Irina Waking Up
        if(IraWakeUP){
            ChangeAnimationState(IRINA_WAKE_UP);
        }

        //  Irina Fall
        else if(IraFall){
            ChangeAnimationState(IRINA_FALL);
        }
        
        //  Idle animation
        else if(!PlayerMovement.GetMoved()){
            if(PlayerMovement.GetLastDir() == Direction.right){
                ChangeAnimationState(PLAYER_IDLE_R);
            }
            else if(PlayerMovement.GetLastDir() == Direction.left){
                ChangeAnimationState(PLAYER_IDLE_L);
            }
        }

        // Walking animation
        else if(PlayerMovement.GetMoved()){
            if(PlayerMovement.GetDir() == Direction.right){
                ChangeAnimationState(PLAYER_WALK_R);
            }
            else if(PlayerMovement.GetDir() == Direction.left){
                ChangeAnimationState(PLAYER_WALK_L);
            }
        }

    }

    public void ChangeAnimationState(string newState){

        // Stop an animaiton from interrupting itself
        if(curState == newState){
            return;
        }

        animator.Play(newState);
        curState = newState;

    }
}