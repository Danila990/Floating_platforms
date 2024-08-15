using MyCode.Core.Scope;
using VContainer;
using VContainer.Unity;

namespace MyCode.Core.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<PlayerSpawnPoint>();
            builder.Register<Player>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}
