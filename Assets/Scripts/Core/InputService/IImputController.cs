
namespace MyCode.Core
{
    public interface IImputController
    {
        public void SetInput(InputType inputType);
        public IInputService GetInput();
        public void ChangeUpdateState(bool isActive);
    }
}