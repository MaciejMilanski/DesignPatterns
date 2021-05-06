using System;
using System.Collections.Generic;
using System.Text;

using FactoryMethod;

using FactoryMethod.Make2Models;

namespace FactoryMethod.Factories
{
    public class Make2Factory : ICarFactory
    {
        private static Make2Factory _instance;
        public static Make2Factory GetInstance()
        {
            if (_instance == null)
                _instance = new Make2Factory();
            return _instance;
        }
        public ICar CreateCar(EModels model)
        {
            switch (model)
            {
                case EModels.MODEL1:
                    {
                        return new Make2Model1();
                    }
                case EModels.MODEL2:
                    {
                        return new Make2Model2();
                    }
                case EModels.MODEL3:
                    {
                        return new Make2Model3();
                    }
                case EModels.MODEL4:
                    {
                        return new Make2Model4();
                    }
                case EModels.MODEL5:
                    {
                        return new Make2Model5();
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}
