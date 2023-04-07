using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Transform _InteractionTriggerPoint;

    [SerializeField] private Vector3 _TriggerBoxHalfs;


    private InteractableObject _CurrentObj = null;
    public bool CanInteract = true; //HINZUGEFÜGT VON TIM
    public static PlayerInteraction instance;

    void Awake()
    {
        instance = this;
    }
    //BIS HIER

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Collider[] tmpCollider = Physics.OverlapBox(_InteractionTriggerPoint.position, _TriggerBoxHalfs, this.transform.rotation);
        (float distance, InteractableObject iObj) mindistanceObj = (float.MaxValue, null);
        foreach (Collider c in tmpCollider)
        {
            if (c.TryGetComponent<InteractableObject>(out InteractableObject tmpObj))
            {
                if ((tmpObj.transform.position - _InteractionTriggerPoint.position).sqrMagnitude < mindistanceObj.distance)
                {
                    mindistanceObj = ((tmpObj.transform.position - _InteractionTriggerPoint.position).sqrMagnitude, tmpObj);
                }
            }
        }

        if (_CurrentObj != null)
        {
            _CurrentObj.IsHighlighted = false;
        }
        if (mindistanceObj.iObj != null)
        {
            mindistanceObj.iObj.IsHighlighted = true;
        }
        _CurrentObj = mindistanceObj.iObj;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.matrix = _InteractionTriggerPoint.transform.localToWorldMatrix;
        Gizmos.DrawWireCube(Vector3.zero, _TriggerBoxHalfs);
    }

    private void OnInteract()
    {
        if (_CurrentObj != null && CanInteract && _CurrentObj.enabled) //während anderen Aktionen soll der SPieler nicht interagieren dürfen
        {
            _CurrentObj.Interact();
        }
        /*
        else if(DialogueManager.Instance.DialogueIsPlaying) // HINZUGEFÜGT VON TIM
        {
            DialogueManager.Instance.ContinueDialogue();
        */
    }

    public void ForceInteract()
    {
        OnInteract();
    }
}
