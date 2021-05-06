using System;
using System.Collections.Generic;
using System.Text;

using ClassRagistrationFactory;

using ClassRagistrationFactory.Make2Models;

namespace ClassRagistrationFactory.Factories
{
    public class Make2Factory : ICarFactory
    {
        private readonly Dictionary<string, Func<ICar>> registeredModels = new Dictionary<string, Func<ICar>>();
        private static Make2Factory _instance;
        public static Make2Factory GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Make2Factory();
                _instance.RegisterModel("Model1", () => new Make2Model1());
                _instance.RegisterModel("Model2", () => new Make2Model2());
            }
            return _instance;
        }
        public void RegisterModel(string ModelId, Func<ICar> ModelConstr)
        {
            this.registeredModels.Add(ModelId, ModelConstr);
        }
        public ICar CreateCar(string ModelId)
        {
            //var car = registeredModels.GetValueOrDefault(ModelId);
            var car = registeredModels[ModelId].Invoke();
            return car.createCar();
        }
    }
}
