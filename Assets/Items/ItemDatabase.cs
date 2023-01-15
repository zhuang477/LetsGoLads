using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Database", menuName ="Assets/Databases/ItemDatabase")]
public class ItemDatabase : ScriptableObject
{
    public List<Item> weapons = new List<Item>();
}
