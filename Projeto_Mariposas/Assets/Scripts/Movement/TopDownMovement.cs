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
    
    public static bool TDCanMove;
    [SerializeField] private bool canRun { get; set; }

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

    [Header("Box info")]
    [SerializeField] private bool hasBox;
    [SerializeField] private GameObject curBox;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        holdObjectScript = GetComponent<HoldObjectScript>();
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

        TDCanMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!TDCanMove || DialogueManager.onDialogue){
            moved = false;
            moveDirection.x = 0;
            moveDirection.y = 0;
        }
        MovementInputs();   
    }

    void FixedUpdate(){
        Move();
    }

    private void MovementInputs(){
        if(TDCanMove && !DialogueManager.onDialogue && !Inventory.onInventory){
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
            if (curInRange == inRangeOf.DIALOGUE)
            {
                objInRange.GetComponent<DialogueTrigger>().StartDialogue();
            }

            else if (curInRange == inRangeOf.BOX)
            {
                holdObjectScript.PickUp(objInRange);
                hasBox = true;
                curBox = objInRange;
            }

            else if (curInRange == inRangeOf.POI)
            {

            }
        }

        else if (Input.GetKeyDown(KeyCode.Q))
        {

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
            dir = Direction.right;
            lastDir = Direction.right;
        }

        // Moved LEFT
        else if(speedX < 0){
            dir = Direction.left;
            lastDir = Direction.left;
        }

        // Moved UP
        if(speedY > 0){
            dir = Direction.up;
            lastDir = Direction.up;
        }

        // Moved DOWN
        else if(speedY < 0){
            dir = Direction.down;
            lastDir = Direction.down;
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
        }
        /*
        else if (collision.gameObject.CompareTag("Collect"))
        {
            //can collect item
        }
        */
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
        }

        if (collision.gameObject.CompareTag("Room"))
        {
            this.curRoom = Rooms.OUTSIDE;
            Debug.Log(curRoom);
        }
    }

    public void StopMoving(){
        speedX = 0;
        speedY = 0;
    }

    public Vector2 GetMoveDirection(){
        return this.moveDirection;
    }

}

public enum inRangeOf
{
    NOTHING,
    BOX,
    DIALOGUE,
    ITEM,
    POI //Point of Interest
}
