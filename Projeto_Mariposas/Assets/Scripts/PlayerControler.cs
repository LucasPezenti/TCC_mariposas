using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public Animator animator;

    Vector3 movement;
    Vector3 aim;

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        Move();
        Animate();
    }
    
    private void ProcessInputs(){
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0.0f);

        if(movement.magnitude > 1.0f){
            movement.Normalize();
        }
    }

    private void Move(){
        transform.position = transform.position + movement * Time.deltaTime;
    }
    private void Animate(){
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.magnitude);
    }
}
