using VContainer;
using MyCode.Core.Factory;

namespace MyCode.Core.Scope.Installers
{
    public class FactoryInstaller : MonoInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<IFactory, BaseFactory>(Lifetime.Singleton);
        }
    }
}