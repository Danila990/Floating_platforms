using System;
using UnityEngine;

namespace MyCode.Core.InputService
{
    public class PcInputService : IInputService
    {
        public event Action<float, float> OnMoveInput;

        public void Activate() { }
        public void Deactivate() { }

        public void Tick()
        {
            float inputX = Input.GetAxis("Horizontal");
            float inputZ = Input.GetAxis("Vertical");
            OnMoveInput?.Invoke(inputX, inputZ);
        }
    }
}