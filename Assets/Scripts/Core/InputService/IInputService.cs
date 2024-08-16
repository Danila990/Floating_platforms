using System;
using VContainer.Unity;

namespace MyCode.Core
{
    public interface IInputService : ITickable
    {
        public event Action<float, float> OnMoveInput;
        public void Activate();
        public void Deactivate();
    }
}