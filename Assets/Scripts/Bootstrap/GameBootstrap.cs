using System;
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
        [SerializeField] private PlayerComponent _playerComponent;
        [SerializeField] private InputComponent _inputComponent;

        protected override async void Awake()
        {
            autoRun = false;
            base.Awake();
            await Load();
            Build();
            Init();
        }

        protected override void Configure(IContainerBuilder builder)
        {
            _inputComponent.Bind(builder);
            _playerComponent.Bind(builder);
        }

        private async Task Load()
        {
            await _inputComponent.Load();
            await _playerComponent.Load();
        }

        private void Init()
        {
            _playerComponent.Init();
        }
    }
}