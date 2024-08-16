
namespace MyCode.Core.InputService
{
    public interface IImputManager
    {
        public void SetService(InputType inputType);
        public IInputService GetCurrentService();
        public void ChangeUpdateState(bool isActive);
    }
}