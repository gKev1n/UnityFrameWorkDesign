using FrameworkDesign2021._2.ServiceLocator.Default;
using FrameworkDesign2021._2.ServiceLocator.Example.LayerArchitectureExample;

namespace FrameworkDesign2021._2.ServiceLocator.Example.LayerdArchitectureExample
{
    public interface ISystem
    {
        
    }
    
    public class BusinessModuleLayer : AbstractModuleLayer, IBusinessModuleLayer
    {
        protected override AssemblyModuleFactory mFactory
        {
            get
            {
                return new AssemblyModuleFactory(typeof(ISystem).Assembly,typeof(ISystem));   
            }
        }
    }
}