using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemViewer : MonoBehaviour, IDragHandler
{
    [SerializeField] private Item _item;
    [SerializeField] private GameObject _itemPrefab;
    [Range(0,1), SerializeField] private float _rotateSensetivity = 0.5f;


    public void Spawn3DItem()
     {
         if(_itemPrefab != null)
         {
             Destroy(_itemPrefab.gameObject);
         }

         _itemPrefab = Instantiate(_item.Prefab, new Vector3(1000, 1000, 1000), Quaternion.identity);
     }

     public void OnDrag(PointerEventData eventData)
     {
         Debug.Log("OnDrag");
         //_itemPrefab.transform.eulerAngles += new Vector3(-eventData.delta.y, -eventData.delta.x);
         _itemPrefab.transform.Rotate(Vector3.up, -eventData.delta.x * _rotateSensetivity, Space.World);
         _itemPrefab.transform.Rotate(Vector3.right, eventData.delta.y * _rotateSensetivity, Space.World);
    }
}


