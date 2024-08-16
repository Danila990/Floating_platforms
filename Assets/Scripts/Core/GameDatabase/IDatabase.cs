using UnityEngine;

namespace MyCode.Core.GameDatabase
{
    public interface IDatabase
    {
        public T GetGameobject<T>(string gameObjectName) where T : MonoBehaviour;
        public T GetScriptableObject<T>(string gameObjectName) where T : ScriptableObject;
    }
}
