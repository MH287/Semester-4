using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : ManagerModule
{
    [SerializeField] private GameObject _quizCanvas;
    [SerializeField] public GameObject _interactWithE;
    [SerializeField] public GameObject _gameFinish;

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

    public void ShowGameFinish()
    {
        _gameFinish.SetActive(true);
    }
}
