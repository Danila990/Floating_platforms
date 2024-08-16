using UnityEngine;
using VContainer;
using MyCode.Core.Factory;
using MyCode.Core.GameDatabase;

namespace MyCode.Core.Scope.Installers
{
    public class DatabaseInstaller : MonoInstaller
    {
        [SerializeField] private BaseDatabase _database;

        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterInstance<IDatabase>(_database).AsImplementedInterfaces();
        }
    }
}