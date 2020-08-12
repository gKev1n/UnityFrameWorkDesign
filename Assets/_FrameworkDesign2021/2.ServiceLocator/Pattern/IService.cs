namespace FrameworkDesign2021._2.ServiceLocator.Pattern
{
    public interface IService
    {
        string Name { get; }

        void Execute();
    }
}