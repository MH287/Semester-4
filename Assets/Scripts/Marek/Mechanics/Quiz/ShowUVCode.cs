using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class ShowUVCode : MonoBehaviour
{ 
    public void ShowCode(GameObject uVCode, GameObject light)
    {
        uVCode.SetActive(true);
        light.SetActive(true);
    }
}
