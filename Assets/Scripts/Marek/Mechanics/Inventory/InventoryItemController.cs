using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    Item item;

    public Button RemoveButton;
    //[SerializeField] private GameObject _itemViewer;
    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);

        Destroy(gameObject);
    }
    public void AddItem(Item newItem)
    {
        item = newItem;
    }

    public void DropItem()
    {
        Debug.Log("Item abgelegt");

    }

    public void UseItem()
    {
        switch (item.itemType)
        {
            case Item.ItemType.Key:
                DropItem();
                InventoryManager.Instance.Remove(item);
                break;
            case Item.ItemType.Example:
                Debug.Log("Example");
                break;
            case Item.ItemType.Tip:
                Debug.Log("Tip");
                break;
            case Item.ItemType.Waste:
                Debug.Log("Waste");
                break;
        }
    }

    /*public void OpenItemViewer()
    {
        _itemViewer.SetActive(true);
        Instantiate(item.Prefab);
    }*/
}
