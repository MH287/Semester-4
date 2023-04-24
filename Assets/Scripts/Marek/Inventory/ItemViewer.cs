using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemViewer : MonoBehaviour, IDragHandler
{
    [SerializeField] private GameObject _viewerCanvas;
    [SerializeField] private Item _item;
    private GameObject _itemPrefab;

    public void Spawn3DItem()
     {
         /*if(_itemPrefab != null)
         {
             Destroy(_itemPrefab.gameObject);
         }*/
         
         _viewerCanvas.SetActive(true); 
         _itemPrefab = Instantiate(_item.Prefab, new Vector3(1000, 1000, 1000), Quaternion.identity);
     }

     public void OnDrag(PointerEventData eventData)
     {
         Debug.Log("OnDrag");
         //_item.Prefab.transform.eulerAngles += new Vector3(-eventData.delta.y, -eventData.delta.x);
         _item.Prefab.transform.rotation = Quaternion.Euler(eventData.delta.y, eventData.delta.x, 0);
     }
}


