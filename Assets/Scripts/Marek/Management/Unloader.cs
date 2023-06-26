using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Unloader : MonoBehaviour
{
    public int UnloadLastScene;
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.layer == Player.layer && SceneManager.GetSceneByBuildIndex(UnloadLastScene).isLoaded)
        {
            SceneManager.UnloadSceneAsync(UnloadLastScene);
        } 
    }
}
