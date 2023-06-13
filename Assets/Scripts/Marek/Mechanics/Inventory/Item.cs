using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName ="Item/Create New Item")]

public class Item : ScriptableObject
{
    public string ItemName;
    public Sprite Icon;
    public GameObject Prefab;
    public string ItemDescription;
    public ItemType itemType;

    public enum ItemType
    {
        Collectable,
        NotCollectable
    }
}
