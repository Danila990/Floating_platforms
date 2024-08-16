using MyCode.Core.Factory;
using System;
using UnityEngine;
using VContainer;

namespace MyCode.Core.InputService
{
    public class MobileInputService : IInputService
    {
        public event Action<float, float> OnMoveInput;

        [Inject] private IFactory _factory;

        [SerializeField] private Joystick _joystick;

        public void Activate()
        {
            if(_joystick is null)
                _joystick = _factory.Create("Joystick").GetComponentInChildren<Joystick>();

            _joystick.gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            _joystick?.gameObject.SetActive(true);
        }

        public void Tick()
        {
            OnMoveInput?.Invoke(_joystick.Horizontal, _joystick.Vertical);
        }
    }
}