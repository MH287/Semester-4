using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item Item;

     public void PickUp()
    {
        Manager.Use<InventoryManager>().AddItem(Item);
        Destroy(gameObject);
    }
}
