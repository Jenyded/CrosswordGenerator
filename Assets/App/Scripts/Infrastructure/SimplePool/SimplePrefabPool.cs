using System.Collections.Generic;
using UnityEngine;

namespace App.Scripts.Infrastructure.SimplePool
{
    public class SimplePrefabPool<T> : ISimplePool<T> where T : Component  
    {
        private readonly T _prefab;
        private readonly Transform _parent;
        private readonly int _count;
        private readonly Queue<T> _available;
        private readonly HashSet<T> _inUse;
        private bool _initialized;

        public SimplePrefabPool(T prefab, int count, Transform parent)
        {
            _prefab = prefab;
            _count = count;
            _parent = parent;
            _available = new Queue<T>(count);
            _inUse = new HashSet<T>();
        }

        public void Initialize()
        {
            if (_initialized) return;
            _initialized = true;
            
            for (int i = 0; i < _count; i++)
            {
                var instance = Object.Instantiate(_prefab, _parent);
                instance.gameObject.SetActive(false);
                _available.Enqueue(instance);
            }
        }

        public void Initialize(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var instance = Object.Instantiate(_prefab, _parent);
                instance.gameObject.SetActive(false);
                _available.Enqueue(instance);
            }
        }

        public T Get()
        {
            T instance;
            if (_available.Count > 0)
            {
                instance = _available.Dequeue();
            }
            else
            {
                instance = Object.Instantiate(_prefab, _parent);
            }

            _inUse.Add(instance);
            instance.gameObject.SetActive(true);
            return instance;
        }

        public void Return(T instance)
        {
            if (instance == null) return;
            if (!_inUse.Remove(instance)) return;

            instance.gameObject.SetActive(false);
            if (_parent != null)
                instance.transform.SetParent(_parent);
            _available.Enqueue(instance);
        }

        public int AvailableCount => _available.Count;
        public int InUseCount => _inUse.Count;
    }
}
