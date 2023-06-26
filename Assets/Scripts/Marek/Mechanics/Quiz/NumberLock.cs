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
    [SerializeField] private Transform _numberElementOne;
    [SerializeField] private Transform _numberElementTwo;
    [SerializeField] private Transform _numberElementThree;
    [SerializeField] private Transform _numberElementFour;
    [SerializeField] private Transform _numberElementFive;
    [SerializeField] private Transform _numberElementSix;
    [SerializeField] private float _angleX = 0f;
    [SerializeField] private float _angleY = 0f;
    [SerializeField] private float _angleZ = 36f;
    [SerializeField] private Transform _numberElement;

    [SerializeField] private Animator _doorAnimator;

    private Vector3 _rotateDirection;
    private Vector3 _angleElementOne = new Vector3(0,0,0);
    private Vector3 _angleElementTwo = new Vector3(0, 0, 0);
    private Vector3 _angleElementThree = new Vector3(0, 0, 0);
    private Vector3 _angleElementFour = new Vector3(0, 0, 0);
    private Vector3 _angleElementFive = new Vector3(0, 0, 0);
    private Vector3 _angleElementSix = new Vector3(0, 0, 0);
        

    private int _countElementOne;
    private int _countElementTwo;
    private int _countElementThree;
    private int _countElementFour;
    private int _countElementFive;
    private int _countElementSix;

    private bool _checkElementOne;
    private bool _checkElementTwo;
    private bool _checkElementThree;
    private bool _checkElementFour;
    private bool _checkElementFive;
    private bool _checkElementSix;
    private bool _unlock;




    public void Awake()
    {
        _angleElementOne = new Vector3(_angleX, _angleY, _angleZ);
        _angleElementTwo = new Vector3(_angleX, _angleY, _angleZ);
        _angleElementThree = new Vector3(_angleX, _angleY, _angleZ);
        _angleElementFour = new Vector3(_angleX, _angleY, _angleZ);
        _angleElementFive = new Vector3(_angleX, _angleY, _angleZ);
        _angleElementSix = new Vector3(_angleX, _angleY, _angleZ);

        //_numberElementOne = _lockBody.gameObject.transform.GetChild(0);
        //_numberElementTwo = _lockBody.gameObject.transform.GetChild(1);
        //_numberElementThree = _lockBody.gameObject.transform.GetChild(2);
        //_numberElementFour = _lockBody.gameObject.transform.GetChild(3);
        //_numberElementFive = _lockBody.gameObject.transform.GetChild(4);
        //_numberElementSix = _lockBody.gameObject.transform.GetChild(5);

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
                _angleElementOne += new Vector3(_angleX, _angleY, _angleZ);
                _countElementOne += 1;
                CountRotation(_countElementOne);
                CheckRightNumber(_countElementOne, _unlockNumberOne, _checkElementOne);
                CheckUnlock();

                //Debug.Log("Right Number = " + CheckRightNumber(_countElementOne, _unlockNumberOne));
                //Debug.Log("Unlock?" + CheckUnlock());

                break;
            case 1:
                _numberElement.transform.DOLocalRotate((_rotateDirection + _angleElementTwo), _rotateDuration, RotateMode.Fast);
                _rotateDirection = new Vector3(0, 0, 0);
                _angleElementTwo += new Vector3(_angleX, _angleY, _angleZ);
                _countElementTwo += 1;
                CountRotation(_countElementTwo);
                CheckRightNumber(_countElementTwo, _unlockNumberTwo, _checkElementTwo);
                CheckUnlock();

                //Debug.Log("Right Number = " + CheckRightNumber(_countElementTwo, _unlockNumberTwo));
                //Debug.Log("Unlock?" + CheckUnlock());

                break;
            case 2:
                _numberElement.transform.DOLocalRotate((_rotateDirection + _angleElementThree), _rotateDuration, RotateMode.Fast);
                _rotateDirection = new Vector3(0, 0, 0);
                _angleElementThree += new Vector3(_angleX, _angleY, _angleZ);
                _countElementThree += 1;
                CountRotation(_countElementThree);
                CheckRightNumber(_countElementThree, _unlockNumberThree, _checkElementThree);
                CheckUnlock();

                //Debug.Log("Right Number = " + CheckRightNumber(_countElementThree, _unlockNumberThree));
                //Debug.Log("Unlock?" + CheckUnlock());

                break;
            case 3:
                _numberElement.transform.DOLocalRotate((_rotateDirection + _angleElementFour), _rotateDuration, RotateMode.Fast);
                _rotateDirection = new Vector3(0, 0, 0);
                _angleElementFour += new Vector3(_angleX, _angleY, _angleZ);
                _countElementFour += 1;
                CountRotation(_countElementFour);
                CheckRightNumber(_countElementFour, _unlockNumberFour, _checkElementFour);
                CheckUnlock();

                //Debug.Log("Right Number = " + CheckRightNumber(_countElementFour, _unlockNumberFour));
                //Debug.Log("Unlock?" + CheckUnlock());

                break;

            case 4:
                _numberElement.transform.DOLocalRotate((_rotateDirection + _angleElementFive), _rotateDuration, RotateMode.Fast);
                _rotateDirection = new Vector3(0, 0, 0);
                _angleElementFive += new Vector3(_angleX, _angleY, _angleZ);
                _countElementFive += 1;
                CountRotation(_countElementFive);
                CheckRightNumber(_countElementFive, _unlockNumberFive, _checkElementFive);
                CheckUnlock();

                //Debug.Log("Right Number = " + CheckRightNumber(_countElementFive, _unlockNumberFive));
                //Debug.Log("Unlock?" + CheckUnlock());

                break;

            case 5:
                _numberElement.transform.DOLocalRotate((_rotateDirection + _angleElementSix), _rotateDuration, RotateMode.Fast);
                _rotateDirection = new Vector3(0, 0, 0);
                _angleElementSix += new Vector3(_angleX, _angleY, _angleZ);
                _countElementSix += 1;
                CountRotation(_countElementSix);
                CheckRightNumber(_countElementSix, _unlockNumberSix, _checkElementSix);
                CheckUnlock();

                //Debug.Log("Right Number = " + CheckRightNumber(_countElementSix, _unlockNumberSix));
                //Debug.Log("Unlock?" + CheckUnlock());

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

    public bool CheckRightNumber(int count, int unlockNumber, bool state)
    {
        if (count != unlockNumber)
        {
            state = false;
            return _unlock = false; 
        }
        else
        {
            state = true;
            return _unlock = true; 
        }
    }

    public bool CheckUnlock()
    {
        if(CheckRightNumber(_countElementOne, _unlockNumberOne, _checkElementOne) && CheckRightNumber(_countElementTwo, _unlockNumberTwo, _checkElementTwo) 
            && CheckRightNumber(_countElementThree, _unlockNumberThree, _checkElementThree) && CheckRightNumber(_countElementFour, _unlockNumberFour, _checkElementFour)
            && CheckRightNumber(_countElementFive, _unlockNumberFive, _checkElementFive) && CheckRightNumber(_countElementSix, _unlockNumberSix, _checkElementSix))
        {
            Debug.Log("Unlocked");
            _doorAnimator.Play("LE_Laboratory_door");
            Debug.Log("Play Open Animation");
            return true;
        }
        else return false;
    }
}
