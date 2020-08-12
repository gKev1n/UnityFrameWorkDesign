using FrameworkDesign2021._2.ServiceLocator.Example.LayerArchitectureExample;

using UnityEngine;

namespace FrameworkDesign2021._2.ServiceLocator.Example.LayerdArchitectureExample
{
    public class ArchitectureConfig : IArchitecture
    {
        public ILogicLayer LogicLayer { get; private set; }
        public IBusinessModuleLayer BusinessModuleLayer { get; private set; }
        public IPublicModuleLayer PublicModuleLayer { get; private set;}
        public IUtiltyLayer UtiltyLayer { get; private set; }
        public IBasicModuleLayer BasicModuleLayer { get; private set; }
        
        public static ArchitectureConfig Architecture = null;

        /// <summary>
        /// 项目启动时，自动执行 
        /// </summary>
        [RuntimeInitializeOnLoadMethod]
        static void Config()
        {
            
            Architecture = new ArchitectureConfig();
            
            //逻辑层配置
            Architecture.LogicLayer = new LogicLayer();

            // 主动创建对象
            var loginController = Architecture.LogicLayer.GetModule<ILogicController>();
            var userInputManager = Architecture.LogicLayer.GetModule<IUserInputManager>();
            
            // 业务模块层配置
            Architecture.BusinessModuleLayer = new BusinessModuleLayer();

            var accountSystem = Architecture.BusinessModuleLayer.GetModule<IAccountSystem>();
            var missionSystem = Architecture.BusinessModuleLayer.GetModule<IMissionSystem>();
            
            
        }
    }
}