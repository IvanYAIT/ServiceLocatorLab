using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IServiceLocator
{
    bool GetService<T>(out T service);
}
