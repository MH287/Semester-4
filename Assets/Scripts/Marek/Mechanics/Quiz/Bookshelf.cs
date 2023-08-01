using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bookshelf : MonoBehaviour
{
    [SerializeField] private int[] _solution;

    [SerializeField] private Animator _doorAnimator;
    [SerializeField] private string _animation;

    [SerializeField] private Animator _bookResetAnimator;
    [SerializeField] private string _bookResetAnimationOne;
    [SerializeField] private string _bookResetAnimationTwo;

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
            //_bookResetAnimator.Play(_bookResetAnimationOne);
            //_bookResetAnimator.Play(_bookResetAnimationTwo);
            _index = 0;
        }
    }

    public void TürAnimation()
    {
        _doorAnimator.Play(_animation);
        Debug.Log("Tür öffnet sich");
    }
}
