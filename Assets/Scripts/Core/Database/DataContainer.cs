using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace MyCode.Core
{
    [Serializable]
    public class DataContainer<T>
    {
        [Serializable]
        private struct FactoryData
        {
            public string Key;
            public T Object;
        }

        [SerializeField, ListDrawerSettings(ListElementLabelName = "Key", ElementColor = "GetElementColor"), Searchable, TableList]
        private FactoryData[] _objects;

        public T Get(string key)
        {
            foreach (var data in _objects)
            {
                if (data.Key.Equals(key))
                    return data.Object;
            }

            throw new NullReferenceException($"Find {nameof(T)} is null");
        }
    }
}