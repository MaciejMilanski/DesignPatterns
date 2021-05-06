using System;
using System.Collections.Generic;
using System.Text;

using ClassRegistrationFactoryReflection;

using ClassRegistrationFactoryReflection.Make2Models;

namespace ClassRegistrationFactoryReflection.Factories
{
    public class Make2Factory : ICarFactory
    {
        private readonly Dictionary<string, Type> registeredModels = new Dictionary<string, Type>();
        private static Make1Factory _instance;
        public static Make1Factory GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Make1Factory();
                _instance.RegisterModel("Model1", typeof(Make2Model1));
                _instance.RegisterModel("Model2", typeof(Make2Model2));
            }
            return _instance;
        }
        public void RegisterModel(string ModelId, Type ModelType)
        {
            this.registeredModels.Add(ModelId, ModelType);
        }
        public ICar CreateCar(string ModelId)
        {
            if (registeredModels.TryGetValue(ModelId, out Type ModelType))
                return (ICar)Activator.CreateInstance(ModelType);
            else
                return null;
        }
    }
}
