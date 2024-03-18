using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IrinaScript : MonoBehaviour
{
    private Animator animator;
    private SideScrollMovement PlayerMovement;
    private string curState;
    private Direction dir;

    // Animações Irina
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
        AnimatePlayer(Direction.right);
    }

    void Update()
    {
        AnimatePlayer(dir);
    }

    public void AnimatePlayer(Direction newDir){
        if(dir == newDir) return;
        
        dir = newDir;
        switch (newDir){
            case Direction.right:
                if(!PlayerMovement.GetMoved()){
                    ChangeAnimationState(PLAYER_IDLE_R); 
                }

                else if(PlayerMovement.GetMoved() && PlayerMovement.GetSpeedX() > 0){
                    ChangeAnimationState(PLAYER_WALK_R);
                }
                break;

            case Direction.left:
                if(!PlayerMovement.GetMoved()){
                    ChangeAnimationState(PLAYER_IDLE_L); 
                }

                else if(PlayerMovement.GetMoved() && PlayerMovement.GetSpeedX() < 0){
                    ChangeAnimationState(PLAYER_WALK_L);
                }
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(newDir), newDir, null);
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