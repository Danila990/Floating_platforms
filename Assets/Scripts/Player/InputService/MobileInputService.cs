using System;
using UnityEngine;

namespace MyCode
{
    public class MobileInputService : MonoBehaviour, IInputService
    {
        [SerializeField] private Joystick _joystick;

        public event Action<float, float> OnMoveInput;

        public void Tick()
        {
            OnMoveInput?.Invoke(_joystick.Horizontal, _joystick.Vertical);
        }
    }
}