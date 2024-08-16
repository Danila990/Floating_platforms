﻿using UnityEngine;

namespace MyCode.Core.Factory
{
    [CreateAssetMenu(menuName = "BaseDatabase", fileName = nameof(BaseDatabase))]
    public class BaseDatabase : ScriptableObject
    {
        [SerializeField] private GameobjectContainer _gameobjects;
        [SerializeField] private ScriptableObjectContainer _scriptableObject;

        public T GetGameobject<T>(string gameObjectName) where T : MonoBehaviour
        {
            return _gameobjects.Get<T>(gameObjectName);
        }

        public T GetScriptableObject<T>(string gameObjectName) where T : ScriptableObject
        {
            return _scriptableObject.Get<T>(gameObjectName);
        }
    }
}
