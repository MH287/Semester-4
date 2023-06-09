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
    public ItemType itemType;
    public IntTypeWorld InteractionWorld;
    public IntTypeInv InteractionInv;

    public float eulerXForInspect;
    public float eulerYForInspect;
    public float eulerZForInspect;

    public UnityEvent OnInteract;


    public enum ItemType
    {
        Normal,
        Special
    }
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
        SpecialView, //f�r das Wimmelbild
        NotNeeded
    }
}
