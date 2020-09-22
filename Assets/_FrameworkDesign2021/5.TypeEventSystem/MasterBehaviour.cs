using System;
using System.Collections;
using System.Collections.Generic;
using _FrameworkDesign2021._4.PackageKit;
using UnityEngine;

public abstract class MasterBehaviour : MonoBehaviour
{
    private List<System.Action> mUnRegisterEventActions = new List<System.Action>();
    
    public void Register<T> (Action<T> onReceive)
    {
        TypeEventSystem.Register<T>(onReceive);
        mUnRegisterEventActions.Add(() =>
        {
            TypeEventSystem.UnRegister<T>(onReceive);
        });
    }

    public void Send<T>(T eventKey)
    {
        TypeEventSystem.Send<T>(eventKey);
    }

    public void UnRegister<T>(Action<T> onReceive)
    {
        TypeEventSystem.UnRegister<T>(onReceive);
    }

    public void UnregisterAll()
    {
        mUnRegisterEventActions.ForEach(action => action());
        mUnRegisterEventActions.Clear();
    }
}
