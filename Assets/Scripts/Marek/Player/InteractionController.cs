using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Camera))]
public class InteractionController : MonoBehaviour
{
    [SerializeField] private LayerMask _interactionLayerMask;
    [SerializeField] private float _interactionRange = 2.0f;
    [SerializeField] private InputActionReference _interactionAction;
    [SerializeField] private ItemViewer _itemViewer;
    [SerializeField] private ItemPickUp _itemPickUp;

    private Interactable _interactionTarget;
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
            //TODO highlighting
            _interactionTarget = hit.transform.gameObject.GetComponent<Interactable>();
        }
        else
        {
            _interactionTarget = null;
        }
    }

    private void InteractWithTarget(InputAction.CallbackContext obj)
    {
        if (_interactionTarget == null)
        {
            return;
        }

        switch (_interactionTarget.InteractionType)
        {
            case InteractionType.View:
                _itemViewer.InspectItem(_interactionTarget.ItemReference);
                break;
            case InteractionType.InvokeEvent:
                _interactionTarget.OnInteract.Invoke();
                break;
            case InteractionType.Item:
                _itemPickUp.PickUp();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        
    }
}
