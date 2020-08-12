using UnityEngine;

namespace FrameworkDesign2021._2.ServiceLocator.Example.ModuleManagementExample
{

    public interface IUIManager : IModule
    {
        void DoSomething();
    }

    public class UIManager : IUIManager
    {
        public IResManager mResManager { get; set; }
        public IEventManager mEventManager { get; set; }


        public void DoSomething()
        {
            Debug.Log("UIManager DoSomething");

            mResManager.DoSomething();
            mEventManager.DoSomething();
        }

        public void InitModule()
        {
            mResManager = ModuleManagementConfig.Container.GetModule<IResManager>();
            mEventManager = ModuleManagementConfig.Container.GetModule<IEventManager>();
        }
    }
}