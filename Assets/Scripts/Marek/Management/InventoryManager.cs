using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using static UnityEditor.Progress;
using static Item;
using System.Linq;

public class InventoryManager : ManagerModule
{
    [SerializeField] private InteractionController _interactionController;
    [SerializeField] private PlayerInput _playerInput;

    [Header("Hotbar")]
    [SerializeField] private GameObject _hotbar;
    [SerializeField] private GameObject _slotPrefab;
    [SerializeField] private ItemSlot _slot;

    [SerializeField] private InputActionReference _keyOne;
    [SerializeField] private InputActionReference _keyTwo;
    [SerializeField] private InputActionReference _keyThree;
    [SerializeField] private InputActionReference _audioAdvice;
    [SerializeField] private ItemViewer _itemViewer;
    [SerializeField] private Item _audioAdviceItem;

    public List<Item> InventoryItems = new List<Item>();

    [Header("Fuse + Console")]
    [SerializeField] private GeneratorConsole _generatorConsole;

    [Header("Wimmelbild")]
    [SerializeField] private float _picMoveSpeed;
    [SerializeField] private Transform _picTransform;
    [SerializeField] private float _endPosition;
    private float _startPosition;


    private Interactable _interactionTarget;
    private bool _isActive = false;

    public void Start()
    {
        _keyOne.action.Enable();
        _keyTwo.action.Enable();
        _keyThree.action.Enable();
        _audioAdvice.action.Enable();
        _keyOne.action.performed += UseItem;
        _keyTwo.action.performed += UseItem;
        _keyThree.action.performed += UseItem;
        _audioAdvice.action.performed += UseItem;

        _startPosition = _picTransform.transform.localPosition.y;

    }

    public void AddUIElement()
    {    
        GameObject obj = Instantiate(_slotPrefab, _hotbar.transform);
        ItemSlot objItemSlot = obj.GetComponent<ItemSlot>();
        objItemSlot.Icon.sprite = objItemSlot.Item.Icon;
        objItemSlot.Fitter.aspectRatio = objItemSlot.Item.Icon.texture.width / (float)objItemSlot.Item.Icon.texture.height;
        objItemSlot.KeybindingText.SetText(objItemSlot.Keybinding.ToString());
    }

    public void RemoveUIElement()
    {

    }

    public void AddItemOutOfInspect() //in Use for Button
    {

        _slot.Item = _interactionController.InteractionItem;

        /*int i = InventoryItems.IndexOf(_slot.Item);
        if (!InventoryItems.Contains(_slot.Item))
        {
            int i = InventoryItems.IndexOf(_slot.Item);
            int l = InventoryItems.Count();
            _slot.Keybinding = l + 1;
        }
        else
        {
            IndexHelper();
        }*/

        int l = InventoryItems.Count();
        _slot.Keybinding = l + 1;

        InventoryItems.Add(_interactionController.InteractionItem);

        _playerInput.ActivateInput();
        _itemViewer.gameObject.SetActive(false);
        Manager.Use<MouseController>().LockMouse();

        AddUIElement();
    }

    public void AddItem(Item item)
    {
        InventoryItems.Add(item);
    }

    public void RemoveItem(Item item) 
    {
        InventoryItems.Remove(item);
    }

    /*private void InteractWithInvItem(Item item)
    {
        _interactionTarget = item.Prefab.GetComponent<Interactable>();

        if (_interactionTarget == null)
        {
            return;
        }

        switch (_interactionTarget.InteractionInv)
        {
            case InteractionTypInv.Inspectable:
                Debug.Log("Item View");
                ShowPicture();
                //_itemViewer.InspectItem(_interactionTarget.ItemReference);
                break;
            case InteractionTypInv.InvokeEvent:
                Debug.Log("Event Invoke");
                _interactionTarget.OnInteract.Invoke();
                break;
            case InteractionTypInv.Useable:
                Debug.Log("Item Use");
                break;
            case InteractionTypInv.Audio:
                PlayWalkieTalkie();
                break;
            case InteractionTypInv.SpecialView:
                Debug.Log("Show Storyelement");
                    break;
            default:
                throw new ArgumentOutOfRangeException();
        }


    }*/

    private void InteractWithInvItemTest(Item item)
    {

        _interactionTarget = item.Prefab.GetComponent<Interactable>();

        /*if (_interactionTarget == null)
        {
            return;
        }*/

        if (item == null)
        {
            return;
        }
        else
        {
            switch (item.InteractionInv)
            {
                case IntTypeInv.Inspectable:
                    _itemViewer.InspectItem(item);
                    _playerInput.DeactivateInput();
                    _itemViewer.AddButton.gameObject.SetActive(false);
                    _itemViewer.CloseInspectorButton.gameObject.SetActive(true);
                    break;
                case IntTypeInv.InvokeEvent:
                    item.OnInteract.Invoke();
                    break;
                case IntTypeInv.Useable:
                    Debug.Log("Item Use");
                    //RemoveUIElement();
                    break;
                case IntTypeInv.Audio:
                    PlayWalkieTalkie();
                    break;
                case IntTypeInv.SpecialView:
                    ShowPicture();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
    public void ShowPicture()
    {
        if (_isActive == false)
        {
            _picTransform.gameObject.SetActive(true);
            _picTransform.DOLocalMoveY(_endPosition, _picMoveSpeed);
            _isActive = true;
        }
        else
        {
            StartCoroutine(HidePicture());
        }        
    }

    IEnumerator HidePicture()
    {
        Tween tween = _picTransform.DOLocalMoveY(_startPosition, _picMoveSpeed);
        yield return tween.WaitForCompletion();
        _picTransform.gameObject.SetActive(false);
        _isActive = false;
    }

    public void PlayWalkieTalkie()
    {
        Debug.Log("Play Audio");
    }
    public void UseItem(InputAction.CallbackContext obj)
    {
        //obj.ReadValue<int>();

        if(_keyOne.action.IsPressed())
        {
            //InteractWithInvItem(InventoryItems[0]); --> Falls Teständerung nicht klappt.
            InteractWithInvItemTest(InventoryItems[0]);
        }
        else if(_keyTwo.action.IsPressed())
        {
            InteractWithInvItemTest(InventoryItems[1]);
        }
        else if (_keyThree.action.IsPressed())
        {
            InteractWithInvItemTest(InventoryItems[2]);
        }
        else if (_audioAdvice.action.IsPressed())
        {
            InteractWithInvItemTest(_audioAdviceItem);
        }
    }
    public void DestroyItemInWorld(GameObject item)
    {
        Destroy(item);
    }

    public bool CheckInvForFuse()
    {
        if (InventoryItems.Contains(_generatorConsole.Fuse)) { return true; } else { return false; }
    }
}
