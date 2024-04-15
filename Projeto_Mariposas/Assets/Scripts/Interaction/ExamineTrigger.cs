using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamineTrigger : MonoBehaviour
{
    public Item item;

    public void ExamineItem(){
        FindObjectOfType<ExamineManager>().OpenItemExam(item);
    }
}

[System.Serializable]
public class Item{
    public Sprite sprite;
    public string name;
    public string description;
}
