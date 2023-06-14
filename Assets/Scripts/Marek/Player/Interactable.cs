using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Auskommentieren, falls Teständerung nicht klappt.

/*public enum InteractionTypeWorld 
{
    Inspectable,
    InvokeEvent,
    Collectable
}
public enum InteractionTypInv
{
    Inspectable,
    InvokeEvent,
    Useable,
    Audio,
    SpecialView
}*/
public class Interactable : MonoBehaviour
{

    //public InteractionTypeWorld InteractionWorld;
    //public InteractionTypInv InteractionInv;

    public Item ItemReference;
    public UnityEvent OnInteract;

}
