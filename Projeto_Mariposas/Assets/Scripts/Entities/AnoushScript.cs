using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnoushScript : MonoBehaviour
{
    private Animator animator;
    private TopDownMovement PlayerMovement;
    private HoldObjectScript HoldObject;
    private string curState;

    // Animações Anoush
    const string PLAYER_IDLE_R = "Anoush_IdleR";
    const string PLAYER_IDLE_L = "Anoush_IdleL";
    const string PLAYER_IDLE_U = "Anoush_IdleU";
    const string PLAYER_IDLE_D = "Anoush_IdleD";
    const string PLAYER_WALK_R = "Anoush_WalkR";
    const string PLAYER_WALK_L = "Anoush_WalkL";
    const string PLAYER_WALK_U = "Anoush_WalkU";
    const string PLAYER_WALK_D = "Anoush_WalkD";

    const string PLAYER_RUN_R = "Anoush_RunR";
    const string PLAYER_RUN_L = "Anoush_RunL";
    const string PLAYER_RUN_U = "Anoush_RunU";
    const string PLAYER_RUN_D = "Anoush_RunD";

    // Animações Anoush com caixa
    const string PLAYER_IDLE_BOX_R = "Anoush_IdleBoxR";
    const string PLAYER_IDLE_BOX_L = "Anoush_IdleBoxL";
    const string PLAYER_IDLE_BOX_U = "Anoush_IdleBoxU";
    const string PLAYER_IDLE_BOX_D = "Anoush_IdleBoxD";
    const string PLAYER_WALK_BOX_R = "Anoush_WalkBoxR";
    const string PLAYER_WALK_BOX_L = "Anoush_WalkBoxL";
    const string PLAYER_WALK_BOX_U = "Anoush_WalkBoxU";
    const string PLAYER_WALK_BOX_D = "Anoush_WalkBoxD";

    void Start()
    {
        animator = GetComponent<Animator>();
        PlayerMovement = GetComponent<TopDownMovement>();
        HoldObject = GetComponent<HoldObjectScript>();
    }

    void Update()
    {
        AnimatePlayer();
    }

    public void AnimatePlayer(){
        // Idle animation
        if(!HoldObject.GetIsHolding() && !PlayerMovement.GetMoved()){
            if(PlayerMovement.GetLastDir() == Direction.right){
                ChangeAnimationState(PLAYER_IDLE_R);
            }
            else if(PlayerMovement.GetLastDir() == Direction.left){
                ChangeAnimationState(PLAYER_IDLE_L);
            }

            if(PlayerMovement.GetLastDir() == Direction.up){
                ChangeAnimationState(PLAYER_IDLE_U);
            }
            else if(PlayerMovement.GetLastDir() == Direction.down){
                ChangeAnimationState(PLAYER_IDLE_D);
            }
        }

        // Walking animation
        else if(!HoldObject.GetIsHolding() && PlayerMovement.GetMoved()){
            if(PlayerMovement.GetDir() == Direction.right){
                ChangeAnimationState(PLAYER_WALK_R);
            }
            else if(PlayerMovement.GetDir() == Direction.left){
                ChangeAnimationState(PLAYER_WALK_L);
            }

            if(PlayerMovement.GetDir() == Direction.up){
                ChangeAnimationState(PLAYER_WALK_U);
            }
            else if(PlayerMovement.GetDir() == Direction.down){
                ChangeAnimationState(PLAYER_WALK_D);
            }
        }

        // Running animation
        else if(!HoldObject.GetIsHolding() && PlayerMovement.GetMoved() && PlayerMovement.GetRunning()){
            if(PlayerMovement.GetDir() == Direction.right){
                ChangeAnimationState(PLAYER_RUN_R);
            }
            else if(PlayerMovement.GetDir() == Direction.left){
                ChangeAnimationState(PLAYER_RUN_L);
            }

            if(PlayerMovement.GetDir() == Direction.up){
                ChangeAnimationState(PLAYER_RUN_U);
            }
            else if(PlayerMovement.GetDir() == Direction.down){
                ChangeAnimationState(PLAYER_RUN_D);
            }
        }

        // Idle with box animation
        else if(HoldObject.GetIsHolding() && !PlayerMovement.GetMoved()){
            if(PlayerMovement.GetLastDir() == Direction.right){
                ChangeAnimationState(PLAYER_IDLE_BOX_R);
            }
            else if(PlayerMovement.GetLastDir() == Direction.left){
                ChangeAnimationState(PLAYER_IDLE_BOX_L);
            }

            if(PlayerMovement.GetLastDir() == Direction.up){
                ChangeAnimationState(PLAYER_IDLE_BOX_U);
            }
            else if(PlayerMovement.GetLastDir() == Direction.down){
                ChangeAnimationState(PLAYER_IDLE_BOX_D);
            }
        }

        // Walking animation
        else if(HoldObject.GetIsHolding() && PlayerMovement.GetMoved()){
            if(PlayerMovement.GetDir() == Direction.right){
                ChangeAnimationState(PLAYER_WALK_BOX_R);
            }
            else if(PlayerMovement.GetDir() == Direction.left){
                ChangeAnimationState(PLAYER_WALK_BOX_L);
            }

            if(PlayerMovement.GetDir() == Direction.up){
                ChangeAnimationState(PLAYER_WALK_BOX_U);
            }
            else if(PlayerMovement.GetDir() == Direction.down){
                ChangeAnimationState(PLAYER_WALK_BOX_D);
            }
        }
    }

    public void ChangeAnimationState(string newState){

        // Impede que a animação interrompa a si mesma
        if(curState == newState){
            return;
        }

        animator.Play(newState);
        curState = newState;

    }
}
