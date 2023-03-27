using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float moveSpd;
    public Rigidbody2D rb;
    public Animator animator;
    private Vector2 moveDirection;
    private Vector2 lastMoveDirection;

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        Animate();
    }

    // Physics Calculation
    void FixedUpdate(){
        Move();
    }
    
    private void ProcessInputs(){
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if((moveX == 0 && moveY == 0) && moveDirection.x != 0 || moveDirection.y != 0){
            lastMoveDirection = moveDirection;
        }

        moveDirection = new Vector2(moveX, moveY).normalized;

    }

    private void Move(){
        rb.velocity = new Vector2(moveDirection.x * moveSpd, moveDirection.y * moveSpd);
    }

    private void Animate(){
        animator.SetFloat("AnimMoveX", moveDirection.x);
        animator.SetFloat("AnimMoveY", moveDirection.y);
        animator.SetFloat("AnimMoveMagnitude", moveDirection.magnitude);
        animator.SetFloat("AnimLastMoveX", lastMoveDirection.x);
        animator.SetFloat("AnimLastMoveY", lastMoveDirection.y);
    }
}
