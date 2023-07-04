using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerModule : MonoBehaviour
{
    void Awake()
    {
        Manager.Instance.Register(this);
        OnAwake();
    }

    protected virtual void OnAwake()
    {

    }

    void OnDestroy()
    {
        if(Manager.Instance != null)
            Manager.Instance.Unregister(this);
    }
}
