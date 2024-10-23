using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("Inventory Settings")]
    [SerializeField] private bool isOpen;

    [Header("Selection Settings")]
    [SerializeField] private GameObject selection;
    [SerializeField] private Transform[] selectionPoints;
    [SerializeField] private int selectId;

    [Header("Item Splashs")]
    [SerializeField] private GameObject inventoryObj;
    [SerializeField] private GameObject pillsSplash;
    [SerializeField] private GameObject insecticideSplash;
    [SerializeField] private GameObject hammerSplash;
    [SerializeField] private GameObject lanternOffSplash;
    [SerializeField] private GameObject lanternOnSplash;

    [Header("Item check")]
    [SerializeField] private bool hasPills;
    [SerializeField] private bool hasInsecticide;
    [SerializeField] private bool hasHammer;
    [SerializeField] private bool hasLantern;

    [Header("Triggers")]
    [SerializeField] private bool takingPills;
    [SerializeField] private bool usingSpray;
    [SerializeField] private bool missionPills;
    [SerializeField] private GameObject deadMoths;

    [Header("Lantern Settings")]
    [SerializeField] private GameObject lanternComand;
    [SerializeField] private GameObject lanternOnComandSplash;
    [SerializeField] private GameObject lanternOffComandSplash;
    [SerializeField] private GameObject lightArea;
    [SerializeField] private GameObject darkness;
    [SerializeField] private bool isDark;
    [SerializeField] private bool lanternOn;
    [SerializeField] private bool holdingLantern;

    //public static bool onInventory;

    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        missionPills = true;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    private void ProcessInputs()
    {
        
        if (!DialogueManager.onDialogue)
        {

            if (Input.GetKeyDown(KeyCode.F))
            {
                if (hasLantern && holdingLantern) 
                { 
                    SwitchLantern();
                }
            }
        }

        if (isOpen)
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
        isOpen = true;
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
        isOpen = false;
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
        TopDownMovement.TDCanMove = true;
    }

    public bool GetUsingSpray()
    {
        return this.usingSpray;
    }
    public void SetSprayOff()
    {
        this.usingSpray = false;
        deadMoths.SetActive(false);
        TopDownMovement.TDCanMove = true;
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
