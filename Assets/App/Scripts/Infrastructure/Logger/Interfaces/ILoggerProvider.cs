namespace App.Scripts.Infrastructure.Logger.Interfaces
{
    public interface ILoggerProvider
    {
        IAppLogger CreateLogger(string categoryName);
    }
}