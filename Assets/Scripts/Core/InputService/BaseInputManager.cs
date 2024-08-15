using System;
using System.Collections.Generic;
using VContainer.Unity;

namespace MyCode.Core.InputService
{
    public class BaseInputManager : ITickable, IImputManager
    {
        private readonly List<BaseInputService> _services = new List<BaseInputService>();
       
        public void Tick()
        {
            foreach (var service in _services)
            {
                if (service.IsActive)
                    service.Tick();
            }
        }

        public void SetInputService<T>(T setService) where T : BaseInputService
        {
            var type = typeof(T);
            foreach (var service in _services)
            {
                if (service.GetType().Equals(type))
                    throw new Exception($"Dublicate Inpit Services: {type}");

                _services.Add(setService);
            }
        }

        public T GetInputService<T>() where T : BaseInputService
        {
            var type = typeof(T);
            foreach (var service in _services)
            {
                if (service.GetType().Equals(type))
                    return (T)service;
            }

            throw new NullReferenceException($"Inpit Services is null: {type}");
        }
    }
}
