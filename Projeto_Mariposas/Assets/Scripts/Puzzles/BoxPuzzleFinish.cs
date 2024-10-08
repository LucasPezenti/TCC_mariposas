using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPuzzleFinish : MonoBehaviour
{
    public GameObject[] newObjects;
    public GameObject[] oldObjects;
    [SerializeField] private int boxesLeft;
    private bool boxPuzzleOver;

    void Start()
    {
        boxPuzzleOver = false;
    }

    public void FinishBoxPuzzle()
    {
        if (boxPuzzleOver)
        {
            FindObjectOfType<MissionManager>().SetMissionIndex(1);

            for (int i = 0; i < newObjects.Length; i++)
            {
                newObjects[i].SetActive(true);
            }
            for (int i = 0; i < oldObjects.Length; i++)
            {
                oldObjects[i].SetActive(false);
            }
        }
    }

    public void DeliverBox()
    {
        boxesLeft--;
        if (boxesLeft <= 0)
        {
            boxPuzzleOver = true;
            FinishBoxPuzzle();
        }
    }
}
