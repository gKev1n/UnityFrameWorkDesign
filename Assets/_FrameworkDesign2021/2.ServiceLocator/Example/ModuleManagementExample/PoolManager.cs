using UnityEngine;

namespace FrameworkDesign2021._2.ServiceLocator.Example.ModuleManagementExample
{
    public interface IPoolManager : IModule
    {
        void DoSomething();
    }

    public class PoolManager : IPoolManager
    {
        public void DoSomething()
        {
            Debug.Log("PoolManager DoSomething");
        }

        public void InitModule()
        {

        }
    }
}