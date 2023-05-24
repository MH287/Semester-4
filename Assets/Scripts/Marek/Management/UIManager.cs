using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : ManagerModule
{
    [SerializeField] private GameObject _quizCanvas;
    [SerializeField] private GameObject _interactWithE;

    public void OpenWindow()
    {
        _quizCanvas.SetActive(true);
    }

    public void CloseButton()
    {
        _quizCanvas.SetActive(false);
    }
    public void ShowInteractWithE()
    {
        _interactWithE.SetActive(true);
    }
    public void HideInteractWithE()
    {
        _interactWithE.SetActive(false);
    }
}
