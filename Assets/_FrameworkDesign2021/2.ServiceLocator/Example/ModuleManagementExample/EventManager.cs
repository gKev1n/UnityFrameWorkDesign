using UnityEngine;

namespace FrameworkDesign2021._2.ServiceLocator.Example.ModuleManagementExample
{
    public interface IEventManager : IModule
    {
        void DoSomething();
    }

    public class EventManager : IEventManager
    {
        public IPoolManager mPoolManager { get; set; }

        public void DoSomething()
        {
            Debug.Log("EventManager DoSomeThing");
        }

        public void InitModule()
        {
            mPoolManager = ModuleManagementConfig.Container.GetModule<IPoolManager>();
        }
    }
}