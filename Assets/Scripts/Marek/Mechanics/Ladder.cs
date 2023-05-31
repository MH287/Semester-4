using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine.InputSystem;
using UnityEngine;
using DG.Tweening;
using StarterAssets;

public class Ladder : MonoBehaviour
{
    [SerializeField] private Vector3 _lastPosition;
    [SerializeField] private Vector3 _ladderPos1;
    [SerializeField] private Vector3 _ladderPos2;
    [SerializeField] private Vector3 _ladderPos3;
    [SerializeField] private float _ladderSpeed;

    [SerializeField] private Vector3 _moveDirection;
    [SerializeField] private InputActionReference _ladder;

    [SerializeField] private InteractionController _controller;

    public void Start()
    {
        _ladder.action.Enable();
        _ladder.action.performed += MoveLedder;
    }

    public void MoveLedderFixPosition()
    {
        if (transform.position == _ladderPos1)
        {
            transform.DOMove(_ladderPos2, _ladderSpeed);
            _lastPosition = _ladderPos1;
        }
        else if (transform.position == _ladderPos2 && _lastPosition == _ladderPos1)
        {
            transform.DOMove(_ladderPos3, _ladderSpeed);
            _lastPosition = _ladderPos2;
        }
        else if (transform.position == _ladderPos2 && _lastPosition == _ladderPos3)
        {
            transform.DOMove(_ladderPos1, _ladderSpeed);
            _lastPosition = _ladderPos2;
        }
        else
        {
            transform.DOMove(_ladderPos2, _ladderSpeed);
            _lastPosition = _ladderPos3;
        }
    }
    
    public void MoveLedderFree()
    {
        if(_controller._interactionTarget.GetComponent<Ladder>() != null)
        {
            Debug.Log("LadderMove");
            transform.Translate(_moveDirection, Space.Self);
        }

    }
    public void MoveLedder(InputAction.CallbackContext obj)
    {
        //während E gedrückt ist (Move Leddder Free)
    }
}
