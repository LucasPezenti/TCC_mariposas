using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SideScrollMovement : MonoBehaviour
{
    private float speed;
    private float speedX, speedY;
    private bool moved;
    private bool running;
    [SerializeField] private bool canMove;
    [SerializeField] private bool canRun;

    private Vector2 moveDirection;
    private Rigidbody2D rb;
    private Direction dir, lastDir;

    // Start is called before the first frame update
    void Start()
    {
        moved = false;
        speed = 1.4f;
        speedY = 0;
        running = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void ProcessInputs(){
        if(canMove){
            speedX = Input.GetAxisRaw("Horizontal");

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
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y);
    
        moved = false;

        if(speedX > 0){
            moved = true;
            dir = Direction.right;
            lastDir = Direction.right;
        }

        else if(speedX < 0){
            moved = true;
            dir = Direction.left;
            lastDir = Direction.left;
        }

        if(running){
            speed = 3.2f;
        }else{
            speed = 1.4f;
        }
        
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

    public Vector2 GetMoveDirection(){
        return this.moveDirection;
    }

    public Direction GetDir(){
        return this.dir;
    }

    public Direction GetLastDir(){
        return this.lastDir;
    }
}
