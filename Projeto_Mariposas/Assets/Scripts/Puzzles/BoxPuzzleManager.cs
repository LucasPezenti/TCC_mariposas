using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPuzzleManager : MonoBehaviour
{
    public GameObject[] oldFurniture;
    public GameObject[] newFurniture;
    private string boxName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }
}
