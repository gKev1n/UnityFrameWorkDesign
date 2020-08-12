using FrameworkDesign2021._2.ServiceLocator.Example.LayerdArchitectureExample;
using UnityEngine;

namespace FrameworkDesign2021._2.ServiceLocator.Example.LayerdArchitectureExample
{
    public interface IUserInputManager : ILogicController
    {
        void OnInput(KeyCode keyCode);
    }

    public class UserInputManager : IUserInputManager
    {
        public void OnInput(KeyCode keyCode)
        {
            Debug.Log("输入了:" + keyCode);

            var missionSystem = ArchitectureConfig.Architecture.BusinessModuleLayer.GetModule<IMissionSystem>();

            missionSystem.OnEvent("JUMP");
        }
    }
}