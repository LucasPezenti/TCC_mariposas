using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private Rooms room;

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
