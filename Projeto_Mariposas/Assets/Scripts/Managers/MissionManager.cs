using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionManager : MonoBehaviour
{
    public UIElement[] missionList;
    public UIElement[] missionStepsList;
    public int missionIndex;

    [SerializeField] private Animator animator;
    [SerializeField] private Button missionBtn;
    public GameObject missionStepsText;
    private bool stepsActive;

    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = AudioManager.GetAudioInstance();
    }

    private void Start()
    {
        stepsActive = false;
        missionBtn.onClick.AddListener(ShowMissionSteps);
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

    public void ShowMissionSteps()
    {
        if (!stepsActive)
        {
            animator.SetTrigger("OpenTab");
            //missionStepsText.SetActive(true);
            stepsActive = true;
        }
        else
        {
            animator.SetTrigger("CloseTab");
            //missionStepsText.SetActive(false);
            stepsActive = false;
        }
        //laudioManager.Play("ButtonFX01");
    }

    public void SetMissionIndex(int index)
    {
        missionIndex = index;
        LoadMission();
    }

    public Animator GetAnimator()
    {
        return this.animator;
    }
    public void SetAnimOver(bool isOver)
    {
        animator.SetBool("AnimIsOver", isOver);
    }
}
