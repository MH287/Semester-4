using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorConsole : MonoBehaviour
{
    [Header("Fuse + Console")]
    [SerializeField] private InventoryManager _inventoryManager;
    [SerializeField] private ShowUVCode _showUVCode;
    [SerializeField] public Item Fuse;
    [SerializeField] public ItemSlot Slot;
    [SerializeField] private GameObject _fuseOne;
    [SerializeField] private GameObject _fuseTwo;

    [SerializeField] private GameObject _spectatorCode;
    [SerializeField] private GameObject _spectatorLight;
    [SerializeField] private GameObject _storageCode;
    [SerializeField] private GameObject _storageLight;

    int i;

    public void Awake()
    {
        _spectatorCode.SetActive(false);
        _spectatorLight.SetActive(false);
        _storageCode.SetActive(false);
        _storageLight.SetActive(false);
    }

    public void UseFuseInConsole()
    {
        if (_inventoryManager.CheckInvForFuse() && _fuseOne.activeSelf == false)
        {

            _fuseOne.SetActive(true);
            _inventoryManager.InventoryItems.Remove(Fuse);
            Destroy(_inventoryManager.InventorySlots[0].gameObject);
            _inventoryManager.InventorySlots.Remove(_inventoryManager.InventorySlots[0]);
            _inventoryManager.RefreshUI();
            _showUVCode.ShowCode(_spectatorCode, _spectatorLight);
            Debug.Log("Fuse vorhanden");

        }
        else if (_inventoryManager.CheckInvForFuse() && _fuseOne.activeSelf)
        {
            _fuseTwo.SetActive(true);
            _inventoryManager.InventoryItems.Remove(Fuse);
            Destroy(_inventoryManager.InventorySlots[0].gameObject);
            _inventoryManager.InventorySlots.Remove(_inventoryManager.InventorySlots[0]);
            _showUVCode.ShowCode(_storageCode, _storageLight);
            Debug.Log("Fuse vorhanden");
        }
        else
        {
            Debug.Log("Keine Fuse vorhanden");
        }
    }

    public int GetFuseUI()
    {
        if (_inventoryManager._keyOne.action.IsPressed())
        {
            return i = 0;
        }
        else if (_inventoryManager._keyTwo.action.IsPressed())
        {
            return i = 1;
        }
        else if (_inventoryManager._keyThree.action.IsPressed())
        {
            return i = 2;
        }
        else return -1;


    }
}
