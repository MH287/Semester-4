using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bookshelf : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _animation;
    private bool _pressedBookOne;
    private bool _pressedBookTwo;
    private bool _pressedBookThree;
    private bool _pressedBookFour;

    public void CheckCorrectBooks()
    {
        if (_pressedBookOne && _pressedBookTwo && _pressedBookThree && _pressedBookFour)
        {
            _animator.Play(_animation);
            Debug.Log("Bookshelf open");
            //_openBookshelf;
        }
        else
        {
            Debug.Log("Falscher Code");
        }
    }

    public void PressCorrectBook1()
    {
        _pressedBookOne = true;
        CheckCorrectBooks();
    }
    public void PressCorrectBook2()
    {
        _pressedBookTwo = true;
        CheckCorrectBooks();
    }
    public void PressCorrectBook3()
    {
        _pressedBookThree = true;
        CheckCorrectBooks();
    }
    public void PressCorrectBook4()
    {
        _pressedBookFour = true;
        CheckCorrectBooks();
    }

    public void PressedWrongBook()
    {
        Debug.Log("Books resettet!");
        _pressedBookOne = false;
        _pressedBookTwo = false;
        _pressedBookThree = false;
        _pressedBookFour = false;
    }
}
