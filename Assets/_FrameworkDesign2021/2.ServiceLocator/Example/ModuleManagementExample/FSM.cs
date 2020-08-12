using UnityEngine;

namespace FrameworkDesign2021._2.ServiceLocator.Example.ModuleManagementExample
{
    public interface IFSM : IModule
    {
        void DoSomething();
    }

    public class FSM : IFSM
    {
        public void DoSomething()
        {
            Debug.Log("FSM DoSomeThing");
        }

        public void InitModule()
        {

        }
    }
}