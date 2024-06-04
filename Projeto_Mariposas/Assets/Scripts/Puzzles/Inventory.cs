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

    [Header("Lantern Settings")]
    public GameObject lanternComand;
    public GameObject lanternOnComandSplash;
    public GameObject lanternOffComandSplash;
    public GameObject lightArea;
    public GameObject darkness;
    public bool isDark;
    private bool lanternOn;

    private bool hasPills;
    private bool hasInsecticide;
    private bool hasHammer;
    private bool hasLantern;
    

    public static bool onInventory;

    // Start is called before the first frame update
    void Start()
    {
        
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
                if (hasLantern) 
                { 
                    SwitchLantern();
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
        return hasPills;
    }

    public bool GetInsecticide()
    {
        return hasInsecticide;
    }

    public bool GetHammer()
    {
        return hasHammer;
    }

    public bool GetLantern()
    {
        return hasLantern;
    }

}
