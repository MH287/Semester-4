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

    [SerializeField] private GameObject _firstCode;
    [SerializeField] private GameObject _secondCode;
    [SerializeField] private GameObject _firstLight;
    [SerializeField] private GameObject _secondLight;
    [SerializeField] private GameObject _firstElectricity;
    [SerializeField] private GameObject _secondElectricity;

    [Header("Lights")]
    [SerializeField] private List<GameObject> _lights;
    

    int i;

    public void Awake()
    {
        _firstCode.SetActive(false);
        _secondCode.SetActive(false);
        _firstLight.SetActive(false);
        _secondLight.SetActive(false);
    }

    public void UseFuseInConsole()
    {
        if (_inventoryManager.CheckInvForFuse() && _fuseOne.activeSelf == false)
        {

            _fuseOne.SetActive(true);
            _firstElectricity.SetActive(true);
            _inventoryManager.InventoryItems.Remove(Fuse);
            Destroy(_inventoryManager.InventorySlots[0].gameObject);
            _inventoryManager.InventorySlots.Remove(_inventoryManager.InventorySlots[0]);
            _inventoryManager.RefreshUI();
            _showUVCode.ShowCode(_firstCode, _firstLight);
            Debug.Log("Fuse vorhanden");

        }
        else if (_inventoryManager.CheckInvForFuse() && _fuseOne.activeSelf)
        {
            _fuseTwo.SetActive(true);
            _secondElectricity.SetActive(true);
            _inventoryManager.InventoryItems.Remove(Fuse);
            Destroy(_inventoryManager.InventorySlots[0].gameObject);
            _inventoryManager.InventorySlots.Remove(_inventoryManager.InventorySlots[0]);
            _showUVCode.ShowCode(_secondCode, _secondLight);
            foreach(GameObject light in _lights)
            {
                light.SetActive(true);
            }
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
