using FrameworkDesign2021._2.ServiceLocator.Example.LayerArchitectureExample;

namespace FrameworkDesign2021._2.ServiceLocator.Example.LayerdArchitectureExample
{
    public interface IArchitecture
    {
        ILogicLayer LogicLayer { get; }

        IBusinessModuleLayer BusinessModuleLayer { get; }

        IPublicModuleLayer PublicModuleLayer { get; }

        IUtiltyLayer UtiltyLayer { get; }

        IBasicModuleLayer BasicModuleLayer { get; }
    }
}