using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _quizCanvas;

    public void OpenWindow()
    {
        _quizCanvas.SetActive(true);
    }

    public void CloseButton()
    {
        _quizCanvas.SetActive(false);
    }
}
