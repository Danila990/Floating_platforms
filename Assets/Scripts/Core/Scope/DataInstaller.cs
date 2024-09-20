using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MyCode.Core
{
    [CreateAssetMenu(menuName = "DataInstaller", fileName = nameof(DataInstaller))]
    public class DataInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private GameDatabase _database;

        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterComponent<IDatabase>(_database);
            builder.Register<IFactory, Factory>(Lifetime.Singleton);
        }
    }
}