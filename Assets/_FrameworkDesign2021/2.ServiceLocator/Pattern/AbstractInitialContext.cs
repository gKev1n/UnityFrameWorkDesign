namespace FrameworkDesign2021._2.ServiceLocator.Pattern
{
    public abstract class AbstractInitialContext
    {
        public abstract IService LookUp(string name);
    }
}