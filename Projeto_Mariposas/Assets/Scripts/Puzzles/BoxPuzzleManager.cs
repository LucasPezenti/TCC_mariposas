using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPuzzleManager : MonoBehaviour
{
    public GameObject[] oldFurniture;
    public GameObject[] newFurniture;
    [SerializeField] private Rooms roomID;
    [SerializeField] private Room room;
    
    [SerializeField] private BoxPuzzleFinish boxPuzzleFinish;

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

            SwitchFurniture(); // Troca moveis ativos
            boxPuzzleFinish.DeliverBox(); // Marcar parte da miss�o concluida

            // Destruir caixa na m�o do player

            // Desativar alerta de intera��o
        }

        
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
