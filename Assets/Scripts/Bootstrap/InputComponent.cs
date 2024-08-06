using System;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using UnityEngine.AddressableAssets;
using System.Threading.Tasks;

namespace MyCode
{
    [Serializable]
    public class InputComponent
    {
        [SerializeField] private bool _isPc;
        [SerializeField] private AssetReferenceGameObject _mobileInputReference;

        private MobileInputService _mobileInputService;

        public async Task Load()
        {
            if (!_isPc)
                _mobileInputService = await AssetLoader.LoadGameObject<MobileInputService>(_mobileInputReference);
        }

        public void Bind(IContainerBuilder builder)
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