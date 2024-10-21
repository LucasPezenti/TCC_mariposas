using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionManager : MonoBehaviour
{
    [Header("Missions")]
    public UIElement[] missionList;
    public UIElement[] missionStepsList;
    public int missionIndex;

    [Header("UI variables")]
    [SerializeField] private Button missionBtn;
    [SerializeField] private MissionDropdown missionDropdown;
    [SerializeField] private bool isDropdownActive;
    
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = AudioManager.GetAudioInstance();
    }

    private void Start()
    { 
        missionBtn.onClick.AddListener(SwitchDropdown);
        isDropdownActive = false;
        LoadMission();
    }

    public void LoadMission()
    {
        if (System.IO.File.Exists(GameManager.GetInstance().GetUIFilePath()))
        {
            string[] lines = System.IO.File.ReadAllLines(GameManager.GetInstance().GetUIFilePath());
            foreach (string line in lines)
            {
                string[] info = line.Split('/');
                if (line.Contains(missionList[missionIndex].textID))
                {
                    missionList[missionIndex].textToDisplay.text = info[1].Trim();
                }
                if (line.Contains(missionStepsList[missionIndex].textID))
                {
                    missionStepsList[missionIndex].textToDisplay.text = info[1].Trim();
                }
            }
        }
    }

    private void SwitchDropdown()
    {
        if (!isDropdownActive)
        {
            missionDropdown.OpenDropdown();
            isDropdownActive = true;
        }
        else
        {
            missionDropdown.CloseDropdown();
            isDropdownActive = false;
        }
    }

    public void SetMissionIndex(int index)
    {
        missionIndex = index;
        LoadMission();
    }
}
