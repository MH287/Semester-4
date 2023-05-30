using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum InteractionTypeWorld
{
    View,
    InvokeEvent,
    Item
}
public enum InteractionTypInv
{
    View,
    InvokeEvent,
    Useable,
}
public class Interactable : MonoBehaviour
{
    public Item ItemReference;
    public InteractionTypeWorld InteractionTypeWorld;
    public InteractionTypInv InteractionTypInv;
    public UnityEvent OnInteract;

}
