using System;
using System.Collections.Generic;

namespace FrameworkDesign2021._2.ServiceLocator
{
    /// <summary>
    /// 用于服务查找 当 Cache 中不存在所需要的服务时，则会从 InitialContext 中进行查找。
    /// </summary>
    public interface IModuleCache
    {
        object GetModule(ModuleSearchKeys keys);
        
        // object GetModules(ModuleSearchKeys keys);

        object GetAllModules();
        
        void AddModule(ModuleSearchKeys keys, object module);
        
        // void AddModules(ModuleSearchKeys keys, object modules);
    }
}