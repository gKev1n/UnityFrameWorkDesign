using UnityEngine;

namespace FrameworkDesign2021._2.ServiceLocator.Example.ModuleManagementExample
{

    public interface IResManager : IModule
    {
        void DoSomething();
    }

    public class ResManager : IResManager
    {
        public IPoolManager PoolManager { get; set; }

        public void DoSomething()
        {
            Debug.Log("ResManager DoSomething");
        }

        public void InitModule()
        {

        }
    }
}