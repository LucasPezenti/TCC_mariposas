using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExamineManager : MonoBehaviour
{
    [SerializeField] private KeyCode closeKey;

    public GameObject examineBox;
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI descriptionText;
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
        itemName.text = itemDisplay.name;
        itemImage.sprite = itemDisplay.sprite;
        descriptionText.text = itemDisplay.description;
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
