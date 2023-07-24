using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyUse : MonoBehaviour
{
    [SerializeField] private Interactable _keylock;

    private InteractionController _interactionController;
    private InventoryManager _inventoryManager;

    void Start()
    {
        _inventoryManager = Manager.Use<InventoryManager>();
        _interactionController = Manager.Use<InteractionController>();
    }

    public void CheckInteractiontarget()
    {
        if ((_interactionController.InteractionTarget == _keylock))
        {
            
        }
    }
}
