using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace MyCode.Core.Factory
{
    public abstract class BaseContainer<T> : ScriptableObject
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

    [CreateAssetMenu(menuName = "BaseContainer", fileName = nameof(BaseFactory))]
    public class GameobjectContainer : BaseContainer<GameObject> { }

    [CreateAssetMenu(menuName = "BaseContainer", fileName = nameof(ScriptableObjectContainer))]
    public class ScriptableObjectContainer : BaseContainer<ScriptableObject> { }
}