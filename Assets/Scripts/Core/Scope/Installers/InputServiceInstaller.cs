using UnityEngine;
using VContainer;
using MyCode.Core.InputService;
using VContainer.Unity;

namespace MyCode.Core.Scope.Installers
{
    public class InputServiceInstaller : MonoInstaller
    {
#if UNITY_EDITOR
        [SerializeField] private InputType _inputType = InputType.PcDafault;
#endif

        public override void Install(IContainerBuilder builder)
        {
#if UNITY_EDITOR
            BaseInputManager baseInput = new BaseInputManager();
            baseInput.InputType = _inputType;
            builder.RegisterComponent<IImputManager>(baseInput).As<ITickable, IInitializable>();
            return;
#endif

            builder.Register<IImputManager, BaseInputManager>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}