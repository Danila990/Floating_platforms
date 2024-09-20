using UnityEngine;
using VContainer;
using Object = UnityEngine.Object;

namespace MyCode.Core
{
    public class Factory : IFactory
    {
        private readonly IDatabase _database;
        private readonly IObjectResolver _objectResolver;

        public Factory(IObjectResolver objectResolver, IDatabase database)
        {
            _database = database;
            _objectResolver = objectResolver;
        }

        public T CreateAndSetPos<T>(string key, Vector3 pos, bool isActive = true) where T : MonoBehaviour
        {
            return CreateAndSetPos(key, pos, isActive).GetComponent<T>();
        }

        public T Create<T>(string key, bool isActive = true) where T : MonoBehaviour
        {
            return Create(key, isActive).GetComponent<T>();
        }

        public GameObject Create(string key, bool isActive = true)
        {
            var newObject = Object.Instantiate(_database.GetGameobject(key));
            newObject.gameObject.SetActive(isActive);
            _objectResolver.Inject(newObject);
            return newObject;
        }

        public GameObject CreateAndSetPos(string key, Vector3 pos, bool isActive = true)
        {
            var newObject = Create(key, isActive);
            newObject.transform.position = pos;
            return newObject;
        }

        public T CreateScriptableObject<T>(string gameObjectName) where T : ScriptableObject
        {
            var newObject = Object.Instantiate(_database.GetScriptableObject<T>(gameObjectName));
            _objectResolver.Inject(newObject);
            return newObject;
        }

        public void InjectObject(object obj) => _objectResolver.Inject(obj);
    }
}
