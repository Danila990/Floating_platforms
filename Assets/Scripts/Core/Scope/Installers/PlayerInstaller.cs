using VContainer;
using VContainer.Unity;

namespace MyCode.Core.Scope.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            /*builder.RegisterComponentInHierarchy<PlayerSpawnPoint>();
            builder.Register<Player>(Lifetime.Singleton).AsImplementedInterfaces();*/
        }
    }
}
