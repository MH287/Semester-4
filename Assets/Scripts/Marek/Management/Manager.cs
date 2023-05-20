using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance;
    private Dictionary<Type, ManagerModule> _modules;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("2 Managers are present");
        }

        Instance = this;
        _modules = new Dictionary<Type, ManagerModule>();
    }

    public bool ModuleRegistered<T>() where T : ManagerModule => ModuleRegistered(typeof(T));
    public bool ModuleRegistered(Type type) => _modules.ContainsKey(type);

    public void Register(ManagerModule module)
    {
        if (ModuleRegistered(module.GetType()))
            throw new InvalidOperationException();

        _modules.Add(module.GetType(), module);
    }
    public void Unregister(ManagerModule module)
    {
        if (!ModuleRegistered(module.GetType()))
            throw new InvalidOperationException();

        _modules.Remove(module.GetType());
    }

    public T Get<T>() where T : ManagerModule
    {
        if(!ModuleRegistered(typeof(T)))
            throw new InvalidOperationException();

        return (T)_modules[typeof(T)];
    }

    public static T Use<T>() where T : ManagerModule =>
        Application.isPlaying ? Instance.Get<T>() : FindObjectOfType<T>();
}
