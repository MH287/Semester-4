using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Pool;

public class NumberLock : MonoBehaviour
{
    [SerializeField] private InteractionController _controller;
    [SerializeField, Range(0.5f, 10f)] private float _rotateDuration = 1f;
    [SerializeField] private int _unlockNumber;

    private Vector3 _rotateDirection;
    private Vector3 _angle = new Vector3(0,0,36);
    private Transform _numberElement;
    private int UnlockNumberAxis;
    private int _count;


    /* 0 = O
     * 1 = 36
     * 2 = 72
     * 3 = 108
     * 4 = 144
     * 5 = 180
     * 6 = 216
     * 7 = 252
     * 8 = 288
     * 9 = 324
     * */

    public void Awake()
    {
    }
    public void RotateElement()
    {

        _numberElement = _controller.InteractionTarget.GetComponent<Transform>();
        _numberElement.transform.DOLocalRotate((_rotateDirection + _angle),_rotateDuration, RotateMode.Fast);
        _rotateDirection = new Vector3(0,0,0);
        _angle += new Vector3(0,0,36);

        CountRotation();

        CheckRightNumber();
        Debug.Log(CheckRightNumber());
        //Debug.Log(Mathf.RoundToInt(_numberElement.transform.localEulerAngles.z));

    }

    public void SetNumberToAxis()
    {

        switch (_unlockNumber)
        {
            case 0:
                UnlockNumberAxis = 0;
                break;
            case 1:
                UnlockNumberAxis = 36;
                break;
            case 2:
                UnlockNumberAxis = 72;
                break;
            case 3:
                UnlockNumberAxis = 108;
                break;
            case 4:
                UnlockNumberAxis = 144;
                break;
            case 5:
                UnlockNumberAxis = 180;
                break;
            case 6:
                UnlockNumberAxis = 216;
                break;
            case 7:
                UnlockNumberAxis = 252;
                break;
            case 8:
                UnlockNumberAxis = 288;
                break;
            case 9:
                UnlockNumberAxis = 324;
                break;
        }
    }

    public void CountRotation()
    {
        _count += 1;
        if(_count > 9)
        {
            _count = 0;
        }
    }

    public bool CheckRightNumber()
    {
        SetNumberToAxis();
        if (Mathf.RoundToInt(_numberElement.transform.localEulerAngles.z) == UnlockNumberAxis) return true;
                return false;
    }
}
