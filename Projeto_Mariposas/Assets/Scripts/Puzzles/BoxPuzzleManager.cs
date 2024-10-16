using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPuzzleManager : MonoBehaviour
{
    public GameObject[] oldFurniture;
    public GameObject[] newFurniture;
    [SerializeField] private Rooms roomID;
    private GameObject playerBox;
    private bool canLeaveBox;

    [SerializeField] private Room room;

    // Start is called before the first frame update
    void Start()
    {
        roomID = room.GetRoom();
    }

    public void Unpack(Rooms boxRoom)
    {
        if (boxRoom == roomID)
        {   
            // Anima��o de fade out e adicionar novos objetos
            SwitchFurniture();
            // Destruir caixa na m�o do player

            // Desativar alerta de intera��o
        }

        /*
        playerBox = FindAnyObjectByType<HoldObjectScript>().itemHolding;
        if (playerBox != null && !DialogueManager.onDialogue && !ExamineManager.isExamining)
        {
            if(playerBox.GetComponent<PuzzleBox>().boxRoom == roomID)
            {
                playerBox.transform.position = this.transform.position;
                playerBox.transform.parent = transform;
                if (playerBox.GetComponent<Rigidbody2D>())
                {
                    playerBox.GetComponent<Rigidbody2D>().simulated = true;
                }
                FindObjectOfType<BoxPuzzleFinish>().DeliverBox();
                SwitchFurniture();
                Destroy(playerBox);
                this.gameObject.SetActive(false);
            }
        }
        */
    }

    public void SwitchFurniture()
    {
        for (int i = 0; i < oldFurniture.Length; i ++)
        {
            oldFurniture[i].SetActive(false);
            //Destroy(oldFurniture[i]);
        }

        for (int i = 0; i < newFurniture.Length; i++)
        {
            newFurniture[i].SetActive(true);
        }
    }
}
