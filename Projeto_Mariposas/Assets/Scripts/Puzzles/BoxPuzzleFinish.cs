using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPuzzleFinish : MonoBehaviour
{
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
