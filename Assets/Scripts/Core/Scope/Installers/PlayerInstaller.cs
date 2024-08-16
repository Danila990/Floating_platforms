using MyCode._Player;
using VContainer;
using VContainer.Unity;

namespace MyCode.Core
{
    public class PlayerInstaller : MonoInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<PlayerSpawnPoint>();
            builder.Register<PlayerController>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}
