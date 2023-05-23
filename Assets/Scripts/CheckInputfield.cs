using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckInputfield : MonoBehaviour
{
    [SerializeField] private TMP_InputField _codeInputField;
    [SerializeField] private int _inputAsInteger; 
    public int UVCode;

    void Awake()
    {
        _codeInputField.characterLimit = UVCode.ToString().Length;
    }

    public void OpenKeypad()
    {
        gameObject.SetActive(true);
        Manager.Use<MouseController>().FreeMouse();
    }

    public void CheckInput()
    {
        _inputAsInteger = int.Parse(_codeInputField.text);

        if (_inputAsInteger == UVCode)
        {
            gameObject.SetActive(false);
            Manager.Use<MouseController>().LockMouse();
            Debug.Log("Richtiger Code -> Tür öffnet");
        }
        else
        {
            Debug.Log("Falscher Code");
        }
    }
}
