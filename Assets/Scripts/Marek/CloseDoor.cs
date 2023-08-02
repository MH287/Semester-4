using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseDoor : MonoBehaviour
{
    public GameObject Player;

    [SerializeField] private Animator _closeDoorAnimation;
    [SerializeField] private string _closeDoorClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == Player.layer)
        {
            Debug.Log("Door Closed");
            _closeDoorAnimation.Play(_closeDoorClip);
        }
    }
}
