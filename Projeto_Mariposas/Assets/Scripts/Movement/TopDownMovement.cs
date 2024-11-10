using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    [SerializeField] private float speed { get; set; }
    [SerializeField] private float speedX { get; set; }
    [SerializeField] private float speedY { get; set; }
    [SerializeField] public bool moved { get; set; }
    [SerializeField] private bool running { get; set; }
    
    [SerializeField] public static bool TDCanMove;
    [SerializeField] private bool canRun;
    private Vector2 moveDirection;
    private Rigidbody2D rb;
    private HoldObjectScript holdObjectScript;
    [SerializeField] public Direction dir { get; set; }
    [SerializeField] public Direction lastDir { get; set; }


    [Header("Environment info")]
    [SerializeField] private Rooms curRoom;
    [SerializeField] private inRangeOf curInRange;
    [SerializeField] private GameObject objInRange;
    //[Header("Dialogue info")]
    //[SerializeField] private bool onDialogue;

    [Header("Interaction info")]
    [SerializeField] private InteractionAlert interactionAlert;

    [Header("Box info")]
    [SerializeField] private bool hasBox;
    [SerializeField] private PuzzleBox curBox;
    [SerializeField] private BoxPuzzleManager boxManager;
    [SerializeField] private ExamineManager examineManager;

    [Header("Inventory Info")]
    [SerializeField] private Inventory inventory;
    [SerializeField] private bool onInventory;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        holdObjectScript = GetComponent<HoldObjectScript>();
        inventory = GetComponent<Inventory>();
        boxManager = null;
        curBox = null;

    }
    // Start is called before the first frame update
    void Start()
    {
        speed = 1.4f;
        moved = false;
        running = false;

        curBox = null;
        curRoom = Rooms.OUTSIDE;
        curInRange = inRangeOf.NOTHING;

        hasBox = false;

        onInventory = false;

        TDCanMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!TDCanMove || DialogueManager.onDialogue || onInventory){
            moved = false;
            moveDirection.x = 0;
            moveDirection.y = 0;
        }
        MovementInputs();
        if (!DialogueManager.onDialogue)
        {
            InteractionInputs();
        }
    }

    void FixedUpdate(){
        Move();
    }

    private void MovementInputs(){
        if(TDCanMove && !DialogueManager.onDialogue && !onInventory){
            speedX = Input.GetAxisRaw("Horizontal");
            speedY = Input.GetAxisRaw("Vertical");

            if(canRun){
                running = false;
                if(Input.GetKey("left shift")){
                    running = true;
                }
            }

            moveDirection = new Vector2(speedX, speedY).normalized;
        }
    }

    private void InteractionInputs()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (curInRange == inRangeOf.DIALOGUE) // Show dialogue
            {
                objInRange.GetComponent<DialogueTrigger>().StartDialogue();
            }

            else if (curInRange == inRangeOf.BOX && !hasBox) // Grab box
            {
                Debug.Log("Pegou");
                GrabBox(objInRange);
                interactionAlert.TurnAlertOff();
            }

            else if (hasBox && curRoom == curBox.GetBoxRoom()) // Unpack box
            {
                Debug.Log("Sala correta");
                boxManager.Unpack(curRoom);
                hasBox = false;
                Destroy(curBox.gameObject);
                curBox = null;
            }

            else if (hasBox && curRoom != curBox.GetBoxRoom()) // Wrong place
            {
                // Dialogo de "Lugar errado"
                Debug.Log("Lugar errado");
            }

            else if (curInRange == inRangeOf.LIGHTSWITCH)
            {
                objInRange.GetComponent<LightSwitch>().SwitchLights();
                Debug.Log("Interruptor pressionado");
            }
        }

        else if (Input.GetKeyDown(KeyCode.Q))
        {
            
            // Turn Examine screen on and off
            if (hasBox && !examineManager.isExamining && !onInventory)
            {
                examineManager.DisplayItem(curBox.GetBoxImage());
            }
            else if (hasBox && examineManager.isExamining)
            {
                examineManager.CloseItemDisplay();
            }
        }

        else if (Input.GetKeyDown(KeyCode.F)) // Turn flashlight on
        {
            Debug.Log("can move = " + TDCanMove);
        }

        else if (Input.GetKeyDown(KeyCode.Tab)) // Open inventory
        {
            if (!onInventory && !examineManager.isExamining) 
            { 
                inventory.OpenInventory();
                onInventory = true;
            }

            else 
            { 
                inventory.CloseInventory();
                onInventory = false;
            }
        }
    }

    private void Move(){
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y  * speed);
        
        moved = false;
        
        // Verify if Player moved
        if(speedX != 0 || speedY != 0){
            moved = true;
        }

        // Moved RIGHT
        if(speedX > 0){
            dir = Direction.RIGHT;
            lastDir = Direction.RIGHT;
        }

        // Moved LEFT
        else if(speedX < 0){
            dir = Direction.LEFT;
            lastDir = Direction.LEFT;
        }

        // Moved UP
        if(speedY > 0){
            dir = Direction.UP;
            lastDir = Direction.UP;
        }

        // Moved DOWN
        else if(speedY < 0){
            dir = Direction.DOWN;
            lastDir = Direction.DOWN;
        }
        
        if(running){
            speed = 3.2f;
        }else{
            speed = 1.4f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Room"))
        {
            this.curRoom = collision.GetComponent<Room>().GetRoom();
            this.boxManager = collision.GetComponent<BoxPuzzleManager>();
            Debug.Log(curRoom);
        }
        else
        {
            objInRange = collision.gameObject;
        }

        if (collision.gameObject.CompareTag("Dialogue"))
        {
            //can start dialogue
            curInRange = inRangeOf.DIALOGUE;
        }
        else if (collision.gameObject.CompareTag("PickUp"))
        {
            //can carry object
            curInRange = inRangeOf.BOX;
            interactionAlert.TurnAlertOn(false);
        }
        
        else if (collision.gameObject.CompareTag("LightSwitch"))
        {
            //can turn lights on and off (basement)
            curInRange = inRangeOf.LIGHTSWITCH;
            interactionAlert.TurnAlertOn(false);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dialogue"))
        {
            curInRange = inRangeOf.NOTHING;
        }
        else if (collision.gameObject.CompareTag("PickUp"))
        {
            curInRange = inRangeOf.NOTHING;
            interactionAlert.TurnAlertOff();
        }
        else if (collision.gameObject.CompareTag("LightSwitch"))
        {
            //can turn lights on and off (basement)
            curInRange = inRangeOf.NOTHING;
            interactionAlert.TurnAlertOff();
        }

        if (collision.gameObject.CompareTag("Room"))
        {
            this.curRoom = Rooms.OUTSIDE;
            Debug.Log(curRoom);
        }

    }

    public void GrabBox(GameObject box)
    {
        holdObjectScript.PickUp(objInRange);
        curBox = box.GetComponent<PuzzleBox>();
        hasBox = true;
    }

    public void StopMoving(){
        speedX = 0;
        speedY = 0;
    }

    public Vector2 GetMoveDirection(){
        return this.moveDirection;
    }


    public bool GetHasBox()
    {
        return this.hasBox;
    }

    public bool GetOnInventory()
    {
        return this.onInventory;
    }

    public void SetTDCanMove(bool canMove)
    {
        TDCanMove = canMove;
        Debug.Log("can move = " + TDCanMove);
    }

    public void SetOnInventory(bool onInventory)
    {
        this.onInventory = onInventory;
        Debug.Log("on inventory = " + this.onInventory);
    }

    public void SetDirection(int direction)
    {
        if (direction == 2)
        {
            this.dir = Direction.DOWN;
            this.lastDir = Direction.DOWN;
        }

        else if (direction == 4)
        {
            this.dir = Direction.LEFT;
            this.lastDir = Direction.LEFT;
        }

        else if(direction == 6)
        {
            this.dir = Direction.RIGHT;
            this.lastDir = Direction.RIGHT;
        }

        else if(direction == 8)
        {
            this.dir = Direction.UP;
            this.lastDir = Direction.UP;
        }

        else
        {
            this.dir = Direction.DOWN;
            this.lastDir = Direction.DOWN;
        }
    }
}

public enum inRangeOf
{
    NOTHING,
    BOX,
    DIALOGUE,
    ITEM,
    LIGHTSWITCH
}
