using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBox : Item
{
    [SerializeField] public Rooms boxRoom { get; set; }
    [SerializeField] private bool onGround;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D rb;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    public void Start()
    {
        onGround = true;
    }

    public override void Interaction()
    {
        throw new System.NotImplementedException();
    }

    private void PickUpBox(Transform holdSpot)
    {
        this.gameObject.transform.position = holdSpot.position;
        this.gameObject.transform.parent = holdSpot.transform;
        this.spriteRenderer.enabled = false;
        this.rb.simulated = false;
        onGround = false;
    }

    private void ExamineBox()
    {
        if (!onGround)
        {
            //Examine
        }
    }
}

public enum Rooms
{
    LivingRoom,
    Office,
    Bathroom,
    Kitchen,
    Bedroom,
    Babyroom
}