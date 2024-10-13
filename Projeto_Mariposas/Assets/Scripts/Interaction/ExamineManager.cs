using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExamineManager : MonoBehaviour
{
    [SerializeField] private KeyCode closeKey;

    [SerializeField] public GameObject examineBox;
    [SerializeField] public Image itemImage;
    [SerializeField] private Item curItem;
    public bool isExamining { get; set; }

    /*
    private static ExamineManager Instance;

    public static ExamineManager GetInstance()
    {
        return Instance;
    }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    */

    public void OpenItemExam(Item item){
        if(!isExamining){
            curItem = item;
            isExamining = true;
            DisplayItem();
        }
    }

    public void DisplayItem(){
        Item itemDisplay = curItem;
        //itemImage.sprite = itemDisplay.sprite;
        examineBox.SetActive(true);
        SideScrollMovement.SScanMove = false;
        TopDownMovement.TDCanMove = false;

    }

    public void CloseItemDisplay()
    {
        isExamining = false;
        examineBox.SetActive(false);
        SideScrollMovement.SScanMove = true;
        TopDownMovement.TDCanMove = true;
    }

    void Update()
    {
        //ProcessInputs();
    }

    private void ProcessInputs(){
        if(Input.GetKeyDown(closeKey)){
            CloseItemDisplay();
        }
    }
}
