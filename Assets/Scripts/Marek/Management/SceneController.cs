using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SceneController : ManagerModule
{
    public int NextSceneIndex;
    public static bool loaaad;
    public GameObject Player;

    public void LoadSceneStart(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void EndGame()
    {
#if UNITY_EDITOR
EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void LoadScene()
    {
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
    }
    public void UnloadScene()
    {
        SceneManager.UnloadSceneAsync(1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == Player.layer && !SceneManager.GetSceneByBuildIndex(NextSceneIndex).isLoaded)
        {
            if (loaaad)
            {
                loaaad = false;
                return;
            }
            SceneManager.LoadSceneAsync(NextSceneIndex, LoadSceneMode.Additive);
            loaaad = true;
        }
    }

}
