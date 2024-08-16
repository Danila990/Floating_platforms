using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MyCode.Core
{
    public class GameScope : LifetimeScope
    {
        [Header("Installers")]
        [SerializeField] private List<ScriptableObjectInstaller> _scriptableObjectInstallers = new List<ScriptableObjectInstaller>();
        [SerializeField] private List<MonoInstaller> _monoInstallers = new List<MonoInstaller>();

        protected override void Configure(IContainerBuilder builder)
        {
            foreach (var installer in _scriptableObjectInstallers)
            {
                if (Parent != null)
                    Parent.Container.Inject(installer);

                installer.Install(builder);
            }

            foreach (var installer in _monoInstallers)
            {
                if (Parent != null)
                    Parent.Container.Inject(installer);

                installer.Install(builder);
            }
        }
    }
}