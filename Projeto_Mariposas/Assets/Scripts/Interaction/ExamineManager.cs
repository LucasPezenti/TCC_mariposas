using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExamineManager : MonoBehaviour
{
    [SerializeField] private KeyCode closeKey;

    public GameObject examineBox;
    public Image itemImage;
    private Item curItem;
    public static bool isExamining = false;

    public void OpenItemExam(Item item){
        if(!isExamining){
            curItem = item;
            isExamining = true;
            DisplayItem();
        }
    }

    public void DisplayItem(){
        Item itemDisplay = curItem;
        itemImage.sprite = itemDisplay.sprite;
        examineBox.SetActive(true);
        SideScrollMovement.SScanMove = false;
        TopDownMovement.TDcanMove = false;
    }

    void Update()
    {
        ProcessInputs();
    }

    private void ProcessInputs(){
        if(Input.GetKeyDown(closeKey)){
            isExamining = false;
            examineBox.SetActive(false);
            SideScrollMovement.SScanMove = true;
            TopDownMovement.TDcanMove = true;
        }
    }
}
