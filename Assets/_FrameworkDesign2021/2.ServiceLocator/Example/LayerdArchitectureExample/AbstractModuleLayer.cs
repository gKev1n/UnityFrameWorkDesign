using FrameworkDesign2021._2.ServiceLocator.Default;
using FrameworkDesign2021._2.ServiceLocator.Example.LayerArchitectureExample;

namespace FrameworkDesign2021._2.ServiceLocator.Example.LayerdArchitectureExample
{
    public abstract class AbstractModuleLayer : IModuleLayer
    {
        private ModuleContainer mContainer = null;

        protected abstract AssemblyModuleFactory mFactory { get; }

        public AbstractModuleLayer()
        {
            mContainer = new ModuleContainer(new DefaultModuleCache(), mFactory);
        }

        public T GetModule<T>() where T : class
        {
            return mContainer.GetModule<T>();
        }
    }
}