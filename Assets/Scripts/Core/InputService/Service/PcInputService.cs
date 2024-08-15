using System;
using UnityEngine;

namespace MyCode.Core.InputService
{
    public class PcInputService : BaseInputService
    {
        public override event Action<float, float> OnMoveInput;

        public override void Tick()
        {
            base.Tick();

            float inputX = Input.GetAxis("Horizontal");
            float inputZ = Input.GetAxis("Vertical");
            OnMoveInput?.Invoke(inputX, inputZ);
        }
    }
}