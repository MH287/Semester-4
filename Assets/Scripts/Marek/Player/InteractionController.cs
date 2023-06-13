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

    public  Interactable InteractionTarget;
    private Outline _targetOutline;
    private Camera _camera;
    private RaycastHit hit;

    void Awake()
    {
        _interactionAction.action.performed += InteractWithTarget;
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

    private void InteractWithTarget(InputAction.CallbackContext obj)
    {
        if (InteractionTarget == null)
        {
            return;
        }

        switch (InteractionTarget.InteractionTypeWorld)
        {
            case InteractionTypeWorld.View:
                _itemViewer.InspectItem(InteractionTarget.ItemReference);
                break;
            case InteractionTypeWorld.InvokeEvent:
                InteractionTarget.OnInteract.Invoke();
                break;
            case InteractionTypeWorld.Item:
                Manager.Use<InventoryManager>().AddItem(InteractionTarget.ItemReference);
                Manager.Use<InventoryManager>().DestroyItemInWorld(InteractionTarget.gameObject);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        
    }
}
