using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator : IServiceLocator
{
    private Dictionary<Type, IGameService> _services;

    public ServiceLocator(Dictionary<Type, IGameService> services)
    {
        _services = services;
    }

    public bool GetService<T>(out T service)
    {
        service = default;
        if (_services.ContainsKey(typeof(T)))
        {
            service = (T)_services[typeof(T)];
            return true;
        }
        return false;
    }
}