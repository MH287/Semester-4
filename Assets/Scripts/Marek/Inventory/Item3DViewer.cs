using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item3DViewer : MonoBehaviour
{
    [SerializeField] private InventoryManager _inventoryManager;

    private Transform _itemPrefab;

    private void Start()
    {
        _inventoryManager.OnItemSelected += Inventory_OnItemSelected;
    }
    private void Inventory_OnItemSelected(object sender, Item item)
    {
        Debug.Log(item.ItemName);
        if(_itemPrefab != null)
        {
            Destroy(_itemPrefab.gameObject);
        }
        _itemPrefab = Instantiate(item.Prefab, new Vector3(1000,1000,1000), Quaternion.identity);
    }
}
