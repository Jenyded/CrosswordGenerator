namespace App.Scripts.Infrastructure.Logger.Core
{
    public interface ILogProcessor
    {
        void ProcessLog(string message);
    }
}