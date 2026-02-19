using System;
using System.Collections.Generic;

namespace App.Scripts.Infrastructure.SimpleWindows.Window
{
    public class WindowContext
    {
        private readonly Dictionary<Type, object> _components = new Dictionary<Type, object>();

        public T GetComponent<T>()
        {
            var type = typeof(T);
            if (_components.TryGetValue(type, out var value))
                return (T)value;
            throw new KeyNotFoundException($"Component of type {type.Name} not found in WindowContext.");
        }

        public void AddComponent<T>(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            _components[typeof(T)] = value;
        }

        public bool TryGet<T>(out T value)
        {
            value = default;
            var type = typeof(T);

            if (_components.TryGetValue(type, out var valueObject))
            {
                value = (T)valueObject;
                return true;
            }

            return false;   
        }
        
        public bool Has<T>()
        {
            return _components.ContainsKey(typeof(T));
        }
    }
}