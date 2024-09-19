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
    [SerializeField] public Direction dir { get; set; }
    [SerializeField] public Direction lastDir { get; set; }

    [SerializeField] private Rooms curRoom;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        speed = 1.4f;
        moved = false;
        running = false;
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

        if (collision.gameObject.CompareTag("Dialogue"))
        {
            //can start dialogue
        }

        else if (collision.gameObject.CompareTag("Carry"))
        {
            //can pick up object
        }

        else if (collision.gameObject.CompareTag("Collect"))
        {
            //can collect item
        }

        if (collision.gameObject.CompareTag("Room"))
        {
            this.curRoom = collision.GetComponent<Room>().GetRoom();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }

    public void StopMoving(){
        speedX = 0;
        speedY = 0;
    }

    public Vector2 GetMoveDirection(){
        return this.moveDirection;
    }

}
