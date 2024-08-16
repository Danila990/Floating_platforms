using UnityEngine;

namespace MyCode.Core.Factory
{
    public interface IFactory
    {
        public T CreateGameobject<T>(string gameObjectName, Vector3 pos, bool isActive = true) where T : MonoBehaviour;
        public T CreateGameobject<T>(string gameObjectName, bool isActive = true) where T : MonoBehaviour;
        public T CreateScriptable<T>(string gameObjectName) where T : ScriptableObject;
    }
}
