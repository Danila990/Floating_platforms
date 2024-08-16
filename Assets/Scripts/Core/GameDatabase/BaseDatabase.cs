using UnityEngine;

namespace MyCode.Core.GameDatabase
{
    [CreateAssetMenu(menuName = "BaseDatabase", fileName = nameof(BaseDatabase))]
    public class BaseDatabase : ScriptableObject, IDatabase
    {
        [SerializeField] private DataContainer<GameObject> _gameobjects;
        [SerializeField] private DataContainer<ScriptableObject> _scriptableObject;

        public GameObject GetGameobject(string gameObjectName)
        {
            return _gameobjects.Get(gameObjectName);
        }

        public T GetGameobject<T>(string gameObjectName) where T : MonoBehaviour
        {
            return GetGameobject(gameObjectName).GetComponent<T>();
        }

        public T GetScriptableObject<T>(string gameObjectName) where T : ScriptableObject
        {
            return (T)_scriptableObject.Get(gameObjectName);
        }
    }
}
