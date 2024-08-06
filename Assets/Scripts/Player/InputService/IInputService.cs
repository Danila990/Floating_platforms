using System;
using VContainer.Unity;

namespace MyCode
{
    public interface IInputService : ITickable
    {
        public event Action<float, float> OnMoveInput;
    }
}