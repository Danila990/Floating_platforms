using UnityEngine;
using VContainer;
using MyCode.Core.Scope;
using MyCode.Core.Factory;

namespace MyCode.Core.Installers
{
    public class DatabaseInstaller : MonoInstaller
    {
        [SerializeField] private BaseDatabase _database;

        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterInstance(_database).AsImplementedInterfaces();
            builder.Register<BaseFactory>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}