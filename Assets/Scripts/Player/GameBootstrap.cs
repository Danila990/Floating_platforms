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
        private const string PATH_MOBILE_INPUT = "Joystick";

        [Header("Bootstrap")]
        [SerializeField] private bool _isPc;
        [SerializeField] private Player _player;

        private MobileInputService _mobileInputService;

        protected override async void Awake()
        {
            autoRun = false;
            base.Awake();
            await LoadAssets();
            Build();
        }

        protected override void Configure(IContainerBuilder builder)
        {
            BindInputService(builder);
            builder.RegisterComponent(_player);
            builder.RegisterInstance(_player.PlayerHealth);
            builder.RegisterInstance(_player.PlayerMovement);
        }

        private async Task LoadAssets()
        {
            if (!_isPc)
                _mobileInputService = await AssetLoader.LoadGameObject<MobileInputService>(PATH_MOBILE_INPUT);
        }

        private void BindInputService(IContainerBuilder builder)
        {
            IInputService inputService;
            if (_isPc)
                inputService = new PcInputService();
            else
            {
                if (_mobileInputService == null)
                    throw new NullReferenceException("Mobile Input Service is null");

                inputService = _mobileInputService;
            }

            builder.RegisterInstance<IInputService, ITickable>(inputService);
        }
    }
}