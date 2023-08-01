using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinisher : MonoBehaviour
{
    [SerializeField] private GameObject _key;
    [SerializeField] private GameObject _value;

    private InventoryManager _inventoryManager;
    private UIManager _uiManager;
    private MouseController _mouseController;

    private void Start()
    {
        _inventoryManager = Manager.Use<InventoryManager>();
        _uiManager = Manager.Use<UIManager>();
        _mouseController = Manager.Use<MouseController>();
    }

    public void UseKeyToLaunch()
    {
        if(_inventoryManager.CheckInvForKey() == true)
        {
            _key.SetActive(true);
            _uiManager.ShowGameFinish();
            _mouseController.FreeMouse();
            Time.timeScale = 0f;
        }
    }
}
