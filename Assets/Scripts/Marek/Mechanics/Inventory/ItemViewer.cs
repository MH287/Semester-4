using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ItemViewer : MonoBehaviour, IDragHandler
{
    [SerializeField] private GameObject _itemCamera;
    [SerializeField] private int _offset = 1;
    [SerializeField] private Item _item;
    [SerializeField] private GameObject _itemPrefab;
    [Range(0,1), SerializeField] private float _rotateSensetivity = 0.5f;

    [SerializeField] private InputActionReference _interactionAction;

    public void InspectItem(Item target)
    {
        _item = target;
        Spawn3DItem();
        gameObject.SetActive(true);
        Manager.Use<MouseController>().FreeMouse();
    }

    public void Spawn3DItem()
     {
         if(_itemPrefab != null)
         {
             Destroy(_itemPrefab.gameObject);
         }

         _itemPrefab = Instantiate(_item.Prefab, _itemCamera.transform);
        _itemPrefab.transform.localPosition = new Vector3(0,0,_offset);
     }

     public void OnDrag(PointerEventData eventData)
     {
         _itemPrefab.transform.Rotate(Vector3.up, -eventData.delta.x * _rotateSensetivity, Space.World);
         _itemPrefab.transform.Rotate(Vector3.right, eventData.delta.y * _rotateSensetivity, Space.World);
    }
}


