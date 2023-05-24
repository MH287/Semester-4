using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventoryManager : ManagerModule
{
    //[SerializeField] private StarterAssetsInputs _starterAssetsInputs;
    [SerializeField] private InputActionReference _interactionAction;

    [SerializeField] private GameObject _slotHolder;

    public List<Item> InventoryItems = new List<Item>();

    private GameObject[] _slots;

    public void Start()
    {
        _slots = new GameObject[_slotHolder.transform.childCount];
        for(int i = 0; i < _slotHolder.transform.childCount; i++) //_slotHolder.transform.childCount == _slots.Lenght
        {
            _slots[i] = _slotHolder.transform.GetChild(i).gameObject;
        }

        RefreshUI();

        //nur zum testen
        //AddItem(itemToAdd);
        //RemoveItem(itemToRemove);
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

    public void UseItem(Item item)
    {
        InventoryItems.Remove(item);
        RefreshUI();
    }
    public void DestroyItemInWorld(GameObject item)
    {
        Destroy(item);
    }
}
