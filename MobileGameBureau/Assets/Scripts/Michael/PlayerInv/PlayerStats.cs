using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float earnedXP;
    public float playtime;
    public float levelsCompleted;
    public float deliveredPost;
    public float ownedVehicles;
    public float vehiclesUsed;

    [Header("Objects")]
    public List<GameObject> vehiclesList;
}
