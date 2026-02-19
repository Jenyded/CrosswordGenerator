using App.Scripts.Infrastructure.SimpleWindows.Window;

namespace App.Scripts.Infrastructure.SimpleWindows
{
    public interface IWindowNavigator
    {
        WindowView CreateWindow(string key);
        void ProcessClose(WindowView window);
    }
}