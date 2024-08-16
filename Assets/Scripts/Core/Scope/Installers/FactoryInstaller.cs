using VContainer;

namespace MyCode.Core
{
    public class FactoryInstaller : MonoInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<IFactory, Factory>(Lifetime.Singleton);
        }
    }
}