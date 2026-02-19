namespace App.Scripts.Infrastructure.SimplePool
{
    public interface ISimplePool
    {
        void Initialize();
    }
    
    public interface ISimplePool<T> : ISimplePool
    {
        T Get();
        void Return(T instance);
    }
    
}