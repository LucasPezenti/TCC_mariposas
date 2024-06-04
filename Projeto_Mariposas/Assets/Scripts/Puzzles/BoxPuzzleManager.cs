using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPuzzleManager : MonoBehaviour
{
    public GameObject[] oldFurniture;
    public GameObject[] newFurniture;
    [SerializeField] private int roomID;
    private GameObject playerBox;
    private bool canLeaveBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Unpack()
    {
        playerBox = FindAnyObjectByType<HoldObjectScript>().itemHolding;
        if (playerBox != null)
        {
            if(playerBox.GetComponent<PuzzleBox>().boxID == roomID)
            {
                playerBox.transform.position = this.transform.position;
                playerBox.transform.parent = transform;
                if (playerBox.GetComponent<Rigidbody2D>())
                {
                    playerBox.GetComponent<Rigidbody2D>().simulated = true;
                }
                SwitchFurniture();
                Destroy(playerBox);
                this.gameObject.SetActive(false);
            }
        }
    }

    public void SwitchFurniture()
    {
        for (int i = 0; i < oldFurniture.Length; i ++)
        {
            oldFurniture[i].SetActive(false);
        }

        for (int i = 0; i < newFurniture.Length; i++)
        {
            newFurniture[i].SetActive(true);
        }
    }
}
