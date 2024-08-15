using System;

namespace MyCode.Core.InputService
{
    public abstract class BaseInputService
    {
        public abstract event Action<float, float> OnMoveInput;
        public bool IsActive { get; protected set; }

        public virtual void Tick()
        {
            if (!IsActive)
            return;
        }

        public void ChangeActiveState(bool active) => IsActive = active;
    }
}