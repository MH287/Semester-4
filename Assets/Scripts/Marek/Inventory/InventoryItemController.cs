using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    Item item;

    public Button RemoveButton;
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
                break;
            case Item.ItemType.Tip:
                break;
            case Item.ItemType.Waste:
                break;
        }

        /*
        DropItem();
        InventoryManager.Instance.Remove(item);
        */
    }
}
