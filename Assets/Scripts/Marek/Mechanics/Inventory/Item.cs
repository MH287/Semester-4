using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName ="New Item", menuName ="Item/Create New Item")]

public class Item : ScriptableObject
{
    public string ItemName;
    public Sprite Icon;
    public GameObject Prefab;
    public string ItemDescription;
    //public ItemType itemType;
    public IntTypeWorld InteractionWorld;
    public IntTypeInv InteractionInv;

    public UnityEvent OnInteract;


    /*public enum ItemType
    {
        Collectable,
        NotCollectable
    }*/
    public enum IntTypeWorld
    {
        Inspectable,
        InvokeEvent,
        Collectable,
        SpecialView
    }
    public enum IntTypeInv
    {
        Inspectable,
        InvokeEvent,
        Useable,
        Audio,
        SpecialView, //für das Wimmelbild
        NotNeeded
    }
}
