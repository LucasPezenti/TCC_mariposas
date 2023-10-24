using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, IInteractable
{

    private Rigidbody2D rb;
    private PlayerController Player;
    
    // Start is called before the first frame update
    void Start()
    {
        //Player = new PlayerController();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        this.transform.position = Player.HoldPoint.position;
        this.transform.SetParent(Player.transform);
    }
}
