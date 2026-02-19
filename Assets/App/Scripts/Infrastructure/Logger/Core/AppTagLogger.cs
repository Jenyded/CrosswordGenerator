using App.Scripts.Infrastructure.Logger.Interfaces;

namespace App.Scripts.Infrastructure.Logger.Core
{
    public class AppTagLogger : IAppLogger
    {
        private readonly ILogProcessor _logProcessor;
        public string Tag { get; }

        public AppTagLogger(ILogProcessor logProcessor, string tag)
        {
            _logProcessor = logProcessor;
            Tag = tag;
        }
        
        public void Log(string message)
        {
            _logProcessor.ProcessLog($"[{Tag}] {message}");
        }
    }
}