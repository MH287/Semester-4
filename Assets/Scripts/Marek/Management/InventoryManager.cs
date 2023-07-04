using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static Item;

public class InventoryManager : ManagerModule
{
    [SerializeField] private InteractionController _interactionController;
    [SerializeField] private PlayerInput _playerInput;

    [Header("Hotbar")]
    [SerializeField] private GameObject _hotbar;
    [SerializeField] private GameObject _slotPrefab;
    [SerializeField] private ItemSlot _slot;

    [SerializeField] public InputActionReference _keyOne;
    [SerializeField] public InputActionReference _keyTwo;
    [SerializeField] public InputActionReference _keyThree;
    [SerializeField] private InputActionReference _audioAdvice;
    [SerializeField] private InputActionReference _noteBook;
    [SerializeField] private ItemViewer _itemViewer;
    [SerializeField] private Item _audioAdviceItem;
    [SerializeField] private Item _noteBookItem;

    public List<Item> InventoryItems = new List<Item>();

    [Header("Special Items")]
    [SerializeField] private GameObject _noteBookGO;
    [SerializeField] private GameObject _audioDeviceGO;
    [SerializeField] private GameObject _slotPrefab1;
    [SerializeField] private GameObject _specialItems;
    [SerializeField] public List<Item> _specialItemList;

    [Header("Fuse + Console")]
    [SerializeField] private GeneratorConsole _generatorConsole;
    [SerializeField] public Item Fuse;

    [Header("Wimmelbild")]
    [SerializeField] private float _picMoveSpeed;
    [SerializeField] private Transform _picTransform;
    [SerializeField] private float _endPosition;
    private float _startPosition;


    private Interactable _interactionTarget;
    private bool _isActive = false;

    public List<ItemSlot> InventorySlots = new List<ItemSlot>();

    public void Start()
    {
        _keyOne.action.Enable();
        _keyTwo.action.Enable();
        _keyThree.action.Enable();
        _audioAdvice.action.Enable();
        _noteBook.action.Enable();
        _keyOne.action.performed += UseItem;
        _keyTwo.action.performed += UseItem;
        _keyThree.action.performed += UseItem;
        _audioAdvice.action.performed += UseItem;
        _noteBook.action.performed += UseItem;

        _startPosition = _picTransform.transform.localPosition.y;

    }

    public void AddUIElement()
    {    
        GameObject obj = Instantiate(_slotPrefab, _hotbar.transform);
        ItemSlot objItemSlot = obj.GetComponent<ItemSlot>();
        objItemSlot.Icon.sprite = objItemSlot.Item.Icon;
        objItemSlot.Fitter.aspectRatio = objItemSlot.Item.Icon.texture.width / (float)objItemSlot.Item.Icon.texture.height;
        objItemSlot.KeybindingText.SetText(objItemSlot.Keybinding.ToString());

        InventorySlots.Add(objItemSlot);
    }

    public void RefreshUI()
    {
        //List<ItemSlot> slots = InventorySlots;
            foreach (ItemSlot slot in InventorySlots)
            {
                slot.Icon.sprite = slot.Item.Icon;
                slot.Fitter.aspectRatio = slot.Item.Icon.texture.width / (float)slot.Item.Icon.texture.height;
                slot.KeybindingText.SetText((InventorySlots.IndexOf(slot) + 1).ToString());
            }
    }

    public void RemoveUIElement(ItemSlot itemSlot)
    {
        InventorySlots.Remove(itemSlot);
        Destroy(itemSlot.gameObject);

    }
    public void AddUIElementSpecialItem(Item item)
    {
        if (item == _noteBookItem)
        {
            ItemSlot objItemSlot = _noteBookGO.GetComponent<ItemSlot>();
            objItemSlot.Icon.sprite = objItemSlot.Item.Icon;
            objItemSlot.Fitter.aspectRatio = objItemSlot.Item.Icon.texture.width / (float)objItemSlot.Item.Icon.texture.height;
            //objItemSlot.KeybindingText.SetText(objItemSlot.Keybinding.ToString());
            _noteBookGO.SetActive(true);
        }
        else
        {
            ItemSlot objItemSlot = _audioDeviceGO.GetComponent<ItemSlot>();
            objItemSlot.Icon.sprite = objItemSlot.Item.Icon;
            objItemSlot.Fitter.aspectRatio = objItemSlot.Item.Icon.texture.width / (float)objItemSlot.Item.Icon.texture.height;
            _audioDeviceGO.SetActive(true);
        }
    }


    public void CheckItemTypeForAdd() //in Use for Button
    {
        if (_interactionController.InteractionItem.itemType == ItemType.Normal)
        {
            AddItemOutOfInspectNormal();
        }
        else
        {
            AddItemOutOfInspectSpecial();
        }
    }
    public void AddItemOutOfInspectSpecial()
    {
        _specialItemList.Add(_interactionController.InteractionItem);
        _playerInput.ActivateInput();
        _itemViewer.gameObject.SetActive(false);
        Manager.Use<MouseController>().LockMouse();
        AddUIElementSpecialItem(_interactionController.InteractionItem);
    }
    public void AddItemOutOfInspectNormal() 
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

    private void InteractWithInvItemTest(Item item, ItemSlot itemSlot)
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
                    InventoryItems.Remove(item);
                    RemoveUIElement(itemSlot);
                    RefreshUI();
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
            InteractWithInvItemTest(InventoryItems[0], InventorySlots[0]);
        }
        else if(_keyTwo.action.IsPressed())
        {
            InteractWithInvItemTest(InventoryItems[1], InventorySlots[1]);
        }
        else if (_keyThree.action.IsPressed())
        {
            InteractWithInvItemTest(InventoryItems[2], InventorySlots[2]);
        }
        else if (_audioAdvice.action.IsPressed())
        {
            InteractWithInvItemTest(_audioAdviceItem, _audioDeviceGO.GetComponent<ItemSlot>());
        }
        else if(_noteBook.action.IsPressed())
        {
            InteractWithInvItemTest(_noteBookItem, _noteBookGO.GetComponent<ItemSlot>());
        }
    }
    public void DestroyItemInWorld(GameObject item)
    {
        Destroy(item);
    }

    public bool CheckInvForFuse()
    {
        if (InventoryItems.Contains(Fuse)) { return true; } else { return false; }
    }
}
