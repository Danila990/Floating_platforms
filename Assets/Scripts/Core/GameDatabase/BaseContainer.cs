using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace MyCode.Core.GameDatabase
{
    public abstract class BaseContainer<T>
    {
        [Serializable]
        private struct FactoryData
        {
            public string Key;
            public T Object;
        }

        [SerializeField, ListDrawerSettings(ListElementLabelName = "Key", ElementColor = "GetElementColor"), Searchable, TableList]
        private FactoryData[] _objects;

        public TObject Get<TObject>(string key) where TObject : T 
        {
            foreach (var data in _objects)
            {
                if (data.Key.Equals(key))
                    return (TObject)data.Object;
            }

            throw new NullReferenceException($"Find {nameof(T)} is null");
        }
    }

    [Serializable]
    public class GameobjectContainer : BaseContainer<MonoBehaviour> { }

    [Serializable]
    public class ScriptableObjectContainer : BaseContainer<ScriptableObject> { }
}