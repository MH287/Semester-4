using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Unloader : MonoBehaviour
{
    public int UnloadLastScene;
    public GameObject Player;
    [SerializeField] private GameObject _playerLight;
    [SerializeField] private Material _nextSkybox;

    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.layer == Player.layer && SceneManager.GetSceneByBuildIndex(UnloadLastScene).isLoaded)
        {
            SceneManager.UnloadSceneAsync(UnloadLastScene);
            RenderSettings.skybox = _nextSkybox;
        } 

       if(UnloadLastScene == 2)
        {
            _playerLight.SetActive(false);
        }
    }
}
