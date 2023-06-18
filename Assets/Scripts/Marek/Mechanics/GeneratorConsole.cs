using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorConsole : MonoBehaviour
{
    [Header("Fuse + Console")]
    [SerializeField] private InventoryManager _inventoryManager;
    [SerializeField] private ShowUVCode _showUVCode;
    [SerializeField] public Item Fuse;
    [SerializeField] private GameObject _fuseOne;
    [SerializeField] private GameObject _fuseTwo;

    [SerializeField] private GameObject _spectatorCode;
    [SerializeField] private GameObject _spectatorLight;
    [SerializeField] private GameObject _storageCode;
    [SerializeField] private GameObject _storageLight;


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
            _showUVCode.ShowCode(_spectatorCode, _spectatorLight);
            Debug.Log("Fuse vorhanden");

        }
        else if (_inventoryManager.CheckInvForFuse() && _fuseOne.activeSelf)
        {
            _fuseTwo.SetActive(true);
            _inventoryManager.InventoryItems.Remove(Fuse);
            _showUVCode.ShowCode(_storageCode, _storageLight);
            Debug.Log("Fuse vorhanden");
        }
        else
        {
            Debug.Log("Keine Fuse vorhanden");
        }
    }
}
