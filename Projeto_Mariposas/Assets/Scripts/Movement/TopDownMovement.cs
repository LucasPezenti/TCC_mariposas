using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private float speed;
    private float speedX, speedY;
    private bool running;
    private Vector2 moveDirection;
    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        speed = 1.8f;
        running = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    void FixedUpdate(){
        Move();
    }

    private void ProcessInputs(){
        speedX = Input.GetAxisRaw("Horizontal");
        speedY = Input.GetAxisRaw("Vertical");

        running = false;
        if(Input.GetKey("left shift")){
            running = true;
        }

        moveDirection = new Vector2(speedX, speedY).normalized;
    }

    private void Move(){
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y  * speed);
        if(running){
            speed = 3.2f;
        }else{
            speed = 2f;
        }
    }

    public float GetSpeedX(){
        return this.speedX;
    }

    public float GetSpeedY(){
        return this.speedY;
    }
}
