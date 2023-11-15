using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHolder : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HoldObject()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        this.transform.position = player.GetComponent<PlayerController>().holdSpot.position;
        this.transform.SetParent(player.transform);
    }
}
