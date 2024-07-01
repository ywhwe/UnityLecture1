using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum ItemType
{
    Weapon, Armor, Consumable
}
[CreateAssetMenu(fileName = "New Item Data", menuName = "CustomData/Create Item Data", order = 0)]
public class ItemData : ScriptableObject
{
    public Sprite itemImage;
    public string itemName;
    
    [TextArea]
    public string itemDesc;
    public ItemType type;
    
    
}
