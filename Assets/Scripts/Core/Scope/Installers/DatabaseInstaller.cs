using UnityEngine;
using VContainer;
using MyCode.Core.GameDatabase;
using VContainer.Unity;

namespace MyCode.Core.Scope.Installers
{
    public class DatabaseInstaller : MonoInstaller
    {
        [SerializeField] private BaseDatabase _database;

        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterComponent<IDatabase>(_database);
        }
    }
}