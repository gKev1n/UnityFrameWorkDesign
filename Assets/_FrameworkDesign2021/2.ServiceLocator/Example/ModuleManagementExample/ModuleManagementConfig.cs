using System;
using FrameworkDesign2021._2.ServiceLocator.Default;
using UnityEngine;

namespace FrameworkDesign2021._2.ServiceLocator.Example.ModuleManagementExample
{
    public class ModuleManagementConfig : MonoBehaviour
    {
        public static ModuleContainer Container = null;

        void Awake()
        {
            var baseType = typeof(IModule);

            var cache = new DefaultModuleCache();
            var factory = new AssemblyModuleFactory(baseType.Assembly,baseType);

            Container = new ModuleContainer(cache,factory);

            // 主动去创建对象
            var poolManager = Container.GetModule<IPoolManager>();
            var fsm = Container.GetModule<IFSM>();
            var resManager = Container.GetModule<IResManager>();
            var eventManager = Container.GetModule<IEventManager>();
            var uiManager = Container.GetModule<IUIManager>();

            var modules = Container.GetAllModules<IModule>();
            
            // 初始化模块
            foreach (var module in modules)
            {
                module.InitModule();
            }
        }

        private void Start()
        {
            var uiManager = ModuleManagementConfig.Container.GetModule<IUIManager>();
            
            uiManager.DoSomething();

        }
    }
}