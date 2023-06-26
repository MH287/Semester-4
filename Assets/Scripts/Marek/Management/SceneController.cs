using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : ManagerModule
{
    public int NextSceneIndex;
    public static bool loaaad;
    public GameObject Player;

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
