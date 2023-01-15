using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "Item", menuName ="Assets/Items")]
public class Item : ScriptableObject
{
    public int ItemID;
    public string Weapon_name;
    public string Description;

    public GameObject weaponPrefab;
    public Sprite weaponSprite;
}
