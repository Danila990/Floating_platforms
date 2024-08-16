using System;
using VContainer.Unity;

namespace MyCode.Core.InputService
{
    public interface IInputService : ITickable
    {
        public event Action<float, float> OnMoveInput;
        public void Activate();
        public void Deactivate();
    }
}