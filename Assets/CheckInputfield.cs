using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckInputfield : MonoBehaviour
{
    [SerializeField] private TMP_InputField _codeInputField;
    [SerializeField] private int _inputAsInteger;
    [SerializeField] private int _uVCode;

    void Awake()
    {
        _codeInputField.characterLimit = _uVCode.ToString().Length;
    }

    public void OpenKeypad()
    {
        gameObject.SetActive(true);
        Manager.Use<MouseController>().FreeMouse();
    }

    public void CheckInput()
    {
        _inputAsInteger = int.Parse(_codeInputField.text);

        if (_inputAsInteger == _uVCode)
        {
            Debug.Log("Richtiger Code -> Tür öffnet");
        }
        else
        {
            Debug.Log("Falscher Code");
        }
    }
}
