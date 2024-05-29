using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageSelector : MonoBehaviour
{
    [SerializeField] private Button BPT_Btn;
    [SerializeField] private Button ENG_Btn;
    GameManager GameManager = GameManager.GetInstance();

    private void Awake()
    {
        BPT_Btn.onClick.AddListener(SelectBPT);
        ENG_Btn.onClick.AddListener(SelectENG);
    }

    public void SelectBPT()
    {
        GameManager.GetInstance().ChangeLanguage(Languages.BPT);
        FindAnyObjectByType<UIManager>().LoadUI();
    }

    public void SelectENG()
    {
        GameManager.GetInstance().ChangeLanguage(Languages.ENG);
        FindAnyObjectByType<UIManager>().LoadUI();
    }
}
