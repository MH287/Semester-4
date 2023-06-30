using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.InputSystem;

public class AudioDeviceCheck : MonoBehaviour
{
    [SerializeField] private InventoryManager _inventoryManager;
    [SerializeField] private Item _audioDeviceItem;
    [SerializeField] private GameObject _cutscene;
    [SerializeField, Min(1)] private float _cutsceneLenght = 5;
    [SerializeField] private InputActionAsset _inputActionMap;

    private void CheckAudioDevice()
    {
        if (!_inventoryManager._specialItemList.Contains(_audioDeviceItem))
        {
            StartCoroutine(PlayCutscenePlaceholder());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        CheckAudioDevice();
        
        Debug.Log("Play Cutscene");
    }

    IEnumerator PlayCutscenePlaceholder()
    {
        _inputActionMap.Disable();
        _cutscene.SetActive(true);
        yield return new WaitForSeconds(_cutsceneLenght);
        _inputActionMap.Enable();
        _inventoryManager._specialItemList.Add(_audioDeviceItem);
        _inventoryManager.AddUIElementSpecialItem(_audioDeviceItem);
        _cutscene.SetActive(false);
    }
}
