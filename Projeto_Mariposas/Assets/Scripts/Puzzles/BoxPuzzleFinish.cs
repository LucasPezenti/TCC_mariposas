using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPuzzleFinish : MonoBehaviour
{
    public GameObject[] newObjects;
    [SerializeField] private int boxesLeft;
    private bool boxPuzzleOver;

    void Start()
    {
        boxPuzzleOver = false;
    }

    void Update()
    {
        if (boxPuzzleOver)
        {
            FindObjectOfType<MissionManager>().SetMissionIndex(1);
            for (int i = 0; i < newObjects.Length; i++)
            {
                newObjects[i].SetActive(true);
            }
        }

        if (boxesLeft <= 0)
        {
            boxPuzzleOver = true;
        }
    }

    public void DeliverBox()
    {
        boxesLeft--;
    }
}
