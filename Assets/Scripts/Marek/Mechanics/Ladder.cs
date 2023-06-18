using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine.InputSystem;
using UnityEngine;
using DG.Tweening;
using StarterAssets;
using System.Security.Cryptography;

public class Ladder : MonoBehaviour
{
    [SerializeField] private InteractionController _controller;
    [SerializeField] private InputActionReference _ladder;


    [SerializeField] private Vector3 _ladderPos1;
    [SerializeField] private Vector3 _ladderPos2;
    [SerializeField] private Vector3 _ladderPos3;
    [SerializeField] private float _ladderSpeedFixPosition;
    [SerializeField, Range(1, 50)] private float _ladderSpeedFreePosition = 25f;

    [SerializeField] private Vector3 _moveDirection;

    private Vector3 _lastPosition;





    public void Start()
    {
        _ladder.action.Enable();
        _ladder.action.performed += MoveLedderPerformed;
        _ladder.action.canceled += MoveLedderCanceled;
    }

    public void MoveLedderFixPosition()
    {
        if (transform.position == _ladderPos1)
        {
            transform.DOMove(_ladderPos2, _ladderSpeedFixPosition);
            _lastPosition = _ladderPos1;
        }
        else if (transform.position == _ladderPos2 && _lastPosition == _ladderPos1)
        {
            transform.DOMove(_ladderPos3, _ladderSpeedFixPosition);
            _lastPosition = _ladderPos2;
        }
        else if (transform.position == _ladderPos2 && _lastPosition == _ladderPos3)
        {
            transform.DOMove(_ladderPos1, _ladderSpeedFixPosition);
            _lastPosition = _ladderPos2;
        }
        else
        {
            transform.DOMove(_ladderPos2, _ladderSpeedFixPosition);
            _lastPosition = _ladderPos3;
        }
    }
    
    public void MoveLedderFree()
    {
        if(_controller.InteractionTarget.GetComponent<Ladder>() != null)
        {
            Debug.Log("LadderMove");
            transform.position = GetComponent<Transform>().position;
            _ladder.action.performed += MoveLedderPerformed;

        }

    }
    public void MoveLedderPerformed(InputAction.CallbackContext obj)
    {

        if (transform.position.x >= _ladderPos3.x && transform.position.x <= _ladderPos1.x)
        {
            _moveDirection.x = _moveDirection.x * 1;
            GetComponent<Rigidbody>().AddForce(_moveDirection * _ladderSpeedFreePosition, ForceMode.Force);
            Debug.Log(_moveDirection.x);
        }
        else if (transform.position.x <= _ladderPos3.x)
        {
            _moveDirection.x = _moveDirection.x * -1;
            GetComponent<Rigidbody>().AddForce(_moveDirection * _ladderSpeedFreePosition, ForceMode.Force);
            Debug.Log(_moveDirection.x);
        }
        else if (transform.position.x >= -_ladderPos1.x)
        {
            _moveDirection.x = _moveDirection.x * -1;
            GetComponent<Rigidbody>().AddForce(_moveDirection * _ladderSpeedFreePosition, ForceMode.Force);
            Debug.Log(_moveDirection.x);
        }


    }
    public void MoveLedderCanceled(InputAction.CallbackContext obj)
    {
        double j = obj.duration;
        if(j > 1)
        {
            j = 0;
        }
        GetComponent<Rigidbody>().velocity = Vector3.zero;

    }
}
