using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyCode
{
    public class PcInputService : IInputService
    {
        public event Action<float, float> OnMoveInput;

        public void Tick()
        {
            float inputX = Input.GetAxis("Horizontal");
            float inputZ = Input.GetAxis("Vertical");
            OnMoveInput?.Invoke(inputX, inputZ);
        }
    }
}