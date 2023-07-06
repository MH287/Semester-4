using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static Item;

public class ItemViewer : MonoBehaviour, IDragHandler
{
    [SerializeField] private GameObject _itemCamera;
    [SerializeField, Range(1,2)] private float _offset = 1.5f;
    [SerializeField] private Item _item;
    [SerializeField] private GameObject _itemPrefab;
    [Range(0,1), SerializeField] private float _rotateSensetivity = 0.5f;

    [SerializeField] private InputActionReference _interactionAction;

    [SerializeField] public Button AddButton;
    [SerializeField] public Button CloseInspectorButton;

    [SerializeField] private Item _globe;

    Interactable _onDraginteractable;
    public void InspectItem(Item target)
    {
        _item = target;
        Spawn3DItem();
        gameObject.SetActive(true);
        Manager.Use<MouseController>().FreeMouse();
    }

    public void InspectSpecialItem(Item target)
    {
        _item = target;
        SpawnSpecialView(_item.Prefab, _item.eulerXForInspect, _item.eulerYForInspect, _item.eulerZForInspect);
        gameObject.SetActive(true);
        Manager.Use<MouseController>().FreeMouse();
    }

    public void CloseInspectWindow(GameObject canvas)
    {
        canvas.SetActive(false);
        Manager.Use<MouseController>().LockMouse(); 
    }

    public void Spawn3DItem()
     {
         if(_itemPrefab != null)
         {
             Destroy(_itemPrefab);
         }

         _itemPrefab = Instantiate(_item.Prefab, _itemCamera.transform);
        _itemPrefab.gameObject.layer = LayerMask.NameToLayer("ItemViewer");
        _itemPrefab.transform.localPosition = new Vector3(0,0,_offset);
        _itemPrefab.transform.localRotation = Quaternion.Euler(_item.eulerXForInspect, _item.eulerYForInspect, _item.eulerZForInspect);
    }

    public void SpawnSpecialView(GameObject interactionTarget, float eulerX, float eulerY, float eulerZ )
    {
        if (_itemPrefab != null)
        {
            Destroy(_itemPrefab);
        }

        Interactable itemPrefab = interactionTarget.GetComponent<Interactable>();
        interactionTarget = Instantiate(itemPrefab.ItemReference.Prefab, _itemCamera.transform);
        interactionTarget.layer = LayerMask.NameToLayer("ItemViewer");
        interactionTarget.transform.localPosition = new Vector3(0, 0, _offset);
        interactionTarget.transform.localRotation = Quaternion.Euler(eulerX,eulerY,eulerZ);

        _itemPrefab = interactionTarget.gameObject;
    }

    //On Drag zum differenziern, ob man alle Items drehen soll oder nicht
    /*public void OnDrag(PointerEventData eventData)
    {
       _onDraginteractable = _itemPrefab.GetComponent<Interactable>();

       if(_onDraginteractable != null )
       {
           switch (_onDraginteractable.ItemReference.InteractionWorld)
           {
               case IntTypeWorld.SpecialView:
                   Debug.Log("Wir drehen nicht");
                   break;
               default:
                   if (_itemPrefab != null && _item != _globe)
                   {
                       _itemPrefab.transform.Rotate(Vector3.up, -eventData.delta.x * _rotateSensetivity, Space.World);
                       _itemPrefab.transform.Rotate(Vector3.right, eventData.delta.y * _rotateSensetivity, Space.World);
                   }
                   else if (_itemPrefab != null && _item == _globe)
                   {
                       _itemPrefab.transform.Rotate(Vector3.up, -eventData.delta.x * _rotateSensetivity, Space.World);
                   }
                   else
                   {
                       Debug.Log("Wir drehen nicht");
                   }
                   break;
           }
       }
       else
       {
           if (_itemPrefab != null && _item != _globe)
           {
               _itemPrefab.transform.Rotate(Vector3.up, -eventData.delta.x * _rotateSensetivity, Space.World);
               _itemPrefab.transform.Rotate(Vector3.right, eventData.delta.y * _rotateSensetivity, Space.World);
           }
           else if (_itemPrefab != null && _item == _globe)
           {
               _itemPrefab.transform.Rotate(Vector3.up, -eventData.delta.x * _rotateSensetivity, Space.World);
           }
           else
           {
               Debug.Log("Wir drehen nicht");
           }
       }*/
    public void OnDrag(PointerEventData eventData)
    {
        if (_itemPrefab != null && _item != _globe)
        {
            _itemPrefab.transform.Rotate(Vector3.up, -eventData.delta.x * _rotateSensetivity, Space.World);
            _itemPrefab.transform.Rotate(Vector3.right, eventData.delta.y * _rotateSensetivity, Space.World);
        }
        else if (_itemPrefab != null && _item == _globe)
        {
            _itemPrefab.transform.Rotate(Vector3.up, -eventData.delta.x * _rotateSensetivity, Space.World);
        }
        else
        {
            Debug.Log("Wir drehen nicht");
        }
    }
    
}


