using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShowUVCode : MonoBehaviour
{
    [SerializeField] private GameObject _uVCode;
    [SerializeField] private GameObject _light;
    [SerializeField] private InventoryManager _inventoryManager;
    [SerializeField] private Item _key;

    void Awake()
    {
        _uVCode.SetActive(false);
        _light.SetActive(false);
    }

    void Update()
    {
        CheckFuse();
    }
    public void ShowCode()
    {
        _uVCode.SetActive(true);
        _light.SetActive(true);
    }

    public void CheckFuse()
    {
        if (!_inventoryManager.Items.Contains(_key))
        {
            _uVCode.SetActive(false);
            _light.SetActive(false);
        }
    }
    public void CheckInventoryForKey()
    {

        if (_inventoryManager.Items.Contains(_key))
        {
            ShowCode();
        }
        else
        {
            Debug.Log("Key nicht vorhanden!");
        }
    }
}
