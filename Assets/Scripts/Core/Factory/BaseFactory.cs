using UnityEngine;
using VContainer;
using Object = UnityEngine.Object;

namespace MyCode.Core.Factory
{
    public class BaseFactory
    {
        private BaseDatabase _database;
        private IObjectResolver _objectResolver;

        [Inject]
        public void Construct(IObjectResolver objectResolver, BaseDatabase database)
        {
            _database = database;
            _objectResolver = objectResolver;
        }

        public T CreateGameobject<T>(string gameObjectName, Vector3 pos, bool isActive = true) where T : MonoBehaviour
        {
            var newObject = CreateGameobject<T>(gameObjectName, isActive);
            newObject.transform.position = pos;
            return newObject;
        }

        public T CreateGameobject<T>(string gameObjectName, bool isActive = true) where T : MonoBehaviour
        {
            var newObject = Object.Instantiate(_database.GetGameobject<T>(gameObjectName));
            newObject.gameObject.SetActive(isActive);
            _objectResolver.Inject(newObject);
            return newObject;
        }

        public T CreateScriptable<T>(string gameObjectName) where T : ScriptableObject
        {
            var newObject = Object.Instantiate(_database.GetScriptableObject<T>(gameObjectName));
            _objectResolver.Inject(newObject);
            return newObject;
        }
    }
}
