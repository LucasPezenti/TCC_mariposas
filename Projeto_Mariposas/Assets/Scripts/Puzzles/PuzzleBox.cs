using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBox : MonoBehaviour
{

    public Item item;
    public int boxID;

}

[System.Serializable]
public class Item
{
    public Sprite sprite;
    public string name;
    public string description;
}