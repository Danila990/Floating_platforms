using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MyCode.Core
{
    public class InputServiceInstaller : MonoInstaller
    {
        [SerializeField] private InputType _testInput = InputType.PcDafault;

        public override void Install(IContainerBuilder builder)
        {
            InputController inputController = new InputController(_testInput);
            builder.RegisterComponent<IImputController>(inputController).As<ITickable, IInitializable>();
        }
    }
}