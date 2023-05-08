using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public Item Item;

    public void PickUp()
    {
        InventoryManager.Instance.Add(Item);
        Destroy(gameObject);
    }
}
