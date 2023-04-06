using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName ="Item/Create New Item")]

public class Item : ScriptableObject
{
    public int ID;
    public string ItemName;
    public Sprite Icon;
    public string ItemDescription;
    public ItemType itemType;

    public enum ItemType
    {
        Key,
        Tip,
        Waste,
        Example
    }
}
