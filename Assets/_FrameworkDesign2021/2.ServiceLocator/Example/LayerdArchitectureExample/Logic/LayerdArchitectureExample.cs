using UnityEngine;

namespace FrameworkDesign2021._2.ServiceLocator.Example.LayerdArchitectureExample
{
    public class LayerdArchitectureExample : MonoBehaviour
    {
        private ILoginController mLoginController;

        private IUserInputManager mUserInputManager;

        void Start()
        {
            mLoginController = ArchitectureConfig.Architecture.LogicLayer.GetModule<ILoginController>();
            mUserInputManager = ArchitectureConfig.Architecture.LogicLayer.GetModule<IUserInputManager>();

            mLoginController.Login();
            
            MissionSystem m = new MissionSystem();
            m.SetmJumpCount();
        }

        void Update()
        {
            // 空格
            if (Input.GetKeyUp(KeyCode.Space))
            {
                mUserInputManager.OnInput(KeyCode.Space);
            }
        }
    }
}