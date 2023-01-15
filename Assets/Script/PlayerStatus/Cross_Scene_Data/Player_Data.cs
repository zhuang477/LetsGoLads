using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Player_Data : ScriptableObject
{
    public CitizenShip chosen_Country;
    public Career chosen_Job;
    public int CurrentMoney;
    public string Difficulty;
}
