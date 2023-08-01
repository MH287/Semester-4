using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
    public class NumberLockWheel
    {
        public Transform Wheel;
        [Delayed] public int Solution;
        public int CurrentValue;
        [Delayed] public int WheelSides = 10;
    }

    public class NumberLock_New : MonoBehaviour
    {
        [Header("Lock Element")]
        [SerializeField] private GameObject _lockBody;

        [SerializeField] private List<Transform> _numberElementList = new List<Transform>();
        [SerializeField] private NumberLockWheel[] _elements;

        [Header("Animation")]
        [SerializeField, Range(0.5f, 10f)] private float _rotateDuration = 1f;

        [SerializeField] private Animator _doorAnimator;
        [SerializeField, Range(0, 1)] private float _doorAnimationDelay = 0.5f;

        [SerializeField] private GameObject _gameObject;

        [Header("Sound")]
        [SerializeField] private AudioSource _audioSource;

    

    public void RotateElement(Transform target) => RotateElement(_numberElementList.IndexOf(target));

    public void RotateElement(int index)
        {
            _elements[index].CurrentValue = ++_elements[index].CurrentValue % 10;
            _elements[index].Wheel.DOLocalRotate(new Vector3(360f / _elements[index].WheelSides * _elements[index].CurrentValue, 0, 0 ), _rotateDuration);
            UnlockIfSolved();
        }

        public void UnlockIfSolved()
        {
            if (_elements.All(e => e.CurrentValue == e.Solution))
            {
                Debug.Log("Unlocked");
                _gameObject.SetActive(true);
                StartCoroutine(DoorAnimation());
                Debug.Log("Play Open Animation");
            }
        }

        private IEnumerator DoorAnimation()
        {
            yield return new WaitForSeconds(_doorAnimationDelay);
            _audioSource.Play();
            _doorAnimator.Play("LE_Laboratory_door");
        }

        private void OnValidate()
        {
            for (int i = 0; i < _elements.Length; i++)
            {
                if (_elements[i].Solution >= _elements[i].WheelSides ||
                    _elements[i].Solution < 0)
                {
                    Debug.LogError($"NumberLock \"{gameObject.name}\" element #{i}. Solution {_elements[i].Solution} exceeds range [0..{_elements[i].WheelSides - 1}]");
                }
            }
        }
    }
