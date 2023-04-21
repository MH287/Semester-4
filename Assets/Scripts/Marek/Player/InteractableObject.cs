using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class InteractableObject : MonoBehaviour
{
    private Outline _Outline;

    [SerializeField] private float _FadeFactor = 2f;

    public bool IsHighlighted;

    [SerializeField] private UnityEvent _onInteractionEvent = new UnityEvent();

    [SerializeField] private Color _outlineColor = Color.white;

    void Start()
    {
        //_Outline = this.gameObject.AddComponent<Outline>();
        //_Outline.OutlineColor = new Color(_outlineColor.r, _outlineColor.g, _outlineColor.b, 0f);
    }

    void Update()
    {
        /*if (IsHighlighted && _Outline.OutlineColor.a < 1f)
        {
            _Outline.OutlineColor = new Color(_outlineColor.r, _outlineColor.g, _outlineColor.b, Mathf.Clamp(_Outline.OutlineColor.a + Time.deltaTime * _FadeFactor, 0f, 1f));
        }
        else if (_Outline.OutlineColor.a > 0f)
        {
            _Outline.OutlineColor = new Color(_outlineColor.r, _outlineColor.g, _outlineColor.b, Mathf.Clamp(_Outline.OutlineColor.a - Time.deltaTime * _FadeFactor, 0f, 1f));
        }*/
    }

    public void Interact()
    {
        Debug.Log("Interacted with " + this.gameObject.name);
        _onInteractionEvent.Invoke();
    }
}
