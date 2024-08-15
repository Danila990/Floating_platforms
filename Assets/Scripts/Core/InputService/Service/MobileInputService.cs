using System;
using UnityEngine;

namespace MyCode.Core.InputService
{
    public class MobileInputService : BaseInputService
    {
        [SerializeField] private Joystick _joystick;

        public override event Action<float, float> OnMoveInput;

        public override void Tick()
        {
            base.Tick();

            OnMoveInput?.Invoke(_joystick.Horizontal, _joystick.Vertical);
        }
    }
}