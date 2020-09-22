using System;
using System.Collections.Generic;

namespace _FrameworkDesign2021._5.TypeEventSystem.Example
{
    public class EventService 
    {
        private List<System.Action> mUnRegisterEventActions = new List<System.Action>();

        public void Register<T>(Action<T> onRecieve)
        {
            QFramework.TypeEventSystem.Register<T>(onRecieve);
        
            mUnRegisterEventActions.Add(() =>
            {
                QFramework.TypeEventSystem.Register<T>(onRecieve);
            });
        }


        public void Send<T>(T eventKey)
        {
            QFramework.TypeEventSystem.Send<T>(eventKey);
        }

        public void UnRegister<T>(Action<T> onRecieve)
        {
            QFramework.TypeEventSystem.UnRegister<T>(onRecieve);
        }

        public void UnRegisterAll()
        {
            mUnRegisterEventActions.ForEach(action => action());
            mUnRegisterEventActions.Clear();
        }
    }
}
