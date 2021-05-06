using System;
using System.Collections.Generic;
using System.Text;

using ClassRagistrationFactory.Make3Models;

namespace ClassRagistrationFactory.Factories
{
    public class Make3Factory : ICarFactory
    {
        private readonly Dictionary<string, Func<ICar>> registeredModels = new Dictionary<string, Func<ICar>>();
        private static Make3Factory _instance;
        public static Make3Factory GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Make3Factory();
                _instance.RegisterModel("Model1", () => new Make3Model1());
                _instance.RegisterModel("Model2", () => new Make3Model2());
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
