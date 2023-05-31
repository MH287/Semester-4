using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventoryManager : ManagerModule
{
    [SerializeField] private GameObject _slotHolder;
    [SerializeField] private InputActionReference _keyOne;
    [SerializeField] private InputActionReference _keyTwo;
    [SerializeField] private InputActionReference _keyThree;
    [SerializeField] private ItemViewer _itemViewer;

    public List<Item> InventoryItems = new List<Item>();

    private GameObject[] _slots;
    private Interactable _interactionTarget;
    private int CurrentSlot = 0;

    public void Start()
    {
        _keyOne.action.Enable();
        _keyTwo.action.Enable();
        _keyThree.action.Enable();
        _keyOne.action.performed += UseItem;
        _keyTwo.action.performed += UseItem;
        _keyThree.action.performed += UseItem;

        _slots = new GameObject[_slotHolder.transform.childCount];
        for(int i = 0; i < _slotHolder.transform.childCount; i++) //_slotHolder.transform.childCount == _slots.Lenght
        {
            _slots[i] = _slotHolder.transform.GetChild(i).gameObject;
        }

        RefreshUI();
    }

    public void RefreshUI()
    {
        for(int i = 0; i < _slots.Length; i++)
        {
            
            try
            {
                _slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                _slots[i].transform.GetChild(0).GetComponent<Image>().sprite = InventoryItems[i].Icon;
            }
            catch
            {
                _slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                _slots[i].transform.GetChild(0).GetComponent<Image>().enabled = false;

            }
        }
    }

    public void AddItem(Item item)
    {
        InventoryItems.Add(item);
        RefreshUI();
    }

    public void RemoveItem(Item item) 
    {
        InventoryItems.Remove(item);
        RefreshUI();
    }
    public void ResetCurrentSlot()
    {
        if (InventoryItems.Count < CurrentSlot)
        {
            CurrentSlot = 0;
        }
    }
    private void InteractWithInvItem(Item item)
    {
        _interactionTarget = item.Prefab.GetComponent<Interactable>();

        if (_interactionTarget == null)
        {
            return;
        }

        switch (_interactionTarget.InteractionTypInv)
        {
            case InteractionTypInv.View:
                Debug.Log("Item View");
                _itemViewer.InspectItem(_interactionTarget.ItemReference);
                break;
            case InteractionTypInv.InvokeEvent:
                Debug.Log("Event Invoke");
                //_interactionTarget.OnInteract.Invoke();
                break;
            case InteractionTypInv.Useable:
                Debug.Log("Item Use");
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }


    }
    public void UseItem(InputAction.CallbackContext obj)
    {
        if(_keyOne.action.IsPressed())
        {
            InteractWithInvItem(InventoryItems[0]);
        }
        else if(_keyTwo.action.IsPressed())
        {
            InteractWithInvItem(InventoryItems[1]);
        }
        else if (_keyThree.action.IsPressed())
        {
            InteractWithInvItem(InventoryItems[2]);
        }
    }
    public void DestroyItemInWorld(GameObject item)
    {
        Destroy(item);
    }

}
