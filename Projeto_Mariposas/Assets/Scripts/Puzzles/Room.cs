using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private Rooms room;
    [SerializeField] private GameObject[] oldFurniture;
    [SerializeField] private GameObject[] newFurniture;

    public void SwitchFurniture()
    {
        // Adicionar fade out para troca da mobilia

        for (int i = 0; i < oldFurniture.Length; i++)
        {
            oldFurniture[i].SetActive(false);
        }

        for (int i = 0; i < newFurniture.Length; i++)
        {
            newFurniture[i].SetActive(true);
        }
    }

    public Rooms GetRoom()
    {
        return this.room;
    }
}

public enum Rooms
{
    OUTSIDE,
    LIVINGROOM,
    OFFICE,
    BATHROOM,
    KITCHEN,
    BEDROOM,
    BABYROOM
}
