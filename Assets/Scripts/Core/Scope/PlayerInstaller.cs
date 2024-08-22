using MyCode._Player;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MyCode.Core
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private InputType _testInput = InputType.PcDafault;

        public override void Install(IContainerBuilder builder)
        {
            BindInput(builder);
            BindPlayer(builder);
        }

        private void BindInput(IContainerBuilder builder)
        {
            InputController inputController = new InputController(_testInput);
            builder.RegisterComponent<IImputController>(inputController).As<ITickable, IInitializable>();
        }

        private void BindPlayer(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<PlayerSpawnPoint>();
            builder.Register<PlayerController>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}
