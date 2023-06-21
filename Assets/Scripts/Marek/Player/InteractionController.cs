using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Item;

[RequireComponent(typeof(Camera))]
public class InteractionController : MonoBehaviour
{
    [SerializeField] private LayerMask _interactionLayerMask;
    [SerializeField] private float _interactionRange = 1.5f;
    [SerializeField] private InputActionReference _interactionAction;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private ItemViewer _itemViewer;

    public  Interactable InteractionTarget;
    public Item InteractionItem;

    private GameObject _interactionTargetGO;
    private Outline _targetOutline;
    private Camera _camera;
    private RaycastHit hit;

    void Awake()
    {
        //_interactionAction.action.performed += InteractWithTarget; --> Falls Teständerung nicht klappt
        _interactionAction.action.performed += InteractWithTargetTest;
        _interactionAction.action.Enable();
        _camera = GetComponent<Camera>();
    }

    void Update()
    {
        Debug.DrawRay(_camera.transform.position, _camera.transform.forward, Color.red);
        if (Physics.Raycast(_camera.ViewportPointToRay(new Vector3(0.5f, 0.5f)), out hit, _interactionRange,
                _interactionLayerMask))
        {
            Manager.Use<UIManager>().ShowInteractWithE();
            _targetOutline = hit.transform.gameObject.GetComponent<Outline>();
            if (_targetOutline != null)
            {
                _targetOutline.enabled = true;
            }

            InteractionTarget = hit.transform.gameObject.GetComponent<Interactable>();
        }
        else
        {
            Manager.Use<UIManager>().HideInteractWithE();
            if(_targetOutline != null)
                _targetOutline.enabled = false;

            _targetOutline = null;
            InteractionTarget = null;
        }
    }

    /*private void InteractWithTarget(InputAction.CallbackContext obj) --> Falls Teständerung nicht klappt.
    {
        if (InteractionTarget == null)
        {
            return;
        }

        switch (InteractionTarget.InteractionWorld)
        {
            case InteractionTypeWorld.Inspectable:
                _itemViewer.InspectItem(InteractionTarget.ItemReference);
                break;
            case InteractionTypeWorld.InvokeEvent:
                InteractionTarget.OnInteract.Invoke();
                break;
            case InteractionTypeWorld.Collectable:
                Manager.Use<InventoryManager>().AddItem(InteractionTarget.ItemReference);
                Manager.Use<InventoryManager>().DestroyItemInWorld(InteractionTarget.gameObject);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }    
    }*/
    private void InteractWithTargetTest(InputAction.CallbackContext obj)
    {
        if (InteractionTarget == null)
        {
            return;
        }

        switch (InteractionTarget.ItemReference.InteractionWorld)
        {
            case IntTypeWorld.Inspectable:
                _playerInput.DeactivateInput();
                InteractionTarget.gameObject.SetActive(false);
                _interactionTargetGO = InteractionTarget.gameObject;
                _itemViewer.InspectItem(InteractionTarget.ItemReference);
                _itemViewer.AddButton.gameObject.SetActive(false);
                _itemViewer.CloseInspectorButton.gameObject.SetActive(true);
                break;
            case IntTypeWorld.InvokeEvent:
                InteractionTarget.OnInteract.Invoke();
                break;
            case IntTypeWorld.Collectable:
                //Inspect Item mit Add zum Inv
                _playerInput.DeactivateInput();
                InteractionTarget.gameObject.SetActive(false);
                InteractionItem = InteractionTarget.ItemReference;
                DestroyItemInWorld();
                _itemViewer.InspectItem(InteractionTarget.ItemReference);
                _itemViewer.AddButton.gameObject.SetActive(true);
                _itemViewer.CloseInspectorButton.gameObject.SetActive(false);
                //Manager.Use<InventoryManager>().DestroyItemInWorld(InteractionTarget.gameObject);
                break;
            case IntTypeWorld.SpecialView:
                Debug.Log("Show Story Element");
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    public void DestroyItemInWorld()
    {
        _playerInput.ActivateInput();
        //Debug.Log(_interactionController.InteractionTarget.ItemReference);
        Destroy(InteractionTarget.gameObject);
    }

    public void SpawnItemOnWorldPlace()
    {
        Manager.Use<MouseController>().LockMouse();
        _playerInput.ActivateInput();
        _itemViewer.gameObject.SetActive(false);
        _interactionTargetGO.SetActive(true);
    }
}
