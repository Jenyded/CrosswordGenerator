using App.Scripts.Infrastructure.Logger.Interfaces;

namespace App.Scripts.Infrastructure.Logger.Core
{
    public class LoggerProvider : ILoggerProvider
    {
        private readonly ILogProcessor _logProcessor;

        public LoggerProvider(ILogProcessor logProcessor)
        {
            _logProcessor = logProcessor;
        }

        public IAppLogger CreateLogger(string categoryName)
        {
            return new AppTagLogger(_logProcessor, categoryName);
        }
    }
}