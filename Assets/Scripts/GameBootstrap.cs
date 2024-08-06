using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MyCode
{
    public class GameBootstrap : LifetimeScope
    {
        protected override async void Awake()
        {
            autoRun = false;
            base.Awake();
            await LoadAssets();
            Build();
        }

        protected override void Configure(IContainerBuilder builder)
        {
            
        }

        private async Task LoadAssets()
        {
            await Task.Delay(1000);
        }
    }
}