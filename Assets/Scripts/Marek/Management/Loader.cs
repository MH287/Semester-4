using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public int LoadNetxScene;
    public GameObject Player;
    public static bool loaaad;

    [SerializeField] private GameObject _playerLight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == Player.layer && !SceneManager.GetSceneByBuildIndex(LoadNetxScene).isLoaded)
        {
            if (loaaad)
            {
                loaaad = false;
                return;
            }
            SceneManager.LoadSceneAsync(LoadNetxScene, LoadSceneMode.Additive);
            loaaad = true;
        }
        if (LoadNetxScene == 2)
        {
            _playerLight.SetActive(true);
        }
    }
}
