using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    private string curState;
//    AnimController animController;
//    [SerializeField] GameObject animCtrl;
    public float moveSpd;
    public Rigidbody2D rb;
    private Vector2 moveDirection;


    public Transform holdSpot;
    public LayerMask pickUpMask;
    public Vector3 pickDirection{ get; set; }
    public GameObject itemHolding;


    private bool moved = false;
    private bool running = false;
    private float moveX = 0;
    private float moveY = 0;
    private int right_dir = 0, left_dir = 1, up_dir = 3, down_dir = 4;
    private int dir = 4, last_dir = 4;

    // Player animations
    const string PLAYER_IDLE_D = "Anoush_Idle_D";
    const string PLAYER_IDLE_U = "Anoush_Idle_U";
    const string PLAYER_IDLE_R = "Anoush_Idle_R";
    const string PLAYER_IDLE_L = "Anoush_Idle_L";

    const string PLAYER_RUN_R = "Player_Run_R";
    const string PLAYER_RUN_L = "Player_Run_L";
    const string PLAYER_RUN_D = "Player_Run_D";
    const string PLAYER_RUN_U = "Player_Run_U";

    const string PLAYER_WALK_R = "Anoush_Walk_R";
    const string PLAYER_WALK_L = "Anoush_Walk_L";
    const string PLAYER_WALK_D = "Anoush_Walk_D";
    const string PLAYER_WALK_U = "Anoush_Walk_U";

    /*
    void Awake(){
        animController = animCtrl.GetComponent<AnimController>();
    }
    */
    void Start()
    {
        animator = GetComponent<Animator>();
        pickDirection = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        PlayerAnimation();
    }

    // Physics Calculation
    void FixedUpdate(){
        Move();
    }
    
    private void ProcessInputs(){
        if(DialogueManager.isActive == true){
           return;
        }
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        running = false;
        if(Input.GetKey("left shift")){
            running = true;
        }

        moveDirection = new Vector2(moveX, moveY).normalized;

        // Pick up direction
        if(moveDirection.sqrMagnitude > .1f){
            pickDirection = moveDirection.normalized;
        }

        if(itemHolding == null && Input.GetKeyDown(KeyCode.E)){
            PickUp();
        }
        else if(itemHolding != null && Input.GetKeyDown(KeyCode.E)){
            Release();
        }

    }

    private void Move(){
        rb.velocity = new Vector2(moveDirection.x * moveSpd, moveDirection.y * moveSpd);

        moved = false;
        if(running){
            moveSpd = 3.5f;
        }
        else{
            moveSpd = 2.4f;
        }

        // Movement direction
        if(moveX > 0){
            moved = true;
            dir = right_dir;
            last_dir = right_dir;
            holdSpot.transform.localPosition = new Vector2(0.25f, 0.45f);
            if(itemHolding != null) itemHolding.GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
        else if(moveX < 0){
            moved = true;
            dir = left_dir;
            last_dir = left_dir;
            holdSpot.transform.localPosition = new Vector2(-0.25f, 0.45f);
            if(itemHolding != null) itemHolding.GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
        if(moveY > 0){
            moved = true;
            dir = up_dir;
            last_dir = up_dir;
            holdSpot.transform.localPosition = new Vector2(0, 0.5f);
            if(itemHolding != null) itemHolding.GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
        else if(moveY < 0){
            moved = true;
            dir = down_dir;
            last_dir = down_dir;
            holdSpot.transform.localPosition = new Vector2(0, 0.25f);
            if(itemHolding != null) itemHolding.GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
        
        
    }

    private void PickUp(){
        Collider2D pickUpItem = Physics2D.OverlapCircle(transform.position + pickDirection*.5f, .3f, pickUpMask);
        if(pickUpItem){
            itemHolding = pickUpItem.gameObject;
            itemHolding.transform.position = holdSpot.position;
            itemHolding.transform.parent = holdSpot.transform;
            if(itemHolding.GetComponent<Rigidbody2D>()){
                itemHolding.GetComponent<Rigidbody2D>().simulated = false;                
            //Debug.Log("Item grabbed");
            }
        }
    }

    private void Release(){
        itemHolding.transform.position = transform.position + pickDirection * .5f;
        itemHolding.transform.parent = null;
        if(itemHolding.GetComponent<Rigidbody2D>()){
            itemHolding.GetComponent<Rigidbody2D>().simulated = true;
        }
        itemHolding = null;
        //Debug.Log("Item released");
    }

    private void PlayerAnimation(){

        // Idle animation
        if(!moved){
            if(last_dir == down_dir){
                ChangeAnimationState(PLAYER_IDLE_D);
            }
            else if(last_dir == up_dir){
                ChangeAnimationState(PLAYER_IDLE_U);
            }
            else if(last_dir == right_dir){
                ChangeAnimationState(PLAYER_IDLE_R);
            }
            else if(last_dir == left_dir){
                ChangeAnimationState(PLAYER_IDLE_L);
            }
        }

        // Walking animation
        else if(moved){
            if(dir == down_dir){
                ChangeAnimationState(PLAYER_WALK_D);
            }
            else if(dir == up_dir){
                ChangeAnimationState(PLAYER_WALK_U);
            }
            else if(dir == right_dir){
                ChangeAnimationState(PLAYER_WALK_R);
            }
            else if(dir == left_dir){
                ChangeAnimationState(PLAYER_WALK_L);
            }
        }

        // Running animation
        else if(moved && running){
            if(dir == down_dir){
                ChangeAnimationState(PLAYER_RUN_D);
            }
            else if(dir == up_dir){
                ChangeAnimationState(PLAYER_RUN_U);
            }
            else if(dir == right_dir){
                ChangeAnimationState(PLAYER_RUN_R);
            }
            else if(dir == left_dir){
                ChangeAnimationState(PLAYER_RUN_L);
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
