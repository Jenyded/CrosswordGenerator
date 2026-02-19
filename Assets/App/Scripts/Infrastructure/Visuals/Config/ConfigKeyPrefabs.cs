using System;
using System.Collections.Generic;
using UnityEngine;

namespace App.Scripts.Infrastructure.Visuals.Config
{
    [Serializable]
    public class KeyPrefabPair
    {
        public string key;
        public GameObject prefab;
    }

    public class ConfigKeyPrefabs : ScriptableObject
    {
        [SerializeField] private List<KeyPrefabPair> keyPrefabs = new List<KeyPrefabPair>();

        public T GetPrefab<T>(string key) where T : UnityEngine.Object
        {
            KeyPrefabPair pair = keyPrefabs.Find(p => p.key == key);
            if (pair?.prefab == null)
                return null;

            if (typeof(T) == typeof(GameObject))
                return pair.prefab as T;

            return pair.prefab.GetComponent<T>();
        }
    }
}
