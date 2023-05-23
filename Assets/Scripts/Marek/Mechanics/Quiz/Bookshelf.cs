using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bookshelf : MonoBehaviour
{
    [SerializeField] private int[] _solution;
    private int _index;

    public UnityEvent OnSolved;

    public void PressBook(int bookIndex)
    {
        if (_solution[_index] == bookIndex)
        {
            Debug.Log("Correct");
            if (_index == _solution.Length - 1)
            {
                OnSolved.Invoke();
            }
            _index++;
        }
        else
        {
            Debug.Log("Wrong");
            _index = 0;
        }
    }
}
