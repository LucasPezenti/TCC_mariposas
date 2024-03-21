using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnoushScript : MonoBehaviour
{
     private Animator animator;
    private TopDownMovement PlayerMovement;
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

    void Start()
    {
        animator = GetComponent<Animator>();
        PlayerMovement = GetComponent<TopDownMovement>();
    }

    void Update()
    {
        AnimatePlayer();
    }

    public void AnimatePlayer(){
         // Idle animation
        if(!PlayerMovement.GetMoved()){
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
        else if(PlayerMovement.GetMoved()){
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
