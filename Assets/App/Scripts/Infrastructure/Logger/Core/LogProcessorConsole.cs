using UnityEngine;

namespace App.Scripts.Infrastructure.Logger.Core
{
    public class LogProcessorConsole : ILogProcessor
    {
        public void ProcessLog(string message)
        {
            Debug.Log(message);
        }
    }
}