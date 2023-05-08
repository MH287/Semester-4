using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum InteractionType
{
    View,
    InvokeEvent,
    Item
}
public class Interactable : MonoBehaviour
{
    public Item ItemReference;
    public InteractionType InteractionType;
    public UnityEvent OnInteract;

}
