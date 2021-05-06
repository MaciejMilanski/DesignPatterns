using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using ClassRagistrationFactory.Make1Models;

namespace ClassRagistrationFactory.Factories
{
    public class Make1Factory : ICarFactory
    {
        private readonly Dictionary<string, Func<ICar>> registeredModels = new Dictionary<string, Func<ICar>>();
        private static Make1Factory _instance;
        public static Make1Factory GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Make1Factory();
                _instance.RegisterModel("Model1", () => new Make1Model1());
                _instance.RegisterModel("Model2", () => new Make1Model2());
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
