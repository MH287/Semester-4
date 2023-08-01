using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.InputSystem;

public class SceneController : ManagerModule
{
    [SerializeField] private InputActionReference _pauseMenu;
    [SerializeField] private GameObject _pauseMenuPanel;


    private void Start()
    {
        _pauseMenu.action.Enable();
        _pauseMenu.action.performed += ShowPauseMenu;
    }

    public void ShowPauseMenu(InputAction.CallbackContext obj)
    {
        _pauseMenuPanel.SetActive(true);
        Manager.Use<MouseController>().FreeMouse();
    }

    public void LoadSceneStart()
    {
        SceneManager.LoadScene(1);
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
    }

    public void EndGame()
    {
#if UNITY_EDITOR
EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    /*public void LoadScene()
    {
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
    }*/
    public void UnloadScene()
    {
        SceneManager.UnloadSceneAsync(0);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
