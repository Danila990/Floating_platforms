using System;
using System.Collections.Generic;
using VContainer;
using VContainer.Unity;

namespace MyCode.Core
{
    public class InputController : ITickable, IImputController, IInitializable
    {
        [Inject] private IObjectResolver _objectResolver;

        private readonly Dictionary<InputType, IInputService> _services = new Dictionary<InputType, IInputService>();
        private IInputService _currentService;
        private bool _isUpdate = true;
        private InputType _inputType = InputType.PcDafault;

        public InputController(InputType inputType)
        {
            _inputType = inputType;
        }

        public void Initialize()
        {
            SetInput(_inputType);
        }

        public void Tick()
        {
            if (_currentService is not null)
                if (_isUpdate)
                    _currentService.Tick();
        }

        public void SetInput(InputType inputType)
        {
            if(TryGetService(inputType, out IInputService inputService))
            {
                SetNewService(inputService);
                return;
            }

            switch (inputType)
            {
                case InputType.PcDafault:
                    _currentService = new PcInputService();
                    _objectResolver.Inject(_currentService);
                    SetNewService(_currentService);
                    break;

                case InputType.MobileDafault:
                    _currentService = new MobileInputService();
                    _objectResolver.Inject(_currentService);
                    SetNewService(_currentService);
                    break;

                default:
                    throw new Exception($"_testInput is not bind setting");
            }
        }

        public IInputService GetInput()
        {
            if (_currentService is not null)
                return _currentService;

            throw new NullReferenceException($"Current service is null");
        }

        public void ChangeUpdateState(bool isUpdate)
        {
            _isUpdate = isUpdate;
        }

        private void SetNewService(IInputService inputService)
        {
            _currentService?.Deactivate();
            _currentService = inputService;
            _currentService.Activate();
        }

        private bool TryGetService(InputType inputType, out IInputService inputService)
        {
            if (_services.ContainsKey(inputType))
            {
                inputService = _services[inputType];
                return true;
            }

            inputService = null;
            return false;
        }
    }

    public enum InputType
    {
        PcDafault = 0,
        MobileDafault = 1,
    }
}
