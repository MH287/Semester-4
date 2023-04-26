using System.Collections;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.InputSystem;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject _itemViewer;

    public InputActionReference reference;

    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    public Toggle EnableRemove;

    public InventoryItemController[] InventoryItems;

    public GameObject InventoryObj;

    [SerializeField] private MouseController _mouseController;
    
    private void Awake()
    {
        Instance = this;
        reference.action.Enable();
        reference.action.performed += _ => Inventory();
        InventoryObj.SetActive(false);
    }

    public void Add(Item item)
    {
        Items.Add(item);
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
    }

    public void ListItems()
    {
        CleanList();

        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            var Button = obj.transform.GetComponent<Button>();
            Button.onClick.AddListener(InspectObject);

            itemName.text = item.ItemName;
            itemIcon.sprite = item.Icon;

        }

        SetInventoryItems();
    }

    public void InspectObject()
    {
        _itemViewer.SetActive(true);
        FindObjectOfType<ItemViewer>().Spawn3DItem();
    }
    
    public void CleanList()
    {        
        //Clean Content befor open -> nur das gepickte Item hinzufügen, nicht alles löschen und neu hinzufügen
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

    }

    public void EnableItemRemove()
    {
        if (EnableRemove.isOn)
        {
            foreach (Transform item in ItemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform item in ItemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(false);
            }
        }
    }

    public void SetInventoryItems()
    {
        InventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();

        for (int i = 0; i < Items.Count; i++)
        {
            InventoryItems[i].AddItem(Items[i]);
        }
    }

    public void Inventory()
    {
        if (!InventoryObj.activeSelf)
        {
            Debug.Log("Inventory öffnen.");
            ListItems();
            InventoryObj.SetActive(true);
            _mouseController.FreeMouse();
        }
        else
        {
            Debug.Log("Inventory closed.");
            InventoryObj.SetActive(false);
            _mouseController.LockMouse();
        }
    }
}