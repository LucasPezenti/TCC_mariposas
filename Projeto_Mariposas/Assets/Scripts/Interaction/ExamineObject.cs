using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamineObject : MonoBehaviour
{
    [SerializeField] private GameObject examinedObject;
    [SerializeField] private GameObject examineScreen;
    private bool isExamining;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    private void ProcessInputs(){
        
        if(Input.GetKeyDown(KeyCode.E)){
            if(!isExamining){
                examineScreen.SetActive(true);
            }
            else{
                examineScreen.SetActive(false);
            }
        }
    }
}
