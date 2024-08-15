
namespace MyCode.Core.InputService
{
    public interface IImputManager
    {
        public void SetInputService<T>(T setService) where T : BaseInputService;
        public T GetInputService<T>() where T : BaseInputService;
    }
}