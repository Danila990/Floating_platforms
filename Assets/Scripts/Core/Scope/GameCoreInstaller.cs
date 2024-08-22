using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MyCode.Core
{
    public class GameCoreInstaller : MonoInstaller
    {
        [SerializeField] private GameDatabase _database;

        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterComponent<IDatabase>(_database);
            builder.Register<IFactory, Factory>(Lifetime.Singleton);
        }
    }
}
