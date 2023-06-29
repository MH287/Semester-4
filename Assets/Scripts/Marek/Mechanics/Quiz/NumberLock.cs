using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Pool;

public class NumberLock : MonoBehaviour
{
    [SerializeField] private InteractionController _controller;

    [Header("Lock Element")]
    [SerializeField] private GameObject _lockBody;
    [SerializeField] private List<Transform> _numberElementList = new List<Transform>();
    [SerializeField] private Transform _numberElementOne;
    [SerializeField] private Transform _numberElementTwo;
    [SerializeField] private Transform _numberElementThree;
    [SerializeField] private Transform _numberElementFour;
    [SerializeField] private Transform _numberElementFive;
    [SerializeField] private Transform _numberElementSix;

    [Header("Quiznumbers")]
    [SerializeField] private int _unlockNumberOne;
    [SerializeField] private int _unlockNumberTwo;
    [SerializeField] private int _unlockNumberThree;
    [SerializeField] private int _unlockNumberFour;
    [SerializeField] private int _unlockNumberFive;
    [SerializeField] private int _unlockNumberSix;

    [Header("Animation")]
    [SerializeField, Range(0.5f, 10f)] private float _rotateDuration = 1f;
    [SerializeField] private float _angleX = 0f;
    [SerializeField] private float _angleY = 0f;
    [SerializeField] private float _angleZ = 36f;
    [SerializeField] private Transform _numberElement;
    [SerializeField] private Animator _doorAnimator;
    [SerializeField, Range(0,1)] private float _doorAnimationOffset = 0.5f;

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

    private int _unlockNumberOneRR = 4;
    private int _unlockNumberTwoRR = 2;
    private int _unlockNumberThreeRR = 0;
    private int _unlockNumberFourRR = 4;
    private int _unlockNumberFiveRR = 2;
    private int _unlockNumberSixRR = 0;

    public void Awake()
    {
        _angleElementOne = new Vector3(_angleX, _angleY, _angleZ);
        _angleElementTwo = new Vector3(_angleX, _angleY, _angleZ);
        _angleElementThree = new Vector3(_angleX, _angleY, _angleZ);
        _angleElementFour = new Vector3(_angleX, _angleY, _angleZ);
        _angleElementFive = new Vector3(_angleX, _angleY, _angleZ);
        _angleElementSix = new Vector3(_angleX, _angleY, _angleZ);

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
                _countElementOne = ++_countElementOne % 10;
                CheckRightNumber(_countElementOne, _unlockNumberOne);
                CheckUnlock();
                RickRoll();
                Debug.Log(_countElementOne);
                //Debug.Log(CountRotation(_countElementOne));
                break;
            case 1:
                _numberElement.transform.DOLocalRotate((_rotateDirection + _angleElementTwo), _rotateDuration, RotateMode.Fast);
                _rotateDirection = new Vector3(0, 0, 0);
                _angleElementTwo += new Vector3(_angleX, _angleY, _angleZ);
                _countElementTwo = ++_countElementTwo % 10;
                CheckRightNumber(_countElementTwo, _unlockNumberTwo);
                CheckUnlock();
                break;
            case 2:
                _numberElement.transform.DOLocalRotate((_rotateDirection + _angleElementThree), _rotateDuration, RotateMode.Fast);
                _rotateDirection = new Vector3(0, 0, 0);
                _angleElementThree += new Vector3(_angleX, _angleY, _angleZ);
                _countElementThree = ++_countElementThree % 10;
                CheckRightNumber(_countElementThree, _unlockNumberThree);
                CheckUnlock();
                RickRoll();
                break;
            case 3:
                _numberElement.transform.DOLocalRotate((_rotateDirection + _angleElementFour), _rotateDuration, RotateMode.Fast);
                _rotateDirection = new Vector3(0, 0, 0);
                _angleElementFour += new Vector3(_angleX, _angleY, _angleZ);
                _countElementFour = ++_countElementFour % 10;
                CheckRightNumber(_countElementFour, _unlockNumberFour);
                CheckUnlock();
                RickRoll();
                break;

            case 4:
                _numberElement.transform.DOLocalRotate((_rotateDirection + _angleElementFive), _rotateDuration, RotateMode.Fast);
                _rotateDirection = new Vector3(0, 0, 0);
                _angleElementFive += new Vector3(_angleX, _angleY, _angleZ);
                _countElementFive = ++_countElementFive % 10;
                CheckRightNumber(_countElementFive, _unlockNumberFive);
                CheckUnlock();
                RickRoll();
                break;

            case 5:
                _numberElement.transform.DOLocalRotate((_rotateDirection + _angleElementSix), _rotateDuration, RotateMode.Fast);
                _rotateDirection = new Vector3(0, 0, 0);
                _angleElementSix += new Vector3(_angleX, _angleY, _angleZ);
                _countElementSix = ++_countElementSix % 10;
                CheckRightNumber(_countElementSix, _unlockNumberSix);
                CheckUnlock();
                RickRoll();
                break;
        }
    }
    public bool CheckRightNumber(int count, int unlockNumber)
    {
        if (count != unlockNumber)
        {
            return false; 
        }
        else
        {
            return true; 
        }
    }

    public bool CheckUnlock()
    {
        if(CheckRightNumber(_countElementOne, _unlockNumberOne) && CheckRightNumber(_countElementTwo, _unlockNumberTwo) 
            && CheckRightNumber(_countElementThree, _unlockNumberThree) && CheckRightNumber(_countElementFour, _unlockNumberFour)
            && CheckRightNumber(_countElementFive, _unlockNumberFive) && CheckRightNumber(_countElementSix, _unlockNumberSix))
        {
            Debug.Log("Unlocked");
            StartCoroutine(DoorAnimation());
            Debug.Log("Play Open Animation");
            return true;
        }
        else return false;
    }

    public bool RickRoll()
    {
        if (CheckRickRoll(_countElementOne, _unlockNumberOneRR) && CheckRickRoll(_countElementTwo, _unlockNumberTwoRR) 
            && CheckRickRoll(_countElementThree, _unlockNumberThreeRR) && CheckRickRoll(_countElementFour, _unlockNumberFourRR) 
            && CheckRickRoll(_countElementFive, _unlockNumberFiveRR) && CheckRickRoll(_countElementSix, _unlockNumberSixRR))
        {
            Debug.Log("Play RickRoll");
            return true;
        }
        else return false;
    }
    public bool CheckRickRoll(int count, int unlockNumber)
    {
        if (count != unlockNumber)
        {
            return false;
        }
        else
        {
            return true;
        }
    }


    IEnumerator DoorAnimation()
    {
        yield return new WaitForSeconds(_doorAnimationOffset);
        _doorAnimator.Play("LE_Laboratory_door");
    }
}
