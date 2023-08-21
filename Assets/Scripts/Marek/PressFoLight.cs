using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressFoLight : MonoBehaviour
{
    [SerializeField] private GameObject _light;


    private void Start()
    {
        _light.SetActive(false);
    }
    public void LightOn()
    {
        _light.SetActive(true);
    }
}
