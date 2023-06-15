using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Pool;

public class NumberLock : MonoBehaviour
{
    [SerializeField] private InteractionController _controller;
    [SerializeField] private GameObject _lockBody;
    [SerializeField] private List<Transform> _numberElementList = new List<Transform>();
    [SerializeField, Range(0.5f, 10f)] private float _rotateDuration = 1f;
    [SerializeField] private int _unlockNumberOne;
    [SerializeField] private int _unlockNumberTwo;
    [SerializeField] private int _unlockNumberThree;
    [SerializeField] private int _unlockNumberFour;
    [SerializeField] private int _unlockNumberFive;
    [SerializeField] private int _unlockNumberSix;

    private Vector3 _rotateDirection;
    private Vector3 _angleElementOne = new Vector3(36,0, 0);
    private Vector3 _angleElementTwo = new Vector3(36, 0, 0);
    private Vector3 _angleElementThree = new Vector3(36, 0, 0);
    private Vector3 _angleElementFour = new Vector3(36, 0, 0);
    private Vector3 _angleElementFive = new Vector3(36, 0, 0);
    private Vector3 _angleElementSix = new Vector3(36, 0, 0);

    [SerializeField] private Transform _numberElement;
    
    private Transform _numberElementOne;
    private Transform _numberElementTwo;
    private Transform _numberElementThree;
    private Transform _numberElementFour;
    private Transform _numberElementFive;
    private Transform _numberElementSix;
    private int _countElementOne;
    private int _countElementTwo;
    private int _countElementThree;
    private int _countElementFour;
    private int _countElementFive;
    private int _countElementSix;



    public void Awake()
    {
        _numberElementOne = _lockBody.gameObject.transform.GetChild(0);
        _numberElementTwo = _lockBody.gameObject.transform.GetChild(1);
        _numberElementThree = _lockBody.gameObject.transform.GetChild(2);
        _numberElementFour = _lockBody.gameObject.transform.GetChild(3);
        _numberElementFive = _lockBody.gameObject.transform.GetChild(4);
        _numberElementSix = _lockBody.gameObject.transform.GetChild(5);

        _numberElementList.Add(_numberElementOne);
        _numberElementList.Add(_numberElementTwo);
        _numberElementList.Add(_numberElementThree);
        _numberElementList.Add(_numberElementFour);
        _numberElementList.Add(_numberElementFive);
        _numberElementList.Add(_numberElementSix);
    }

    public void RotateElement()
    {
        _numberElement = _controller.InteractionTarget.GetComponent<Transform>();

        switch (_numberElementList.IndexOf(_numberElement))
        {
            case 0:
                _numberElement.transform.DOLocalRotate((_rotateDirection + _angleElementOne), _rotateDuration, RotateMode.Fast);
                _rotateDirection = new Vector3(0, 0, 0);
                _angleElementOne += new Vector3(36, 0, 0);
                _countElementOne += 1;
                CountRotation(_countElementOne);
                CheckRightNumber(_countElementOne, _unlockNumberOne);
                CheckUnlock();

                Debug.Log("Right Number = " + CheckRightNumber(_countElementOne, _unlockNumberOne));
                Debug.Log("Unlock?" + CheckUnlock());

                break;
            case 1:
                _numberElement.transform.DOLocalRotate((_rotateDirection + _angleElementTwo), _rotateDuration, RotateMode.Fast);
                _rotateDirection = new Vector3(0, 0, 0);
                _angleElementTwo += new Vector3(36, 0, 0);
                _countElementTwo += 1;
                CountRotation(_countElementTwo);
                CheckRightNumber(_countElementTwo, _unlockNumberTwo);
                CheckUnlock();

                Debug.Log("Right Number = " + CheckRightNumber(_countElementTwo, _unlockNumberTwo));
                Debug.Log("Unlock?" + CheckUnlock());

                break;
            case 2:
                _numberElement.transform.DOLocalRotate((_rotateDirection + _angleElementThree), _rotateDuration, RotateMode.Fast);
                _rotateDirection = new Vector3(0, 0, 0);
                _angleElementThree += new Vector3(36, 0, 0);
                _countElementThree += 1;
                CountRotation(_countElementThree);
                CheckRightNumber(_countElementThree, _unlockNumberThree);
                CheckUnlock();

                    Debug.Log("Right Number = " + CheckRightNumber(_countElementThree, _unlockNumberThree));
                Debug.Log("Unlock?" + CheckUnlock());

                break;
            case 3:
                _numberElement.transform.DOLocalRotate((_rotateDirection + _angleElementFour), _rotateDuration, RotateMode.Fast);
                _rotateDirection = new Vector3(0, 0, 0);
                _angleElementFour += new Vector3(36, 0, 0);
                _countElementFour += 1;
                CountRotation(_countElementFour);
                CheckRightNumber(_countElementFour, _unlockNumberFour);
                CheckUnlock();

                Debug.Log("Right Number = " + CheckRightNumber(_countElementFour, _unlockNumberFour));
                Debug.Log("Unlock?" + CheckUnlock());

                break;

            case 4:
                _numberElement.transform.DOLocalRotate((_rotateDirection + _angleElementFive), _rotateDuration, RotateMode.Fast);
                _rotateDirection = new Vector3(0, 0, 0);
                _angleElementFive += new Vector3(36, 0, 0);
                _countElementFive += 1;
                CountRotation(_countElementFive);
                CheckRightNumber(_countElementFive, _unlockNumberFive);
                CheckUnlock();

                Debug.Log("Right Number = " + CheckRightNumber(_countElementFive, _unlockNumberFive));
                Debug.Log("Unlock?" + CheckUnlock());

                break;

            case 5:
                _numberElement.transform.DOLocalRotate((_rotateDirection + _angleElementSix), _rotateDuration, RotateMode.Fast);
                _rotateDirection = new Vector3(0, 0, 0);
                _angleElementSix += new Vector3(36, 0, 0);
                _countElementSix += 1;
                CountRotation(_countElementSix);
                CheckRightNumber(_countElementSix, _unlockNumberSix);
                CheckUnlock();

                Debug.Log("Right Number = " + CheckRightNumber(_countElementSix, _unlockNumberSix));
                Debug.Log("Unlock?" + CheckUnlock());

                break;
        }
    }

    public void CountRotation(int count)
    {
        if(count > 9)
        {
            count = 0;
        }
    }

    public bool CheckRightNumber(int count, int unlockNumber)
    {
        if(count != unlockNumber) { return false; }
        return true;
    }

    public bool CheckUnlock()
    {
        if(CheckRightNumber(_countElementOne, _unlockNumberOne) && CheckRightNumber(_countElementTwo, _unlockNumberTwo) 
            && CheckRightNumber(_countElementThree, _unlockNumberThree) && CheckRightNumber(_countElementFour, _unlockNumberFour)
            && CheckRightNumber(_countElementFive, _unlockNumberFive) && CheckRightNumber(_countElementSix, _unlockNumberSix))
        {
            Debug.Log("Play Open Animation");
            return true;
        }
        else return false;
    }
}
