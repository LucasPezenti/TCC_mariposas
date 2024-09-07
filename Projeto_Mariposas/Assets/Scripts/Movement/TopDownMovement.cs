using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float speedX, speedY;
    [SerializeField] private bool moved;
    [SerializeField] private bool running;
    public static bool TDCanMove;
    [SerializeField] private bool canRun;

    private Vector2 moveDirection;
    private Rigidbody2D rb;
    private Direction dir, lastDir;


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
        
        // Verifica se o player se mexeu
        if(speedX != 0 || speedY != 0){
            moved = true;
        }

        // Player mexeu para a DIREITA
        if(speedX > 0){
            dir = Direction.right;
            lastDir = Direction.right;
        }

        // Player mexeu para a ESQUERDA
        else if(speedX < 0){
            dir = Direction.left;
            lastDir = Direction.left;
        }

        // Player mexeu para CIMA
        if(speedY > 0){
            dir = Direction.up;
            lastDir = Direction.up;
        }

        // Player mexeu para BAIXO
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

    public void StopMoving(){
        speedX = 0;
        speedY = 0;
    }

    public float GetSpeedX(){
        return this.speedX;
    }

    public float GetSpeedY(){
        return this.speedY;
    }

    public bool GetMoved(){
        return this.moved;
    }
    
    /*
    public bool GetCanMove()
    {
        return this.TDCanMove;
    }

    public void SetCanMove(bool canMove)
    {
        this.TDCanMove = canMove;
    }
    */
    public Vector2 GetMoveDirection(){
        return this.moveDirection;
    }

    public Direction GetDir(){
        return this.dir;
    }

    public Direction GetLastDir(){
        return this.lastDir;
    }

    public bool GetRunning(){
        return this.running;
    }

    public bool GetCanRun(){
        return this.canRun;
    }

    public void SetCanRun(bool run){
        this.canRun = run;
    }
}
