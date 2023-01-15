using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDetail :MonoBehaviour
{
    //hand_made_Level, Self_Defense_Level,Legion_Level,Custom_made_Level
    public enum quality{ hand_made_Level, Self_Defense_Level , Legion_Level , Custom_made_Level };
    public float basic_damage;
    public float AP_damage;
    public float Dura;

    public bool CanItZwei;
}
