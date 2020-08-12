using System;
using System.Collections.Generic;

namespace FrameworkDesign2021._2.ServiceLocator
{
    public interface IModuleFactory
    {
        object CreateModule(ModuleSearchKeys keys);

        object CreateAllModules();
    }
}