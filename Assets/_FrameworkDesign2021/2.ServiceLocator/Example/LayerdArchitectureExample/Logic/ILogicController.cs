using FrameworkDesign2021._2.ServiceLocator.Default;
using FrameworkDesign2021._2.ServiceLocator.Example.LayerArchitectureExample;

namespace FrameworkDesign2021._2.ServiceLocator.Example.LayerdArchitectureExample
{
    public interface ILogicController
    {
        
    }

    public class LogicLayer : AbstractModuleLayer, ILogicLayer
    {
        protected override AssemblyModuleFactory mFactory
        {
            get
            {
                return new AssemblyModuleFactory
                    (typeof(ILogicController).Assembly, typeof(ILogicController));
            }
        }
    }
}