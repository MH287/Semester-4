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
        _keyOne.action.performed += ctx => CurrentSlot = 1;
        _keyTwo.action.performed += ctx => CurrentSlot = 2;
        _keyThree.action.performed += ctx => CurrentSlot = 3;

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
        if (_interactionTarget == null)
        {
            return;
        }

        switch (_interactionTarget.InteractionTypInv)
        {
            case InteractionTypInv.View:
                //_itemViewer.InspectItem(_interactionTarget.ItemReference);
                break;
            case InteractionTypInv.InvokeEvent:
                _interactionTarget.OnInteract.Invoke();
                break;
            case InteractionTypInv.Useable:
                Manager.Use<InventoryManager>().UseItem();
                Manager.Use<InventoryManager>().DestroyItemInWorld(_interactionTarget.gameObject);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }


    }
    public void UseItem()
    {
            if (CurrentSlot == 1 && InventoryItems.Count > 0)
            {
                _interactionTarget = InventoryItems[0].Prefab.GetComponent<Interactable>();
                InteractWithInvItem(InventoryItems[0]);
                //RemoveItem(InventoryItems[0]);
                CurrentSlot = 0;
                RefreshUI();
            }
            else if (CurrentSlot == 2 && InventoryItems.Count > 1)
            {
                _interactionTarget = InventoryItems[1].Prefab.GetComponent<Interactable>();
            InteractWithInvItem(InventoryItems[1]);
                //RemoveItem(InventoryItems[1]);
                CurrentSlot = 0;
                RefreshUI();
            }
            else if(CurrentSlot == 3 && InventoryItems.Count > 2)
            {
                InteractWithInvItem(InventoryItems[2]);
                //RemoveItem(InventoryItems[2]);
                CurrentSlot = 0;
                RefreshUI();
            } 
    }
    public void DestroyItemInWorld(GameObject item)
    {
        Destroy(item);
    }

}
