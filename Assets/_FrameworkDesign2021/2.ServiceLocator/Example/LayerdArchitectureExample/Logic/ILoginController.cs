using FrameworkDesign2021._2.ServiceLocator.Example.LayerdArchitectureExample;
using UnityEngine;

namespace FrameworkDesign2021._2.ServiceLocator.Example.LayerdArchitectureExample
{
    public interface ILoginController : ILogicController
    {
        void Login();
    }

    public class LoginController : ILoginController
    {
        public void Login()
        {
            var accountSystem = ArchitectureConfig.Architecture.BusinessModuleLayer.GetModule<IAccountSystem>();

            accountSystem.Login("hello","abc", (succeed) =>
            {
                if (succeed)
                {
                    Debug.Log("登录成功");        
                }
            });

        }
    }
}