using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnoushScript : MonoBehaviour
{
    private Animator animator;
    private TopDownMovement PlayerMovement;
    private HoldObjectScript HoldObject;
    private Inventory inventory;
    private string curState;
    private AudioManager audioManager;

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

    // Animações Anoush com lanterna
    const string PLAYER_IDLE_LANTERNON_R = "Anoush_IdleLantOnR";
    const string PLAYER_IDLE_LANTERNON_L = "Anoush_IdleLantOnL";
    const string PLAYER_IDLE_LANTERNON_U = "Anoush_IdleLantOnU";
    const string PLAYER_IDLE_LANTERNON_D = "Anoush_IdleLantOnD";
    const string PLAYER_WALK_LANTERNON_R = "Anoush_WalkLantOnR";
    const string PLAYER_WALK_LANTERNON_L = "Anoush_WalkLantOnL";
    const string PLAYER_WALK_LANTERNON_U = "Anoush_WalkLantOnU";
    const string PLAYER_WALK_LANTERNON_D = "Anoush_WalkLantOnD";
    const string PLAYER_IDLE_LANTERNOFF_R = "Anoush_IdleLantOffR";
    const string PLAYER_IDLE_LANTERNOFF_L = "Anoush_IdleLantOffL";
    const string PLAYER_IDLE_LANTERNOFF_U = "Anoush_IdleLantOffU";
    const string PLAYER_IDLE_LANTERNOFF_D = "Anoush_IdleLantOffD";
    const string PLAYER_WALK_LANTERNOFF_R = "Anoush_WalkLantOffR";
    const string PLAYER_WALK_LANTERNOFF_L = "Anoush_WalkLantOffL";
    const string PLAYER_WALK_LANTERNOFF_U = "Anoush_WalkLantOffU";
    const string PLAYER_WALK_LANTERNOFF_D = "Anoush_WalkLantOffD";

    const string PLAYER_PILLS_R = "Anoush_PillsR";
    const string PLAYER_PILLS_L = "Anoush_PillsL";
    const string PLAYER_PILLS_U = "Anoush_PillsU";
    const string PLAYER_PILLS_D = "Anoush_PillsD";

    const string PLAYER_SPRAY_R = "Anoush_SprayR";
    const string PLAYER_SPRAY_L = "Anoush_SprayL";
    const string PLAYER_SPRAY_U = "Anoush_SprayU";
    const string PLAYER_SPRAY_D = "Anoush_SprayD";

    void Start()
    {
        animator = GetComponent<Animator>();
        PlayerMovement = GetComponent<TopDownMovement>();
        HoldObject = GetComponent<HoldObjectScript>();
        inventory = GetComponent<Inventory>();
        audioManager = AudioManager.GetAudioInstance();
    }

    void Update()
    {
        AnimatePlayer();
    }

    public void AnimatePlayer(){
        // Idle animation
        if(!HoldObject.GetIsHolding() && !PlayerMovement.GetMoved()){
            audioManager.Stop("SimpleSteps");
            if (PlayerMovement.GetLastDir() == Direction.right){
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
            if (!audioManager.GetAudio("SimpleSteps").source.isPlaying)
            {
                audioManager.Play("SimpleSteps");
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
            audioManager.Stop("SimpleSteps");
            if (PlayerMovement.GetLastDir() == Direction.right){
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

        // Walking with box animation
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

            if (!audioManager.GetAudio("SimpleSteps").source.isPlaying)
            {
                audioManager.Play("SimpleSteps");
            }
        }

        // Idle with lantern off animation
        else if (inventory.GetLantern() && inventory.GetHoldingLantern() && !inventory.GetLanternOn()
                 && !PlayerMovement.GetMoved())
        {
            audioManager.Stop("SimpleSteps");
            if (PlayerMovement.GetLastDir() == Direction.right)
            {
                ChangeAnimationState(PLAYER_IDLE_LANTERNOFF_R);
            }
            else if (PlayerMovement.GetLastDir() == Direction.left)
            {
                ChangeAnimationState(PLAYER_IDLE_LANTERNOFF_L);
            }

            if (PlayerMovement.GetLastDir() == Direction.up)
            {
                ChangeAnimationState(PLAYER_IDLE_LANTERNOFF_U);
            }
            else if (PlayerMovement.GetLastDir() == Direction.down)
            {
                ChangeAnimationState(PLAYER_IDLE_LANTERNOFF_D);
            }
        }

        // Walking with lantern off animation
        else if (inventory.GetLantern() && inventory.GetHoldingLantern() && !inventory.GetLanternOn()
                 && PlayerMovement.GetMoved())
        {
            if (PlayerMovement.GetDir() == Direction.right)
            {
                ChangeAnimationState(PLAYER_WALK_LANTERNOFF_R);
            }
            else if (PlayerMovement.GetDir() == Direction.left)
            {
                ChangeAnimationState(PLAYER_WALK_LANTERNOFF_L);
            }

            if (PlayerMovement.GetDir() == Direction.up)
            {
                ChangeAnimationState(PLAYER_WALK_LANTERNOFF_U);
            }
            else if (PlayerMovement.GetDir() == Direction.down)
            {
                ChangeAnimationState(PLAYER_WALK_LANTERNOFF_D);
            }

            if (!audioManager.GetAudio("SimpleSteps").source.isPlaying)
            {
                audioManager.Play("SimpleSteps");
            }
        }

        // Idle with lantern on animation
        else if (inventory.GetLantern() && inventory.GetHoldingLantern() && inventory.GetLanternOn() 
                 && !PlayerMovement.GetMoved())
        {
            audioManager.Stop("SimpleSteps");
            if (PlayerMovement.GetLastDir() == Direction.right)
            {
                ChangeAnimationState(PLAYER_IDLE_LANTERNON_R);
            }
            else if (PlayerMovement.GetLastDir() == Direction.left)
            {
                ChangeAnimationState(PLAYER_IDLE_LANTERNON_L);
            }

            if (PlayerMovement.GetLastDir() == Direction.up)
            {
                ChangeAnimationState(PLAYER_IDLE_LANTERNON_U);
            }
            else if (PlayerMovement.GetLastDir() == Direction.down)
            {
                ChangeAnimationState(PLAYER_IDLE_LANTERNON_D);
            }
        }

        // Walking with lantern on animation
        else if (inventory.GetLantern() && inventory.GetHoldingLantern() && inventory.GetLanternOn() 
                 && PlayerMovement.GetMoved())
        {
            if (PlayerMovement.GetDir() == Direction.right)
            {
                ChangeAnimationState(PLAYER_WALK_LANTERNON_R);
            }
            else if (PlayerMovement.GetDir() == Direction.left)
            {
                ChangeAnimationState(PLAYER_WALK_LANTERNON_L);
            }

            if (PlayerMovement.GetDir() == Direction.up)
            {
                ChangeAnimationState(PLAYER_WALK_LANTERNON_U);
            }
            else if (PlayerMovement.GetDir() == Direction.down)
            {
                ChangeAnimationState(PLAYER_WALK_LANTERNON_D);
            }

            if (!audioManager.GetAudio("SimpleSteps").source.isPlaying)
            {
                audioManager.Play("SimpleSteps");
            }
        }

        // Taking pills
        if (inventory.GetPills() && inventory.GetTakingPills())
        {
            if (PlayerMovement.GetDir() == Direction.right)
            {
                ChangeAnimationState(PLAYER_PILLS_R);
            }
            else if (PlayerMovement.GetDir() == Direction.left)
            {
                ChangeAnimationState(PLAYER_PILLS_L);
            }

            if (PlayerMovement.GetDir() == Direction.up)
            {
                ChangeAnimationState(PLAYER_PILLS_U);
            }
            else if (PlayerMovement.GetDir() == Direction.down)
            {
                ChangeAnimationState(PLAYER_PILLS_D);
            }
        }

        // Using Insecticide
        if (inventory.GetInsecticide() && inventory.getUsingSpray())
        {
            Debug.Log("Using spray: " + inventory.getUsingSpray());
            if (PlayerMovement.GetDir() == Direction.right)
            {
                ChangeAnimationState(PLAYER_SPRAY_R);
            }
            else if (PlayerMovement.GetDir() == Direction.left)
            {
                ChangeAnimationState(PLAYER_SPRAY_L);
            }

            if (PlayerMovement.GetDir() == Direction.up)
            {
                ChangeAnimationState(PLAYER_SPRAY_U);
            }
            else if (PlayerMovement.GetDir() == Direction.down)
            {
                ChangeAnimationState(PLAYER_SPRAY_D);
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
