using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Camera))]
public class InteractionController : MonoBehaviour
{
    [SerializeField] private LayerMask _interactionLayerMask;
    [SerializeField] private float _interactionRange = 1.5f;
    [SerializeField] private InputActionReference _interactionAction;
    [SerializeField] private ItemViewer _itemViewer;

    public  Interactable _interactionTarget;
    private Outline _targetOutline;
    private Camera _camera;

    void Awake()
    {
        _interactionAction.action.performed += InteractWithTarget;
        _interactionAction.action.Enable();
        _camera = GetComponent<Camera>();
    }

    void Update()
    {
        if (Physics.Raycast(_camera.ViewportPointToRay(new Vector3(0.5f, 0.5f)), out RaycastHit hit, _interactionRange,
                _interactionLayerMask))
        {
            Manager.Use<UIManager>().ShowInteractWithE();
            _targetOutline = hit.transform.gameObject.GetComponent<Outline>();
            if (_targetOutline != null)
            {
                _targetOutline.enabled = true;
            }

            _interactionTarget = hit.transform.gameObject.GetComponent<Interactable>();
        }
        else
        {
            Manager.Use<UIManager>().HideInteractWithE();
            if(_targetOutline != null)
                _targetOutline.enabled = false;

            _targetOutline = null;
            _interactionTarget = null;
        }
    }

    private void InteractWithTarget(InputAction.CallbackContext obj)
    {
        if (_interactionTarget == null)
        {
            return;
        }

        switch (_interactionTarget.InteractionTypeWorld)
        {
            case InteractionTypeWorld.View:
                _itemViewer.InspectItem(_interactionTarget.ItemReference);
                break;
            case InteractionTypeWorld.InvokeEvent:
                _interactionTarget.OnInteract.Invoke();
                break;
            case InteractionTypeWorld.Item:
                Manager.Use<InventoryManager>().AddItem(_interactionTarget.ItemReference);
                Manager.Use<InventoryManager>().DestroyItemInWorld(_interactionTarget.gameObject);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        
    }
}
