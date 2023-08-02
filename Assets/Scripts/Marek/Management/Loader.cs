using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public int LoadNetxScene;
    public GameObject Player;
    public static bool loaaad;
    [SerializeField] private AudioSource _audioManager;
    [SerializeField] private AudioClip _nextAudioClip;
    [SerializeField] private Material _nextSkybox;
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
            _audioManager.clip = _nextAudioClip;
            _audioManager.Play();
            RenderSettings.skybox = _nextSkybox;
            loaaad = true;
        }
        if (LoadNetxScene == 2)
        {
            _playerLight.SetActive(true);
        }
    }
}
