using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using DG.Tweening;

public class Ladder : MonoBehaviour
{
    [SerializeField] private Vector3 _lastPosition;
    [SerializeField] private Vector3 _ladderPos1;
    [SerializeField] private Vector3 _ladderPos2;
    [SerializeField] private Vector3 _ladderPos3;
    [SerializeField] private float _ladderSpeed;

    void Awake()
    {

    }
    public void MoveLedder()
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
}
