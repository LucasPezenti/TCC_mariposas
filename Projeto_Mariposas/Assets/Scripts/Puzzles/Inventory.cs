using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("Inventory Splashs")]
    public GameObject inventoryObj;
    public GameObject pillsSplash;
    public GameObject insecticideSplash;
    public GameObject hammerSplash;
    public GameObject lanternOffSplash;
    public GameObject lanternOnSplash;

    [Header("Selection Settings")]
    public GameObject selection;
    public Transform[] selectionPoints;
    private int selectId;

    [Header("Lantern Settings")]
    public GameObject lanternComand;
    public GameObject lanternOnComandSplash;
    public GameObject lanternOffComandSplash;
    public GameObject lightArea;
    public GameObject darkness;
    public bool isDark;
    public bool lanternOn;
    public bool holdingLantern;

    private GameObject deadMoths;

    private bool takingPills;
    private bool usingSpray;
    public bool missionPills;

    public bool hasPills;
    public bool hasInsecticide;
    public bool hasHammer;
    public bool hasLantern;
    

    public static bool onInventory;

    // Start is called before the first frame update
    void Start()
    {
        missionPills = true;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    private void ProcessInputs()
    {
        if (!DialogueManager.onDialogue && !ExamineManager.isExamining)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (!onInventory)
                {
                    OpenInventory();
                }
                else
                {
                    CloseInventory();
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (onInventory)
                {
                    CloseInventory();
                }
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                if (hasLantern && holdingLantern) 
                { 
                    SwitchLantern();
                }
            }
        }

        if (onInventory)
        {
            if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                selectId++;
                if (selectId > 3)
                {
                    selectId = 0;
                }
                selection.transform.position = selectionPoints[selectId].transform.position;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                selectId--;
                if (selectId < 0)
                {
                    selectId = 3;
                }
                selection.transform.position = selectionPoints[selectId].transform.position;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                
                if (selectId == 0) // Tomar remédios
                {
                    TakePills();
                    CloseInventory();
                } 

                if (selectId == 3) // Pegar Lanterna
                {
                    HoldLantern();
                    CloseInventory();
                } 
            }
        }
    }

    public void OpenInventory()
    {
        onInventory = true;
        inventoryObj.SetActive(true);
        if (hasPills) { pillsSplash.SetActive(true); }
        if (hasInsecticide) { insecticideSplash.SetActive(true); }
        if (hasHammer) { hammerSplash.SetActive(true); }
        if (hasLantern)
        {
            if (lanternOn)
            {
                lanternOnSplash.SetActive(true);
                lanternOffSplash.SetActive(false);
            }
            else
            {
                lanternOffSplash.SetActive(true);
                lanternOnSplash.SetActive(false);
            }
        }
    }
    public void CloseInventory()
    {
        onInventory = false;
        inventoryObj.SetActive(false);
    }

    public void SwitchLantern()
    {
        if (lanternOn)
        {
            lanternOn = false;
            lanternOffComandSplash.SetActive(true);
            lanternOnComandSplash.SetActive(false);
            if (isDark)
            {
                lightArea.SetActive(false);
                darkness.SetActive(true);
            }
        }
        else
        {
            lanternOn = true;
            lanternOnComandSplash.SetActive(true);
            lanternOffComandSplash.SetActive(false);
            if (isDark)
            {
                lightArea.SetActive(true);
                darkness.SetActive(false);
            }
        }
    }

    public void HoldLantern()
    {
        if (hasLantern)
        {
            if (!holdingLantern)
            {
                holdingLantern = true;
            }
            else
            {
                holdingLantern = false;

            }
        }
    }

    public void TakePills()
    {
        if (hasPills)
        {
            takingPills = true;
            if (missionPills)
            {
                FindObjectOfType<TakePillsFinish>().PillsTaken();
                missionPills = false;
            }
            
        }
    }

    public void ColectPills()
    {
        hasPills = true;
    }

    public void ColectInsecticide()
    {
        hasInsecticide = true;
    }

    public void ColectHammer()
    {
        hasHammer = true;
    }

    public void ColectLantern()
    {
        hasLantern = true;
        lanternComand.SetActive(true);
        lanternOffComandSplash.SetActive(true);
    }

    public bool GetPills()
    {
        return this.hasPills;
    }

    public bool GetInsecticide()
    {
        return this.hasInsecticide;
    }

    public bool GetHammer()
    {
        return this.hasHammer;
    }

    public bool GetLantern()
    {
        return this.hasLantern;
    }

    public bool GetHoldingLantern()
    {
        return this.holdingLantern;
    }

    public bool GetLanternOn()
    {
        return this.lanternOn;
    }

    public bool GetTakingPills()
    {
        return this.takingPills;
    }

    public void SetTakingPillsOff()
    {
        this.takingPills = false;
        TopDownMovement.TDcanMove = true;
    }

    public bool GetUsingSpray()
    {
        return this.usingSpray;
    }
    public void SetSprayOff()
    {
        this.usingSpray = false;
        deadMoths.SetActive(false);
        TopDownMovement.TDcanMove = true;
    }
    public void SetSprayOn(GameObject moth)
    {
        if (hasInsecticide)
        {
            this.usingSpray = true;
            this.deadMoths = moth;
        }

    }

}
